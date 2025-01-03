<script lang="ts">
import Reservations from '@/components/Manage Media/reservations.vue';
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'add-media',
  components: {
    Reservations,
  },
})
</script>

<template>
  <div class="container">
    <Reservations />
  </div>
</template>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  align-content: center;
}
</style>