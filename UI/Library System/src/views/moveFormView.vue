<script lang="ts">
import moveForm from '@/components/Manage Media/moveForm.vue';
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'move-form',
  components: {
    moveForm,
  },
})
</script>

<template>
  <div class="container">
    <moveForm/>
  </div>
</template>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  align-content: center;
}
</style>