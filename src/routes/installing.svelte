<svelte:head>
	<title>Installing Letter Avatar Service</title>
</svelte:head>

<h1>Installing Letter Avatar Service</h1>

<h2>Docker</h2>

<p>The service can be installed in serveral ways. The easiest would be by using the <a href="https://hub.docker.com/r/karlsjogren/letter-avatars">docker image from Docker Hub</a>.</p>

<code>
docker pull karlsjogren/letter-avatars
docker run -d -p 80:80 karlsjogren/letter-avatars
</code>

<h2>From GitHub release</h2>

<p>Releases are available over at <a href="https://github.com/karl-sjogren/letter-avatar-service/releases">GitHub</a> and are built as Framework-dependent deployment packages.</p>

<p>To run this .NET Core 3.0 Preview 5 Runtime (or above) has to be available on the system.</p>

<p>To get it running simply extract the zip file and execute the correct binary depending on your system</p>

<code>
./LetterAvatarService # For OSX/Linux
dotnet LetterAvatarService.dll # For Windows
</code>

<h2>From source</h2>

<p>Clone the repository using GIT.</p>

<code>
git clone https://github.com/karl-sjogren/letter-avatar-service.git
</code>

<p>Or download the latest version as a <a href="https://github.com/karl-sjogren/letter-avatar-service/archive/master.zip">zip-file</a> and unzip it.</p>

<p>Change into the LetterAvatarService folder and execute it using .Net CLI.</p>

<code>
cd src/LetterAvatarService
dotnet run
</code>