<script lang="ts">
import Wishlist from '../components/WishlistView/Wishlist.vue'
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'Wish-list',
  components: {
    Wishlist,
  },
})
</script>

<template>
  <div class="container">
    <Wishlist />
  </div>
</template>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  align-content: center;
}
</style>
