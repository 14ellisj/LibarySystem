import { defineStore } from 'pinia'
import type { Media } from '@/models/media'
import type { MediaItem } from '@/models/mediaItem'
import type { Library } from '@/models/library'

export const useMediaStore = defineStore('media', {
  state: () => ({
    media: [] as Media[],
    library: [] as Library[],
    mediaItems: [] as MediaItem[],
    autoCompleteOptions: [] as string[],
  }),
  actions: {
    setMedia(mediaInput: Media[]) {
      this.media = mediaInput
    },
    setMediaItem(mediaItemInput: MediaItem[]) {
      this.mediaItems = mediaItemInput
      console.log(this.mediaItems)
    },
    setLibraryData(libraryInput: Library[]) {
      this.library = libraryInput
      console.log(this.library)
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




