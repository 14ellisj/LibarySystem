<script lang="ts">
import { defineComponent, ref, watch } from 'vue';
import { useMediaStore } from '../../stores/media';

export default defineComponent({
  name: 'Add Media',
  setup() {
    const mediaStore = useMediaStore();
    const media = ref(mediaStore.media);

    return {
      mediaStore,
      media,
    };
  },
});
</script>

<template>
    <div class="container">
      <h1>Your Reservation</h1>
      <table class="reservation-table">
        <thead>
          <tr>
            <th>Media Name</th>
            <th>Author</th>
            <th>Availability</th>
            <th>Rervation Queue</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in media" :key="item.id">
            <td>{{ item.name }}</td>
            <td>{{ item.author }}</td>
            <td>{{ item.is_available ? 'Available' : 'Not Available' }}</td>
            <td>{{  }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </template>


<style scoped>
       /* Center container */
.container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
  background-color: var(--background-color);
  font-family: Arial, sans-serif;
}

/* Table styling */
.reservation-table {
  width: 60%;
  border-collapse: collapse;
  box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
  background-color: white;
}

.reservation-table th, .reservation-table td {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 12px;
}

.reservation-table th {
  background-color: var(--secondary-color);
  color: white;
  font-size: 14px;
}

.reservation-table tr:nth-child(even) {
  background-color: #f2f2f2;
}

.available {
  color: green;
  font-weight: bold;
}

.unavailable {
  color: red;
  font-weight: bold;
}

h1 {
  color: #333333;
  margin-bottom: 20px;
}
</style>