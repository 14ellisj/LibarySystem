import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import type { Media } from '@/models/media'

export const useMediaStore = defineStore('media', {
  state: () => ({
    media: [] as Media[]
  }),
  getters: {
    media: (state) => state.media
  },
  actions: {
    setMedia(media: Media[]) {
      this.media = media;
    }
  }
})
