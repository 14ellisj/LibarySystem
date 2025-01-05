import { defineStore } from 'pinia'
import type { Media } from '@/models/media'
import type { MediaItem } from '@/models/mediaItem'
import type { Library } from '@/models/library'

export const useMediaStore = defineStore('media', {
  state: () => ({
    media: [] as Media[],
    library: [] as Library[],
    mediaItems: [] as MediaItem[],
    libraryItems: [] as MediaItem[],
    autoCompleteOptions: [] as string[],
    mediaMoves: [] as Array<{ Id: number; mediaName: string; mediaId: number; branchFrom: string; branchDestination: string; branchDestinationId: number;}>,
  }),
  actions: {
    setMedia(mediaInput: Media[]) {
      this.media = mediaInput
    },
    setMediaItem(mediaItemInput: MediaItem[]) {
      this.mediaItems = mediaItemInput
      console.log(this.mediaItems)
    },
    setLibraryMediaItem(libraryMediaItemInput: MediaItem[]) {
      this.libraryItems = libraryMediaItemInput
      console.log(this.libraryItems)
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
    },
    setMediaMove(moveData: { Id: number; mediaName: string; mediaId: number; branchFrom: string; branchDestination: string; branchDestinationId: number; }) {
      this.mediaMoves.push(moveData);
    },
    borrowMediaItem(mediaId: number) {
      var mediaIndex = this.media.findIndex(x => x.id === mediaId);
      this.media[mediaIndex].is_borrowed_by_user = true;
    },
    markUnavailable(mediaId: number) {
      var mediaIndex = this.media.findIndex(x => x.id === mediaId)
      this.media[mediaIndex].is_available = false;
      console.log(this.media[mediaIndex]);
    },
    setTitle(title: string) {
      this.title = title
    },
  }
})




