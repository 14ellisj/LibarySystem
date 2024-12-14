<script lang="ts">
import { defineComponent, ref, computed } from 'vue';
import { useMediaStore } from '../../stores/media';
import { useMediaItemStore } from '@/stores/mediaItem';

export default defineComponent({
  name: 'ViewBranchMedia',
  setup() {
    const mediaStore = useMediaStore();
    const mediaItemStore = useMediaItemStore
    const selectedBranch = ref('');
    const mediaItem = ref(useMediaItemStore().mediaItem);

    // Computed property to get media data for the selected branch
    const branchData = computed(() => {
      return mediaItem.value.find(branch => branch.name === selectedBranch.value)?.data || [];
    });

    return {
      mediaStore,
      mediaItemStore,
      selectedBranch,
      branchData,
      mediaItem
    };
  }
});
</script>

<template>
  <div>
    <h1>Select a Branch</h1>

    <!-- Dropdown for selecting a branch -->
    <select v-model="selectedBranch">
      <option value="" disabled>Select a branch</option>
      <option v-for="branch in mediaStore.branches" :key="branch.name" :value="branch.name">
        {{ branch.name }}
      </option>
    </select>

    

    <!-- Display data for the selected branch -->
    <div v-if="selectedBranch">
      <h2>Data for {{ selectedBranch }}</h2>
      <ul>
        <li v-for="(item, index) in branchData" :key="index">
          {{ item }}
        </li>
      </ul>
    </div>

    <!-- Message when no branch is selected -->
    <div v-else>
      <p>Please select a branch to view its data.</p>
      <p> or </p>
      <p><button @click="$router.push('/move')">Move Media</button></p>
      <p> or </p>
      <p><button @click="$router.push('/add')">Add New Media</button></p>
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