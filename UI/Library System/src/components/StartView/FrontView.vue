<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useMediaStore } from '../../stores/media';
import { Type } from '@/models/type';
import { Genre } from '@/models/genre';
import MediaService from '@/services/MediaService';
import toastr from 'toastr';

export default defineComponent({
  name: 'SingleMediaView',
  setup() {
    const store = useMediaStore();
    const expandedRowId = ref<number | null>(null);
    const isPopupVisible = ref(false); 
    const popupMessage = ref('');

    const toggleRowDetails = (id: number) => {
      expandedRowId.value = expandedRowId.value === id ? null : id;
    };

    const showPopup = (message: string) => {
      popupMessage.value = message;
      isPopupVisible.value = true;
    };

    const closePopup = () => {
      isPopupVisible.value = false;
    };

    const addToWishlist = (id: number) => {
      console.log(`Adding with ID: ${id} to wishlist`);
      showPopup('Media has been added to your wishlist!');
    };

    const reserveMedia = (id: number) => {
      console.log(`Reserving media with ID: ${id}`);
      showPopup('Media has been reserved!');
    };

    const decodeBase64Image = (base64String: string): string => {
      let cleanBase64String = base64String;
      if (cleanBase64String.startsWith("data:image")) {
        cleanBase64String = cleanBase64String.split(',')[1];
      }
      const byteCharacters = atob(cleanBase64String);
      const byteArrays = [];

      for (let offset = 0; offset < byteCharacters.length; offset++) {
        const byte = byteCharacters.charCodeAt(offset);
        byteArrays.push(byte);
      }
      const blob = new Blob([new Uint8Array(byteArrays)], { type: 'image/jpeg' }); 
      return URL.createObjectURL(blob);
    };

    return {
      store,
      expandedRowId,
      toggleRowDetails,
      addToWishlist,
      reserveMedia,
      decodeBase64Image,
      isPopupVisible,
      popupMessage,
      closePopup,
      Type,
      Genre,
    };
  },
  methods: {
    async borrowMedia(id: number) {
      const mediaService = new MediaService();
      const success = await mediaService.borrowMedia(id, 1);
      console.log(success);
      if (success)
        toastr.success("Successfully borrowed the media.");

      else
        toastr.error("Failed to borrow the media.");
    }
  },
});
</script>

<template>
  <head>
    <title>Single Media View</title>
  </head>
  <body>
    <main>
      <h1>Library</h1>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Author</th>
            <th>Genre</th>
            <th>Availability</th>
            <th>Type</th>
          </tr>
        </thead>
        <tbody>
          <template v-for="media in store.media" :key="media.id">
            <tr @click="toggleRowDetails(media.id)">
              <td>{{ media.name }}</td>
              <td>{{ media.author.first_name }} {{ media.author.last_name }}</td>
              <td>{{ Genre[media.genre] }}</td>
              <td>{{ media.is_available ? 'Available' : 'Not Available' }}</td>
              <td>{{ Type[media.type] }}</td>
            </tr>
            <tr v-if="expandedRowId === media.id">
              <td colspan="6">
                <div class="details-container">
                  <div class="media-image">
                    <img :src="decodeBase64Image(media.image)" alt="Media Image" />
                  </div>
                  <div class="media-info">
                    <h2>{{ media.name }}</h2>
                    <p><strong>Author: </strong> {{ media.author.first_name }} {{ media.author.last_name }}</p>
                    <p><strong>Length: </strong>{{ media.length }} pages</p>
                    <p><strong>Description: </strong> {{ media.description }}</p>
                    <p><strong>Rating: </strong>{{ media.rating }}/5</p>
                    <ul>
                    </ul>
                    <div class="actions">
                      <button v-if="media.is_available" @click="borrowMedia(media.id)">Borrow</button>
                      <p v-else>Sorry, not available right now</p>

                      <button @click="addToWishlist(media.id)">Add to Wishlist</button>
                      <button @click="reserveMedia(media.id)">Reserve</button>
                    </div>
                  </div>
                </div>
              </td>
            </tr>
          </template>
        </tbody>
      </table>
    </main>

    <div v-if="isPopupVisible" class="overlay" @click="closePopup"></div>
    <div v-if="isPopupVisible" class="popup">
      <p>{{ popupMessage }}</p>
      <button @click="closePopup" class="close-btn">Close</button>
    </div>
  </body>
</template>

<style scoped>
  * {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
  }

  body {
    font-family: Arial, sans-serif;
    background-color: var(--background-color);
    color: #333;
  }

  main {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 50px 20px;
  }

  h1 {
    font-size: 2rem;
    margin-bottom: 20px;
  }

  table {
    width: 80%;
    border-collapse: collapse;
    background-color: white;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  }

  th, td {
    padding: 12px;
    text-align: left;
    border-bottom: 1px solid #ddd;
  }

  th {
    background-color: var(--secondary-color);
    color: white;
  }

  tbody tr:hover {
    background-color: #f9f9f9;
  }

  .details-container {
    display: flex;
    gap: 20px;
    padding: 20px;
    background-color: #f4f4f4;
    border: 1px solid #ddd;
    border-radius: 8px;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
  }

  .media-image img {
    max-width: 150px;
    border-radius: 8px;
  }

  .media-info {
    flex: 1;
  }

  .media-info h2 {
    margin-bottom: 10px;
  }

  .media-info p {
    margin: 5px 0;
  }

  .media-info ul {
    list-style: disc;
    margin-left: 20px;
  }

  .actions {
    margin-top: 20px;
  }

  .actions button {
    padding: 10px 15px;
    margin-right: 10px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
  }

  .actions button:hover {
    background-color: #ddd;
  }

  .overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
  z-index: 999;
}

/* Popup styling */
.popup {
  position: fixed;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background: white;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
  z-index: 1000;
  text-align: center;
  width: 80%;
  max-width: 400px;
}

.close-btn {
  margin-top: 20px;
  padding: 10px 20px;
  background: var(--tertiary-color);
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.close-btn:hover {
  background: var(--secondary-color);
}
</style>
