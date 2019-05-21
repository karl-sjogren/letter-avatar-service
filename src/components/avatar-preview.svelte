<script>
  export let size, name;

  let baseUrl = 'https://letter-avatars.herokuapp.com/avatars/svg/';
  $: url = baseUrl + encodeURIComponent(name);
</script>

<style>
  .avatar-preview-minuscule {
    max-width: 32px
  }

  .avatar-preview-tiny {
    max-width: 64px
  }

  .avatar-preview-small {
    max-width: 128px
  }

  .avatar-preview-medium {
    max-width: 256px
  }

  .avatar-preview-large {
    max-width: 512px
  }
</style>

<img src={url} alt={name} class="avatar-preview avatar-preview-{size}" />