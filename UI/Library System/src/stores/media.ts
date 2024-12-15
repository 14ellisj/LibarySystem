import { defineStore } from 'pinia'
import type { Media } from '@/models/media'
import type { Media_Item } from '@/models/media_item'

export const useMediaStore = defineStore('media', {
  state: () => ({
    media: [] as Media[],
    mediaItem: [] as Media_Item[],
    autoCompleteOptions: [] as string[],
  }),
  actions: {
    setMedia(mediaInput: Media[]) {
      this.media = mediaInput
    },
    setMediaItem(mediaItemInput: Media_Item[]) {
      this.mediaItem = mediaItemInput
    },
    setAutocompleteOptions(input: string[]) {
      this.autoCompleteOptions = input
    },
    updateMediaItem(updatedItem: Media) {
      var mediaIndex = this.media.findIndex(x => x.id === updatedItem.id);
      this.media[mediaIndex] = updatedItem;
      console.log(updatedItem)
      console.log(this.media)
    }
  },
})




