import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import type { Media } from '@/models/media'

export const useMediaStore = defineStore('media', {
  state: () => ({
    media: [{
      id:456,
      name:"Test",
    }] as Media[],
    count: 0
  }),
  actions: {
    setMedia(mediaInput: Media[]) {
      this.media = mediaInput;
      console.log(this.media);
    }
  }
})
