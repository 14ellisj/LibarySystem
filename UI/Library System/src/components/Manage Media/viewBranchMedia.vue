<script lang="ts">
import { defineComponent, ref, watch } from 'vue';
import { useMediaStore } from '../../stores/media';
import type { libraryMediaItemsFilter } from '@/models/filters';
import MediaService from '@/services/MediaService';

export default defineComponent({
  name: 'ViewBranchMedia',
  setup() {
    const mediaStore = useMediaStore();
    const selectedBranch = ref<string | null>(null); 
    const library = ref(mediaStore.library);
    const mediaItems = ref(mediaStore.libraryItems);

    const submitForLibraryMediaItems = async (libraryId: number) => {
      console.log('submitForLibraryMediaItems is called with libraryId:', libraryId);
      const mediaService = new MediaService();
      const filter: libraryMediaItemsFilter = {
        library_id: libraryId,
      };
      try {
        const data = await mediaService.getLibraryMediaItems(filter);
        mediaItems.value = data;
        console.log('Media items fetched successfully:', data);
      } catch (error) {
        console.error('Failed to submit for media items:', error);
      }
    };

    watch(selectedBranch, (newValue) => {
      console.log('Selected branch changed:', newValue);

      if (newValue) {
        const selectedBranchItem = library.value.find((item) => item.id === Number(newValue));

        if (selectedBranchItem) {
          console.log('Calling submitForLibraryMediaItems with libraryId:', selectedBranchItem.id);
          submitForLibraryMediaItems(selectedBranchItem.id);
        } else {
          console.warn('No matching branch found in library for:', newValue);
        }
      } else {
        console.warn('Selected branch is null or undefined.');
      }
    });

    return {
      mediaStore,
      selectedBranch,
      library, 
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

    <div class="data-display" v-if="selectedBranch">
      <h2>Media Titles:</h2>
      <ul>
        <li v-for="(item, index) in mediaStore.libraryItems" :key="index">
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
  min-height: 100vh;
  display: flex;
  flex-direction: column;
  box-sizing: border-box;
}

.container {
  text-align: center;
  padding: 30px;
  background: #ffffff;
  border-radius: 12px;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
  max-width: 400px;
  width: 90%;
  margin: auto; 
  margin-top: 50px; 
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
  margin-left: 10px;
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
