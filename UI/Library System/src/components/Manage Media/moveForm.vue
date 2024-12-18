<script lang="ts">
import { defineComponent, ref, watch } from 'vue';
import { useMediaStore } from '../../stores/media';
import MediaService from '@/services/MediaService';
import type { MediaItem } from '@/models/filters';

export default defineComponent({
  name: 'Add Media',
  setup() {
    const mediaStore = useMediaStore();
    const media = ref(mediaStore.media);
    const mediaItems = ref(mediaStore.mediaItems);
    const showPopup = ref(false);
    const selectedMedia = ref<string | null>(null);

    const handleSubmit = async (event: Event) => {
      event.preventDefault();
      const formData = new FormData(event.target as HTMLFormElement);

      const newMediaMove = {
        media: formData.get('media'),
        branchFrom: formData.get('branchFrom'),
        branchDestination: formData.get('branchDestination'),
      };
      console.log('Form Data Submitted:', newMediaMove);
      showPopup.value = true;

      setTimeout(() => {
        showPopup.value = false;
      }, 3000); // Popup disappears after 3 seconds
    };

    watch(selectedMedia, async (newVal) => {
      if (newVal) {
        await GetMediaItems(parseInt(newVal));
      }
    });

    const GetMediaItems = async (media_id: number) => {
      const mediaService = new MediaService();
      const filter: MediaItem = {}
      const success = await mediaService.getMediaItems(filter);

      if (success) console.log(`Media items loaded successfully for ID: ${media_id}`+ mediaStore.mediaItems);
      else console.log(`Failed to load media items for ID: ${media_id}`);
    };
  

    return {
      mediaStore,
      media,
      mediaItems,
      selectedMedia,
      handleSubmit,
      showPopup,
      GetMediaItems, // Expose the method for the watcher
    };
  },
});
</script>

<template>
  <body>
    <div class="form-container">
      <h2>Select Media and Branch</h2>
      <form @submit="handleSubmit" action="/move-media" method="POST">
        <!-- Media Selection -->
        <label for="media">Choose Media Title to Move:</label>
        <select id="media" name="media" v-model="selectedMedia" required>
          <option value="">-- Select Media --</option>
          <option v-for="item in media" :key="item.id" :value="item.name">
            {{ item.name }}
          </option>
          <option value="test-media">Test Media</option>
        </select>

        <div v-if="selectedMedia">
          <label for="specific-option">Choose Media Location:</label>
          <select id="specific-option" name="specificOption" required>
            <option value="">-- Select Option --</option>
            <option value="option-specific" v-for="item in mediaItems" :key="item.id">
              {{ selectedMedia }}<!--{{ item.library_id.name }}-->
            </option>
          </select>
        </div>

        <label for="branch">Choose Destination Branch:</label>
        <select id="branch" name="branchDestination" required>
          <option value="">-- Select Branch --</option>
          <option v-for="item in mediaItems" :key="item.id" :value="item.library_id">
            {{ item.library_id }}
          </option>
          <option value="test-branch">Test Branch</option>
        </select>

        <button type="submit">Move Media</button>
        <button
          type="button"
          @click="$router.push('/manage')"
          style="margin-top: 10px; background-color: #6c757d;"
        >
          Back
        </button>
      </form>

      <div v-if="showPopup" class="popup-overlay">
        <div class="popup">
          <p>Request Submitted!</p>
        </div>
      </div>
    </div>
  </body>
</template>


<style scoped>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        .form-container {
            max-width: 400px;
            margin: 0 auto;
            padding: 20px;
            background-color: white;
            border: 1px solid #ccc;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }
        label {
            display: block;
            margin-bottom: 8px;
            font-weight: bold;
        }
        select, button {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }
        button {
            background-color: #007BFF;
            color: white;
            font-size: 16px;
            cursor: pointer;
        }
        button:hover {
            background-color: #0056b3;
        }
        .popup-overlay {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.5);
            display: flex;
            justify-content: center;
            align-items: center;
            z-index: 1000;
        }
        .popup {
            background: white;
            padding: 20px;
            border-radius: 5px;
            text-align: center;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }
</style>