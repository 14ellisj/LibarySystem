<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useMediaStore } from '../../stores/media';
import { Genre }  from '../../models/genre';
import { Type } from '../../models/type';

export default defineComponent({
  name: 'SingleMediaView',
  data() {
    return {
        Genre,
        Type
    }
  },
  setup() {
    const store = useMediaStore();

    const expandedRowId = ref<number | null>(null);

    const toggleRowDetails = (id: number) => {
      expandedRowId.value = expandedRowId.value === id ? null : id;
    };

    const borrowMedia = (id: number) => {
      console.log(`Borrowing media with ID: ${id}`);
    };

    const addToWishlist = (id: number) => {
      console.log(`Adding media with ID: ${id} to wishlist`);
    };

    const reserveMedia = (id: number) => {
      console.log(`Reserving media with ID: ${id}`);
    };

    return {
      store,
      expandedRowId,
      toggleRowDetails,
      borrowMedia,
      addToWishlist,
      reserveMedia,
    };
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
                <td>{{ media.genre }}</td>
                <td>{{ media.description }}</td>
                <td>{{ media.type }}</td>
              </tr>
              <tr v-if="expandedRowId === media.id">
                <td colspan="6">
                  <div class="details-container">
                    <div class="media-image">
                      <img :src="media.name" alt="Media Image" />
                    </div>
                    <div class="media-info">
                      <h2>{{ media.name }}</h2>
                      <p><strong>Author:</strong> {{ media.author.first_name }} {{ media.author.last_name }}</p>
                      <p><strong>Description:</strong> {{ media.description }}</p>
                      <p><strong>Rating:</strong></p>
                      <ul>
                      </ul>
                      <div class="actions">
                        <button @click="borrowMedia(media.id)">Borrow</button>
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
  </style>
  