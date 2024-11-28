import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import type { Media } from '@/models/media'

export const useMediaStore = defineStore('media', {
  state: () => ({
    media: [] as Media[],
    autoCompleteOptions: [] as string[]
  }),
  actions: {
    setMedia(mediaInput: Media[]) {
      this.media = mediaInput;
    },
    setAutocompleteOptions(input: string[]) {
      this.autoCompleteOptions = input;
    }
  }
})
