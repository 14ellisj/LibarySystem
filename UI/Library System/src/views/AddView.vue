<script lang="ts">
import AddMedia from '@/components/AddNewMedia/addMedia.vue';
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'add-media',
  components: {
    AddMedia,
  },
})
</script>

<template>
  <div class="container">
    <AddMedia />
  </div>
</template>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  align-content: center;
}
</style>