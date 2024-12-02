<script lang="ts">
import FrontView from '../components/StartView/FrontView.vue'
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'Front',
  components: {
    FrontView,
  },
})
</script>

<template>
  <div>
    <FrontView />
  </div>
</template>
