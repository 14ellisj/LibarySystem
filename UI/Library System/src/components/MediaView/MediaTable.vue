<script lang="ts">
import { defineComponent, ref } from 'vue'

export default defineComponent({
  name: "MediaTable",
  data() {
    return {
      mediaData: Media[]
    }
  },
  methods: {
    increment() {
      this.count++;
      this.message = "Incremented";
    }
  }
})

</script>

<template>
  <div>
    {{count}}
  </div>

  <button @click="increment()">Click me</button>

</template>

<style scoped>
</style>