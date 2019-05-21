<script>
  import { name } from '../stores/name-store.js';

  export let value;

  function handleFocus() {
    name.stopRandomGeneration();
  }

  function handleChange(event) {
    name.setName(event.srcElement.value);
  }
</script>

<style>
.preview-input {
    width: 90%;
    font-size: 2rem;
    border-radius: 12px;
    border: 6px solid #f0f8ff;
    padding: 8px;
    text-align: center
}
</style>

<input type="text" class="preview-input" value={value} on:keydown={handleChange} on:focus={handleFocus} />