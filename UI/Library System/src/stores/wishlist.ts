import { defineStore } from 'pinia';
import type { WishList } from '@/models/wishlist';
import axios from 'axios';

export const useWishListStore = defineStore('wishlist', {
  state: () => ({
    Wishlist: [] as WishList[],
    count: 0,
  }),
  actions: {
    setWishList(WishListInput: WishList[]) {
      this.Wishlist = WishListInput;
      console.log('Wishlist updated:', this.Wishlist);
    },
    async fetchAllWishlistItems(): Promise<void> {
      try {
        const response = await axios.get('https://localhost:5132/wishlist');
        this.Wishlist = response.data; 
        console.log('Fetched all wishlist items');
      } catch (error) {
        console.error('Error fetching wishlist items:', error);
        throw error;
      }
    },
    async removeFromWishlist(mediaId: number): Promise<void> {
      try {
        await axios.delete(`/wishlist/${mediaId}`);
        this.Wishlist = this.Wishlist.filter((item) => item.id !== mediaId);
      } catch (error) {
        console.error('Error removing media from wishlist:', error);
        throw error;
      }
    },
  }
});
