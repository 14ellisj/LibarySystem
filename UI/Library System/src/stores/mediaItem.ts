import { defineStore } from 'pinia'
import type { Media_Item } from '@/models/media_item'

export const useMediaItemStore = defineStore('mediaItem', {
  state: () => ({
    mediaItem: [] as Media_Item[],
  }),
  actions: {
    setMediaItem(mediaItemInput: Media_Item[]) {
      this.mediaItem = mediaItemInput
  },
}
})

