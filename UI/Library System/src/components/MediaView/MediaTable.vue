<script lang="ts">
import { defineComponent, ref } from 'vue'
import { type Media } from '../../models/media'
import MediaService from '@/services/MediaService'

export default defineComponent({
  name: 'MediaTable',
  data() {
    return {
      mediaData: [] as Media[],
    }
  },
  methods: {},
  mounted() {
    let m = new MediaService()
    m.getData().then((result) => (this.mediaData = result))
  },
})
</script>

<template>
  <div v-if="mediaData.length > 0">
    {{ mediaData[0].author.first_name }}
  </div>
</template>

<style scoped></style>
