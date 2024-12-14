<script lang="ts">
import ViewBranchMedia from '@/components/Manage Media/viewBranchMedia.vue'
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'add-media',
  components: {
    ViewBranchMedia,
  },
})
</script>

<template>
  <div class="container">
    <ViewBranchMedia/>
  </div>
</template>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  align-content: center;
}
</style>