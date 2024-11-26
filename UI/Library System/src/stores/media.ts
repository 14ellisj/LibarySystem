import { defineStore } from 'pinia'
import type { Media } from '@/models/media'

export const useMediaStore = defineStore('media', {
  state: () => ({
    media: [{}] as Media[],
    count: 0
  }),
  actions: {
    setMedia(mediaInput: Media[]) {
      this.media = mediaInput;
      console.log(this.media);
    }
  }
})
