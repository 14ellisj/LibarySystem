<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useMediaStore } from '../../stores/media';
import { Type } from '@/models/type';
import { Genre } from '@/models/genre';
import MediaService from '@/services/MediaService';
import { useUserStore } from '../../stores/profileInformation';
import toastr from 'toastr';
import axios from 'axios';
import type { LibraryFilter, MediaItemsFilter } from '@/models/filters';

export default defineComponent({
  name: 'SingleMediaView',
  setup() {
    const media = ref(useMediaStore().media);
    const userStore = useUserStore();
    const expandedRowId = ref<number | null>(null);
    const mediaStore = useMediaStore();
    const reserveQueue = ref<number>(0);
    const isPopupOpen = ref(false);

    // Email form data
const email = ref({
  to: "",
  subject: "Your next in line!",
  body: "Your reserved media is about to become available.\n" + 
        "Head to app to borrow the media now.\n" +
        "Thank you for using AML.",
});

    const message = ref("");

    const togglePopup = () => {
      isPopupOpen.value = !isPopupOpen.value;
    };

    const sendEmail = async () => {
      try {
        const response = await axios.post("http://localhost:5132/email/send", email.value);
        message.value = response.data.message;
        toastr.success("Email sent successfully.");
        togglePopup();
      } catch (error) {}
    };

    const toggleRowDetails = (id: number) => {
      expandedRowId.value = expandedRowId.value === id ? null : id;
    };

    const mediaService = new MediaService();

    const decodeBase64Image = (base64String: string): string => {
      let cleanBase64String = base64String;
      if (cleanBase64String.startsWith('data:image')) {
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

    const reserveMedia = async (media_id: number) => {
      const success = await mediaService.reserveMedia(media_id, userStore.user?.id);
      if (success) {
        reserveQueue.value += 1;
        toastr.success("Successfully reserved the media.");
        isPopupOpen.value = true; // Open popup
      } else {
        toastr.error("Failed to reserve the media.");
      }
    };

    return {
      media,
      expandedRowId,
      toggleRowDetails,
      decodeBase64Image,
      userStore,
      Type,
      Genre,
      mediaStore,
      mediaService,
      reserveQueue,
      isPopupOpen,
      togglePopup,
      reserveMedia,
      email,
      message,
      sendEmail,
    };
  },
  methods: {
    async borrowMedia(media_id: number) {
      const success = await this.mediaService.borrowMedia(media_id, this.userStore.user?.id);
      if (success) toastr.success("Successfully borrowed the media.");
      else toastr.error("Failed to borrow the media.");
    },
    async submitForLibraryData() {
      const filter: LibraryFilter = {};
      try {
        const data = await this.mediaService.getLibraryData(filter);
        console.log("Library Data retrieved successfully:", data);
      } catch (error) {
        console.error("Failed to get Library Data", error);
      }
    },
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
      <h2 v-if="media.length === 0">No media found...</h2>
      <table v-else>
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
          <template v-for="item in media" :key="item.id">
            <tr @click="toggleRowDetails(item.id)">
              <td>{{ item.name }}</td>
              <td>{{ item.author.first_name }} {{ item.author.last_name }}</td>
              <td>{{ Genre[item.genre] }}</td>
              <td>{{ item.is_available ? 'Available' : 'Not Available' }}</td>
              <td>{{ Type[item.type] }}</td>
            </tr>
            <tr v-if="expandedRowId === item.id">
              <td colspan="6">
                <div class="details-container">
                  <div class="media-image">
                    <img :src="decodeBase64Image(item.image)" alt="Media Image" />
                  </div>
                  <div class="media-info">
                    <h2>{{ item.name }}</h2>
                    <p><strong>Author: </strong> {{ item.author.first_name }} {{ item.author.last_name }}</p>
                    <p><strong>Length: </strong>{{ item.length }} pages</p>
                    <p><strong>Description: </strong> {{ item.description }}</p>
                    <p><strong>Rating: </strong>{{ item.rating }}/5</p>
                    <div class="actions">
                      <button :disabled="!item.is_available || item.is_borrowed_by_user" @click="borrowMedia(item.id)">
                        Borrow
                      </button>
                      <button :disabled="!item.is_available || item.is_reserved_by_me" @click="reserveMedia(item.id)">
                        Reserve
                      </button>
                    </div>
                  </div>
                </div>
              </td>
            </tr>
          </template>
        </tbody>
      </table>
      <button class="admin-button" @click="submitForLibraryData(); $router.push('/manage')">Manage Media</button>

      <!-- Popup -->
      <div v-if="isPopupOpen" class="overlay">
        <div class="popup">
          <h2>Send Reservation Confirmation Email</h2>
          <form @submit.prevent="sendEmail">
            <label for="to">Recipient Email:</label>
            <input v-model="email.to" id="to" type="email" placeholder="Enter recipient email" required />

            <button type="submit">Send Email</button>
          </form>
          <p v-if="message" class="response-message">{{ message }}</p>
          <button class="close-btn" @click="togglePopup">Close</button>
        </div>
      </div>
    </main>
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

th,
td {
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
.admin-button {
  position: absolute;
  top: 20px;
  right: 20px;
  padding: 10px 20px;
  background-color: var(--secondary-color);
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  margin-top: 80px;
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

form {
  display: flex;
  flex-direction: column;
}

input,
button {
  margin-bottom: 10px;
  padding: 8px;
}

.close-btn {
  margin-top: 10px;
  padding: 10px 20px;
  background: var(--secondary-color);
  color: white;
  border: none;
  cursor: pointer;
}
</style>
