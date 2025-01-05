<script lang="ts">
import ChangeQuantity from '@/components/Manage Media/changeQuantity.vue'
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'add-media',
  components: {
    ChangeQuantity,
  },
})
</script>

<template>
  <div class="container">
    <ChangeQuantity/>
  </div>
</template>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  align-content: center;
}
</style>