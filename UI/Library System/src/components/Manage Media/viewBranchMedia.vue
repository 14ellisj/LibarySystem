<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import { useMediaStore } from '../../stores/media';
import type { MediaItem } from '@/models/filters';
import MediaService from '@/services/MediaService';

export default defineComponent({
  name: 'ViewBranchMedia',
  setup() {
    const mediaStore = useMediaStore(); 
    const selectedBranch = ref('');
    const mediaService = new MediaService();


    const fetchMediaItems = async () => {
      try {
        const filter: MediaItem = {mediaId}; 
        const data = await mediaService.getMediaItem(filter);
        mediaStore.setMediaItem(data); 
      } catch (error) {
        console.error('Failed to fetch media items:', error);
      }
    };

    onMounted(() => {
      fetchMediaItems();
    });

    return {
      mediaStore,
      selectedBranch,
      submitForMediaItems: async (mediaId: number) => {
        const filter: MediaItem = {
          media_id: mediaId,
        };
        try {
          const data = await mediaService.getMediaItem(filter);
          mediaStore.setMediaItem(data); 
          console.log('Media items fetched successfully');
        } catch (error) {
          console.error('Failed to submit for media items:', error);
        }
      },
    };
  },
});
</script>

<template>
  <div>
    <h1>Select a Branch</h1>

    <select v-model="selectedBranch">
      <option value="" disabled>Select a branch</option>
      <option v-for="item in mediaStore.mediaItems" :key="item.id">
        {{ item.library_id.name }}
      </option>
    </select>

    <div v-if="selectedBranch">
      <h2>Data for {{ selectedBranch }}</h2>
      <ul>
        <li v-for="(item, index) in mediaStore.mediaItems" :key="index">
          {{ item.id }}
        </li>
      </ul>
    </div>

    <div v-else>
      <p>Please select a branch to view its data.</p>
      <p>or</p>
      <p>
        <button @click="submitForMediaItems(1)">Move Media</button>
      </p>
    </div>
  </div>
</template>

<style scoped>
    body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            min-height: 100vh;
            background-color: #f4f4f9;
        }
        .container {
            text-align: center;
            padding: 20px;
            background: white;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }
        select {
            padding: 10px;
            font-size: 16px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        button {
            padding: 10px;
            font-size: 16px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        .data-display {
            padding: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
            background: #f9f9f9;
        }
</style>