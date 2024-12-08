<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useWishListStore } from '../../stores/wishlist';
import type { MediaFilter } from '@/models/filters';
import { SearchType } from '@/models/searchType';
import MediaService from '@/services/MediaService';

export default defineComponent({
  name: 'SingleMediaView',
  data() {
    var query: string = "";
    var searchType: number = 0;

    const mediaService = new MediaService();

    return{
      searchType,
      query,
      mediaService,
    }
  },
  setup() {
    const storeW = useWishListStore();

    const fetchWishlist = async (): Promise<void> => {
      try {
        await storeW.fetchAllWishlistItems();
        console.log(storeW.Wishlist)
      } catch (error) {
        console.error('Failed to fetch wishlist:', error);
      }
    };

    return {
      storeW,
      fetchWishlist,
    };

  },
  methods: {
    async submit(fromSuggestions: boolean) {
        const filter: MediaFilter = {
            title: this.searchType === SearchType.Title ? this.query : undefined,
            author: this.searchType === SearchType.Author ? this.query : undefined,
            is_selected: fromSuggestions
        }
        await this.mediaService.filterData(filter);
        this.$router.push('/wishlist');
    },
  }
});
</script>

<template>
    <h2>Profile</h2>
    <button onclick="window.location.href = 'Home';"> Orders </button> <br>
    <button @click="fetchWishlist" >Wishlist</button> <br>
    <button onclick="window.location.href = 'Return';"> Return Media </button> <br>
    <button onclick="window.location.href = 'Home';"> Settings </button> <br>
    <button onclick="window.location.href = 'logIn';"> Log Out </button>
</template>
  
<style scoped> 
    button {
        color: var(--secondary-color);
        padding: 1%;
        text-align: center;
        margin: 0.81rem;
    }
</style>