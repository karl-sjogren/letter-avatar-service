<script>
  import AvatarPreview from '../components/avatar-preview.svelte';
  export let segment;
</script>

<style>
  nav {
    border-bottom: 1px solid rgba(255, 62, 0, 0.1);
    font-weight: 300;
    padding: 0 1em;
  }

  ul {
    margin: 0;
    padding: 0;
    display: inline-block;
  }

  /* clearfix */
  ul::after {
    content: '';
    display: block;
    clear: both;
  }

  li {
    display: block;
    float: left;
  }

  .selected {
    position: relative;
    display: inline-block;
  }

  .selected::after {
    position: absolute;
    content: '';
    width: calc(100% - 1em);
    height: 2px;
    background-color: rgb(255, 62, 0);
    display: block;
    bottom: -1px;
  }

  a,
  span {
    text-decoration: none;
    padding: 1em 0.5em;
    display: block;
  }

  .brand {
    font-weight: bold;
  }

  .letter-logo {
    display: block;
    max-width: 300px;
    height: 56px;
    float: right;
    margin-top: 10px;
  }
</style>

<nav>
  <ul>
    <li class="brand">
      <span>Letter Avatar Service</span>
    </li>
    <li>
      <a class={segment === undefined ? 'selected' : ''} href=".">home</a>
    </li>
    <li>
      <a class={segment === 'installing' ? 'selected' : ''} href="installing">installing</a>
    </li>
    <li>
      <a class={segment === 'using' ? 'selected' : ''} href="using">using</a>
    </li>
  </ul>
  <div class="letter-logo">
    <AvatarPreview name="L E" size="minuscule" />
    <AvatarPreview name="T T" size="minuscule" />
    <AvatarPreview name="E R" size="minuscule" />
    <AvatarPreview name="A V" size="minuscule" />
    <AvatarPreview name="A T" size="minuscule" />
    <AvatarPreview name="A R" size="minuscule" />
    <AvatarPreview name="S" size="minuscule" />
  </div>
</nav>
