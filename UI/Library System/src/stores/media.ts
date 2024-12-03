import { defineStore } from 'pinia'
import type { Media } from '@/models/media'
import axios from 'axios';

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
    },
    async removeFromWishlist(mediaId: number): Promise<void> {
      try {
        await axios.delete(`/media/${mediaId}`);
        this.media = this.media.filter((item) => item.id !== mediaId);
      } catch (error) {
        console.error('Error removing media from wishlist:', error);
        throw error;
      }
    }
  }
})
