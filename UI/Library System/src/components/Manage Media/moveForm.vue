<script lang="ts">
import { defineComponent, ref, watch } from 'vue';
import { useMediaStore } from '../../stores/media';
import MediaService from '@/services/MediaService';
import type { MediaItemsFilter } from '@/models/filters';

export default defineComponent({
  name: 'Add Media',
  setup() {
    const mediaStore = useMediaStore();
    const media = ref(mediaStore.media);
    const mediaItems = ref(mediaStore.mediaItems);
    const library = ref(mediaStore.library);
    const showPopup = ref(false);
    const showError = ref(false);
    const selectedMedia = ref<string | null>(null);

    const generateUniqueId = (): number =>
      Number(`${Date.now()}${Math.floor(Math.random() * 10000)}`);

    const Id = ref(generateUniqueId());

  const handleSubmit = async (event: Event) => {
  event.preventDefault();

  Id.value = generateUniqueId();

  const formData = new FormData(event.target as HTMLFormElement);

  formData.append('Id', Id.value.toString());

  const branchFrom = formData.get('branchFrom') as string | null;
  const branchDestination = formData.get('branchDestination') as string | null;
  const mediaName = formData.get('media') as string | null;

  if (!branchFrom || !branchDestination || !mediaName) {
    console.error('Form data is missing required fields');
    return;
  }

  if (branchFrom === branchDestination) {
    showError.value = true;
    setTimeout(() => {
      showError.value = false;
    }, 3000);
    return;
  }

  const branchDestinationLibrary = library.value.find(
    (item) => item.name === branchDestination
  );
  const branchDestinationId = branchDestinationLibrary
    ? branchDestinationLibrary.id
    : null;

  const selectedMediaItem = mediaItems.value.find(
    (item) => item.media.name === mediaName
  );

  if (!selectedMediaItem) {
    console.error('Selected media item not found');
    return;
  }

  const mediaId = selectedMediaItem.id; 

  const newMediaMove = {
    mediaName,
    mediaId, 
    branchFrom,
    branchDestination,
    branchDestinationId,
    Id: Id.value, 
  };

  console.log('Form Data Submitted:', newMediaMove);

  mediaStore.setMediaMove(newMediaMove);

  showPopup.value = true;

  setTimeout(() => {
    showPopup.value = false;
  }, 3000);
};

    watch(selectedMedia, (newValue) => {
      if (newValue) {
        const selectedMediaItem = media.value.find((item) => item.name === newValue);
        if (selectedMediaItem) {
          submitForMediaItems(selectedMediaItem.id);
        }
      }
    });

    const submitForMediaItems = async (mediaId: number) => {
      const mediaService = new MediaService();
      const filter: MediaItemsFilter = {
        media_id: mediaId,
      };
      try {
        const data = await mediaService.getMediaItems(filter);
        mediaItems.value = data;
        console.log('Media items fetched successfully:', data);
      } catch (error) {
        console.error('Failed to submit for media items:', error);
      }
    };

    return {
      mediaStore,
      media,
      mediaItems,
      selectedMedia,
      handleSubmit,
      showPopup,
      showError,
      library,
      Id, 
    };
  },
});
</script>

<template>
  <body>
    <div class="form-container">
      <h2>Select Media and Branch</h2>
      <form :id="Id.toString()" @submit="handleSubmit" action="/move-media" method="POST">
        <label for="media">Choose Media Title to Move:</label>
        <select id="media" name="media" v-model="selectedMedia" required>
          <option value="">-- Select Media --</option>
          <option v-for="item in media" :key="item.id" :value="item.name">
            {{ item.name }}
          </option>
        </select>

        <div v-if="selectedMedia">
          <label for="specific-option">Choose Media Location:</label>
          <select id="specific-option" name="branchFrom" required>
            <option value="">-- Select Option --</option>
            <option
              v-for="item in mediaItems"
              :key="item.id"
              :value="item.library.name"
              :disabled="!item.media.is_available"
            >
            {{ item.media.name }} - {{ item.library.name }} ({{ item.media.is_available ? 'Available' : 'Not Available' }})
            </option>
          </select>
        </div>

        <label for="branch">Choose Destination Branch:</label>
        <select id="branch" name="branchDestination" required>
          <option value="">-- Select Branch --</option>
          <option v-for="item in library" :key="item.id" :value="item.name">
            {{ item.id }}. {{ item.name }}
          </option>
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

      <div v-if="showError" class="popup-overlay">
        <div class="popup">
          <p>Error!</p>
          <p>Media cannot move to same location as it's from</p>
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
            background-color: var(--secondary-color);
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