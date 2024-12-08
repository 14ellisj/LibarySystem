<script lang="ts">
import { defineComponent, ref } from 'vue'
import { useWishListStore } from '../../stores/wishlist'

export default defineComponent({
  name: 'SingleMediaView',
  setup() {
    const store = useWishListStore()

    return {
      store,
    }
  },
})
</script>

<template>
  <head> </head>
  <body>
    <div class="container">
      <h1>My Book Wish List</h1>
      <table id="wishlist-table">
        <thead>
          <tr>
            <th>Book Name</th>
            <th>Author</th>
            <th>Availability</th>
            <th>Type</th>
            <th>Remove</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="wishlist in store.Wishlist" :key="wishlist.id">
            <td>
              <RouterLink :to="`/item/${wishlist.id}`">{{ wishlist.media_id.name }}</RouterLink>
            </td>
            <td>
              {{ wishlist.media_id.author_id.first_name }}
              {{ wishlist.media_id.author_id.last_name }}
            </td>
            <td>{{ wishlist.media_id.avaliablity }}</td>
            <td>{{ wishlist.media_id.type_id.name }}</td>
            <td><button class="remove-btn">Remove</button></td>
          </tr>
        </tbody>
      </table>
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
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
  padding-top: 1%;
}

.container {
  text-align: center;
  background-color: white;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  width: 80%;
  max-width: 800px;
}

h1 {
  margin-bottom: 20px;
  color: #333;
}

table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
}

th,
td {
  padding: 12px;
  border: 1px solid #ddd;
  text-align: left;
}

th {
  background-color: var(--secondary-color);
  color: white;
}

td {
  background-color: #f9f9f9;
}

.remove-btn {
  background-color: #f44336;
  color: white;
  border: none;
  padding: 6px 12px;
  cursor: pointer;
  border-radius: 4px;
}

.remove-btn:hover {
  background-color: #d32f2f;
}
</style>
