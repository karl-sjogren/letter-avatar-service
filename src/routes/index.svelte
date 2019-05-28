<script>
  import AvatarPreview from '../components/avatar-preview.svelte';
  import PreviewInput from '../components/preview-input.svelte';
  import { name } from '../stores/name-store.js';
</script>

<style>
.preview {
	text-align: center
}
.preview-images {
  transform: perspective(1600px) rotateY(-25deg) rotateX(50deg) rotateZ(0deg)
}
</style>

<svelte:head>
  <title>Letter Avatar Service</title>
</svelte:head>

<div class="preview">
  <div class="preview-images">
    <AvatarPreview name={$name} size="large" />
    <AvatarPreview name={$name} size="medium" />
    <AvatarPreview name={$name} size="small" />
    <AvatarPreview name={$name} size="tiny" />
    <AvatarPreview name={$name} size="minuscule" />
  </div>
  <PreviewInput value={$name} />
</div>
