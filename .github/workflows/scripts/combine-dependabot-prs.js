// @ts-check

// Adapted version of https://github.com/hrvey/combine-prs-workflow
// https://github.com/hrvey/combine-prs-workflow/blob/master/LICENSE

// To get the below types, run `npm install --save-dev github:actions/github-script`
/** @param {import('@types/github-script').AsyncFunctionArguments} AsyncFunctionArguments */
module.exports = async ({ github, context, core }, inputs) => {
  try {
    const targetBranchRef = 'heads/' + inputs.combineBranchName;
    let existingBranch = null;
    try {
      existingBranch = await github.rest.git.getRef({
        owner: context.repo.owner,
        repo: context.repo.repo,
        ref: targetBranchRef
      });
    } catch(error) {
      if(error?.status == 404) {
        console.log(`No existing branch ${targetBranchRef} found. Continuing.`);
      } else {
        console.log(error);
        core.setFailed('Failed to check for existing combined branch. Exiting.');
        return;
      }
    }

    if(!!existingBranch) {
      console.log(`Found existing branch ${targetBranchRef}. Trying to remove it.`)

      await github.rest.git.deleteRef({
        owner: context.repo.owner,
        repo: context.repo.repo,
        ref: targetBranchRef
      });
    }
  } catch(error) {
    console.log(error);
    core.setFailed('Failed to remove existing combined branch. Exiting.');
    return;
  }

  const pulls = await github.paginate('GET /repos/:owner/:repo/pulls', {
    owner: context.repo.owner,
    repo: context.repo.repo
  });

  let dependencies = new Set();
  let branchesAndPRStrings = [];
  let baseBranch = null;
  let baseBranchSHA = null;

  for(const pull of pulls) {
    const branch = pull['head']['ref'];
    console.log(`Checking pull request for branch ${branch}.`);

    if(!branch.startsWith('dependabot')) {
      continue;
    }

    console.log(`Branch matched prefix: ${branch}`);
    let statusOK = true;

    console.log(`Checking green status: ${branch}`);
    const checkRuns = await github.paginate('GET /repos/{owner}/{repo}/commits/{ref}/check-runs', {
      owner: context.repo.owner,
      repo: context.repo.repo,
      ref: branch
    });

    for(const checkRun of checkRuns) {
      console.log('Validating check conclusion: ' + checkRun.conclusion);
      if(checkRun.conclusion != 'success' && checkRun.conclusion != 'skipped') {
        console.log(`Discarding ${branch} with check conclusion ${checkRun.conclusion}.`);
        statusOK = false;
      }
    }

    console.log(`Checking labels for branch ${branch}.`);
    const labels = pull['labels'];
    for(const label of labels) {
      const labelName = label['name'];
      console.log('Checking label: ' + labelName);

      if(labelName == inputs.ignoreLabel) {
        console.log(`Discarding ${branch} with label ${labelName}.`);
        statusOK = false;
      }
    }

    if(statusOK) {
      console.log(`Adding branch to array: ${branch}`);

      const title = `${pull['title']}`;
      const prString = `#${pull['number']} ${title}`;

      branchesAndPRStrings.push({ branch, prString, title });
      baseBranch = pull['base']['ref'];
      baseBranchSHA = pull['base']['sha'];
    }
  }

  if(branchesAndPRStrings.length == 0) {
    core.setFailed('No pull requests/branches matched criteria. Exiting.');
    return;
  }

  try {
    await github.rest.git.createRef({
      owner: context.repo.owner,
      repo: context.repo.repo,
      ref: 'refs/heads/' + inputs.combineBranchName,
      sha: baseBranchSHA
    });
  } catch(error) {
    console.log(error);
    core.setFailed('Failed to create combined branch.');
    return;
  }

  const combinedPRs = [];
  const mergeFailedPRs = [];
  for(const { branch, prString, title } of branchesAndPRStrings) {
    try {
      await github.rest.repos.merge({
        owner: context.repo.owner,
        repo: context.repo.repo,
        base: inputs.combineBranchName,
        head: branch,
      });

      console.log(`Merged branch ${branch}.`);
      combinedPRs.push(prString);

      const singleNameRegex = /(?:Bump\s)(?:the\s)?(.*?)\s(?:from|group)/gi;
      const singleNameMatch = singleNameRegex.exec(title);
      if(!!singleNameMatch) {
        const dependency = singleNameMatch[1];
        console.log(`Adding dependency name to array: ${dependency}.`);
        dependencies.add(dependency);
      }

      const multiNameRegex = /Bump\s([^\s]*?)(?:,\s([^\s]*?))?(?:,\s([^\s]*?))?(?:,\s([^\s]*?))?(?:,\s([^\s]*?))?(?:,\s([^\s]*?))?(?:,\s([^\s]*?))?\sand\s([^\s]*?)$/gi;
      const multiNameMatch = multiNameRegex.exec(title);
      if(!!multiNameMatch) {
        for(let i = 1; i < multiNameMatch.length; i++) {
          const dependency = multiNameMatch[i];
          if(!!dependency) {
            console.log(`Adding dependency name to array: ${dependency}.`);
            dependencies.add(dependency);
          }
        }
      }
    } catch(error) {
      console.log(`Failed to merge branch ${branch}.`);
      mergeFailedPRs.push(prString);
    }
  }

  console.log('Creating combined pull request.');

  const combinedPRsString = combinedPRs.join('\n');

  let body = `✅ This PR was created by combining the following dependabot PRs:\n\n${combinedPRsString}`;

  if(mergeFailedPRs.length > 0) {
    const mergeFailedPRsString = mergeFailedPRs.join('\n');
    body += `\n\n⚠️ The following PRs were left out due to merge conflicts:\n\n${mergeFailedPRsString}`
  }

  let dependenciesDisplay;
  if(dependencies.size > 1) {
    const dependenciesArray = [...dependencies];
    dependenciesDisplay = dependenciesArray.slice(0, -1).join(', ') + ' and ' + dependenciesArray.slice(-1);
  } else if(dependencies.size == 1) {
    dependenciesDisplay = [...dependencies][0];
  } else {
    dependenciesDisplay = 'unknown dependencies';
  }

  await github.rest.pulls.create({
    owner: context.repo.owner,
    repo: context.repo.repo,
    title: `Combined PR with updates for ${dependenciesDisplay}`,
    head: inputs.combineBranchName,
    base: baseBranch,
    body: body
  });
}
