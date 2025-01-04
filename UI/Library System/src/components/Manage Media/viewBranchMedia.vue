<script lang="ts">
import { defineComponent, ref, watch } from 'vue';
import { useMediaStore } from '../../stores/media';
import type { libraryMediaItemsFilter } from '@/models/filters';
import MediaService from '@/services/MediaService';

export default defineComponent({
  name: 'ViewBranchMedia',
  setup() {
    const mediaStore = useMediaStore();
    const selectedBranch = ref<string | null>(null); // Initialize with null to match the empty state
    const mediaService = new MediaService();
    const library = ref(mediaStore.library);
  
    // Watch for changes in selectedBranch
    watch(selectedBranch, async (newValue) => {
      if (newValue) {
        const branchId = Number(newValue);
        const selectedLibraryMediaItem = library.value.find((item) => item.id === branchId); // Match ID
        if (selectedLibraryMediaItem) {
          await fetchLibraryMediaItems(selectedLibraryMediaItem.id);
        }
      }
    });

    // Function to fetch media items for a specific library
    const fetchLibraryMediaItems = async (libraryId: number) => {
      const filter: libraryMediaItemsFilter = {
        library_id: libraryId,
      };
      try {
        const data = await mediaService.getLibraryMediaItems(filter);
        mediaStore.libraryMediaItems = data; // Update mediaStore directly
        console.log('Media items fetched successfully:', data);
      } catch (error) {
        console.error('Failed to fetch media items:', error);
      }
    };

    return {
      mediaStore,
      selectedBranch,
    };
  },
});
</script>


<template>
  <div class="container">
    <h1>Select a Branch</h1>

    <div class="instructions">
      <p>Please select a branch to view its data.</p>
    </div>

    <select v-model="selectedBranch">
      <option value="" disabled>Select a branch</option>
      <option v-for="item in mediaStore.library" :key="item.id" :value="item.id">
        {{ item.id }}. {{ item.name }}
      </option>
    </select>

    <div class="data-display">
      <ul>
        <li v-for="(item, index) in mediaStore.libraryMediaItems" :key="index">
          {{ item.media.name }}
        </li>
      </ul>
    </div>


    <div class="action-buttons">
      <button @click="$router.push('/move');">Move Media</button>
      <button @click="$router.push('/request');">Requests</button>
    </div>
  </div>
</template>


<style scoped>
body {
  font-family: Arial, sans-serif;
  margin: 0;
  padding: 0;
  background-color: #f4f4f9;
  display: flex;
  align-items: center;
  justify-content: center;
  min-height: 100vh;
}

.container {
  text-align: center;
  padding: 30px;
  background: #ffffff;
  border-radius: 12px;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
  max-width: 400px;
  width: 90%;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}

h1 {
  color: #333333;
  margin-bottom: 20px;
  font-size: 24px;
}

select {
  padding: 12px;
  font-size: 16px;
  margin-bottom: 20px;
  border: 1px solid #ccc;
  border-radius: 4px;
  width: 100%;
  box-sizing: border-box;
}

button {
  padding: 12px;
  font-size: 16px;
  background-color: var(--secondary-color);
  color: #ffffff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.instructions {
  margin-top: 20px;
  color: #666666;
}

.action-buttons {
  margin-top: 20px;
}

.data-display {
  padding: 15px;
  margin-top: 20px;
  border: 1px solid #ddd;
  border-radius: 8px;
  background: #f9f9f9;
}

ul {
  list-style: none;
  padding: 0;
}

li {
  padding: 5px 0;
  color: #333333;
  font-size: 16px;
}
</style>
