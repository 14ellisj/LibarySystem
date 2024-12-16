import { defineStore } from 'pinia'
import type { Media } from '@/models/media'

export const useMediaStore = defineStore('media', {
  state: () => ({
    media: [] as Media[],
    autoCompleteOptions: [] as string[],
  }),
  actions: {
    setMedia(mediaInput: Media[]) {
      this.media = mediaInput
    },
    setAutocompleteOptions(input: string[]) {
      this.autoCompleteOptions = input
    },
    borrowMediaItem(mediaId: number) {
      var mediaIndex = this.media.findIndex(x => x.id === mediaId);
      this.media[mediaIndex].is_borrowed_by_user = true;
    },
    markUnavailable(mediaId: number) {
      var mediaIndex = this.media.findIndex(x => x.id === mediaId)
      this.media[mediaIndex].is_available = false;
      console.log(this.media[mediaIndex]);
    }
  },
})
