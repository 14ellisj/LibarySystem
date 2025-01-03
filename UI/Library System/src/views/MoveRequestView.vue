<script lang="ts">
import moveRequests from '@/components/Manage Media/moveRequests.vue';
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'add-media',
  components: {
    moveRequests,
  },
})
</script>

<template>
  <div class="container">
    <moveRequests/>
  </div>
</template>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  align-content: center;
}
</style>