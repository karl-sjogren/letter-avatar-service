import { writable } from 'svelte/store';
import previewNames from './preview-names';

function createName() {
  let interval;
  const { subscribe, set } = writable('Letter Avatars', () => {
    interval = setInterval(() => {
      let randomName = previewNames[Math.floor(Math.random() * previewNames.length)];
      set(randomName);
    }, 500);

    return () => clearInterval(interval);
  });

  return {
    subscribe,
    stopRandomGeneration: () => clearInterval(interval),
    setName: name => set(name),
    reset: () => set('Letter Avatars')
  };
}

export const name = createName();