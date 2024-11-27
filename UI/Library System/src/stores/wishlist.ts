import { defineStore } from 'pinia'
import type { WishList } from '@/models/wishlist'

export const useWishListStore = defineStore('wishlist', {
  state: () => ({
    Wishlist: [{
        id:567
    }] as WishList[],
    count: 0
  }),
  actions: {
    setWishList(WishListInput: WishList[]) {
      this.Wishlist = WishListInput;
      console.log(this.Wishlist);
    }
  }
})