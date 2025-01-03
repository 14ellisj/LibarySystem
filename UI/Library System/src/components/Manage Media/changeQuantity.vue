<script lang="ts">
  import { defineComponent, ref } from 'vue';
  import { useMediaStore } from '../../stores/media';
  
  export default defineComponent({
    name: 'SingleMediaView',
    setup() {
      const mediaStore = useMediaStore();
      const media = ref(mediaStore.media);
      const selectedMediaId = ref('');
  
      const updateSelectedMediaId = (event: Event) => {
        const selectElement = event.target as HTMLSelectElement;
        const selectedOption = selectElement.options[selectElement.selectedIndex];
        selectedMediaId.value = selectedOption.getAttribute('data-id') || '';
      };
  
      const handleSubmit = async (event: Event) => {
        event.preventDefault();
        const formData = new FormData(event.target as HTMLFormElement);
  
        const quantityChange = {
          mediaName: formData.get('media-name'),
          mediaId: formData.get('media-id'),
          mediaQuantity: formData.get('media-quantity'),
        };
        console.log('Form Data Submitted:', quantityChange);
      };
  
      return {
        mediaStore,
        media,
        selectedMediaId,
        updateSelectedMediaId,
        handleSubmit,
      };
    },
  });
  </script>
<template>
    <div class="form-wrapper">
      <button class="back-button" @click="$router.push('/add')">Back</button>
      <div class="form-container">
        <h1>Media Input Form</h1>
        <form @submit="handleSubmit"> 
          <div class="form-group">
            <label for="media-name">Media:</label>
            <select name="media-name" id="media-name" required @change="updateSelectedMediaId">
              <option value="">Select Media</option>
              <option v-for="item in media" :key="item.id" :value="item.name" :data-id="item.id">
                {{ item.name }}
              </option>
            </select>
            <input type="hidden" name="media-id" id="media-id" :value="selectedMediaId" />
          </div>
          <div class="form-group">
            <label for="media-quantity">New Quantity:</label>
            <input type="number" id="media-quantity" name="media-quantity" placeholder="Enter new quantity" required />
          </div>
          <div class="form-group">
            <button type="submit" class="submit-button">Submit</button>
          </div>
        </form>
      </div>
    </div>
  </template>
  
  <style scoped>
  .form-wrapper {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 20px;
    background-color: var(--background-colour);
    min-height: 100vh;
    font-family: Arial, sans-serif;
  }
  
  .back-button {
    background-color: var(--secondary-color);
    color: white;
    border: none;
    padding: 10px 15px;
    border-radius: 5px;
    cursor: pointer;
    margin-bottom: 20px;
    font-size: 16px;
  }
  
  .form-container {
    background-color: white;
    padding: 20px;
    border-radius: 8px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    width: 100%;
    max-width: 500px;
  }
  
  h1 {
    margin-bottom: 20px;
    font-size: 24px;
    text-align: center;
    color: #333;
  }
  
  .form-group {
    margin-bottom: 15px;
  }
  
  label {
    display: block;
    margin-bottom: 5px;
    font-weight: bold;
    color: #555;
  }
  
  select, input {
    width: 100%;
    padding: 10px;
    font-size: 16px;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-sizing: border-box;
  }
  
  select:focus, input:focus {
    border-color: var(--tertiary-color);
    outline: none;
    box-shadow: 0 0 3px rgba(0, 0, 0, 0.5);
  }
  
  .submit-button {
    background-color: var(--secondary-color);
    color: white;
    border: none;
    padding: 10px 15px;
    border-radius: 5px;
    cursor: pointer;
    font-size: 16px;
    width: 100%;
  }
  
  .submit-button:hover {
    background-color: var(--tertiary-color);
  }
  </style>
  