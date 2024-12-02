<script lang="ts">
import SingleItemView from '../components/SingleMediaView/SingleItemView.vue'
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'Item',
  components: {
    SingleItemView,
  },
})
</script>

<template>
  <div>
    <SingleItemView />
  </div>
</template>
