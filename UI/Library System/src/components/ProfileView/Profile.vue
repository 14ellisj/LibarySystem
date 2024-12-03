<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useWishListStore } from '../../stores/wishlist';

export default defineComponent({
  name: 'SingleMediaView',
  setup() {
    const storeW = useWishListStore();

    const fetchWishlist = async (): Promise<void> => {
      try {
        await storeW.fetchAllWishlistItems();
      } catch (error) {
        console.error('Failed to fetch wishlist:', error);
      }
    };

    return {
      storeW,
      fetchWishlist,
    };

  },
});
</script>

<template>
    <h2>Profile</h2>
    <button onclick="window.location.href = '';"> Orders </button> <br>
    <button onclick="window.location.href = 'Wishlist';" @click="fetchWishlist" >Wishlist</button> <br>
    <button onclick="window.location.href = 'Return';"> Return Media </button> <br>
    <button onclick="window.location.href = '';"> Settings </button> <br>
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