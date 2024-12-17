<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import { useMediaStore } from '../../stores/media';
import type { MediaItem } from '@/models/filters';
import MediaService from '@/services/MediaService';

export default defineComponent({
  name: 'ViewBranchMedia',
  setup() {
    const mediaStore = useMediaStore(); // Pinia store instance
    const selectedBranch = ref('');
    const mediaService = new MediaService();

    // Fetch media items on component mount
    const fetchMediaItems = async () => {
      try {
        const filter: MediaItem = { media_id }; // Adjust this filter as needed
        const data = await mediaService.getMediaItem(filter);
        mediaStore.setMediaItem(data); // Set data in the Pinia store
      } catch (error) {
        console.error('Failed to fetch media items:', error);
      }
    };

    // Fetch data when the component is mounted
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

    <!-- Dropdown for selecting a branch -->
    <select v-model="selectedBranch">
      <option value="" disabled>Select a branch</option>
      <option v-for="item in mediaStore.mediaItems" :key="item.id">
        {{ item.library_id.name }}
      </option>
    </select>

    <!-- Display data for the selected branch -->
    <div v-if="selectedBranch">
      <h2>Data for {{ selectedBranch }}</h2>
      <ul>
        <li v-for="(item, index) in mediaStore.mediaItems" :key="index">
          {{ item.id }}
        </li>
      </ul>
    </div>

    <!-- Message when no branch is selected -->
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
button {
  margin: 10px 0;
  padding: 8px 12px;
  background-color: #007bff;
  color: white;
  border: none;
  cursor: pointer;
  border-radius: 4px;
}
button:hover {
  background-color: #0056b3;
}
</style>

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