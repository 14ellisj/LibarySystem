<script lang="ts">
import { defineComponent, ref, computed } from 'vue';
import { useMediaStore } from '../../stores/media';
import { useMediaItemStore } from '@/stores/mediaItem';

export default defineComponent({
  name: 'Add Media',
  setup() {
    const mediaStore = useMediaStore();
    const media = ref(useMediaStore().media);
    const mediaItemStore = useMediaItemStore();
    const mediaItem = ref(useMediaItemStore().mediaItem);
    const showPopup = ref(false);

    const handleSubmit = async (event: Event) => {
      event.preventDefault();
      const formData = new FormData(event.target as HTMLFormElement);

      const newMediaMove = {
        media: formData.get('media'),
        branch: formData.get('branch'),
      };
      console.log('Form Data Submitted:', newMediaMove);
      showPopup.value = true;

      setTimeout(() => {
        showPopup.value = false;
      }, 3000); // Popup disappears after 3 seconds
    };

    return {
      mediaStore,
      media,
      mediaItemStore,
      mediaItem,
      handleSubmit,
      showPopup,
    };
  },
});
</script>

<template>
  <body>
    <div class="form-container">
      <h2>Select Media and Branch</h2>
      <form @submit="handleSubmit" action="/move-media" method="POST">
        <label for="media">Choose Media to Move:</label>
        <select id="media" name="media" required>
          <option value="">-- Select Media --</option>
          <option v-for="item in media" :key="item.id" :value="item.id">
            {{ item.name }}
          </option>
          <option>Test Media</option>
        </select>

        <label for="branch">Choose Branch:</label>
        <select id="branch" name="branch" required>
          <option value="">-- Select Branch --</option>
          <option v-for="item in mediaItem" :key="item.id" :value="item.library_id">
            {{ item.library_id }}
          </option>
          <option value="test-branch">Test Branch</option>
        </select>

        <button type="submit">Move Media</button>
        <button type="button" @click="$router.push('/manage')" style="margin-top: 10px; background-color: #6c757d;">
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