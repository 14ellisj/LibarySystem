<script lang="ts">
import { defineComponent, ref, watch } from 'vue';
import { useMediaStore } from '../../stores/media';
import MediaService from '@/services/MediaService';
import type { mediaItemsFilter } from '@/models/filters';

export default defineComponent({
  name: 'move Form',
  setup() {
    const mediaStore = useMediaStore();
    const media = ref(mediaStore.media);
    const mediaItems = ref(mediaStore.mediaItems);
    const showPopup = ref(false);
    const showError = ref(false);
    const selectedMedia = ref<string | null>(null);

    const handleSubmit = async (event: Event) => {
      event.preventDefault();
      const formData = new FormData(event.target as HTMLFormElement);

      const branchFrom = formData.get('branchFrom');
      const branchDestination = formData.get('branchDestination');

      if (branchFrom === branchDestination) {
        showError.value = true; // Display error message
        setTimeout(() => {
          showError.value = false; // Hide error message after 3 seconds
        }, 3000);
        return; // Prevent submission
      }

      const newMediaMove = {
        media: formData.get('media'),
        branchFrom,
        branchDestination,
      };
      console.log('Form Data Submitted:', newMediaMove);
      showPopup.value = true;

      setTimeout(() => {
        showPopup.value = false;
      }, 3000); // Popup disappears after 3 seconds
    };

    // Watch for changes in the selected media and call `submitForMediaItems`
    watch(selectedMedia, (newValue) => {
      if (newValue) {
        const selectedMediaItem = media.value.find((item) => item.name === newValue);
        if (selectedMediaItem) {
          submitForMediaItems(selectedMediaItem.id);
        }
      }
    });

    // Method to fetch media items for the selected media
    const submitForMediaItems = async (mediaId: number) => {
      const mediaService = new MediaService();
      const filter: mediaItemsFilter = {
        media_id: mediaId,
      };
      try {
        const data = await mediaService.getMediaItems(filter);
        mediaItems.value = data; // Update mediaItems with fetched data
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
    };
  },
});
</script>




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