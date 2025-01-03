<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useMediaStore } from '../../stores/media';

export default defineComponent({
  name: 'moveRequests',
  setup() {
    const mediaMoves = ref(useMediaStore().mediaMoves);

    return {
      mediaMoves,
    };
  },
});
</script>

<template>
  <body>
    <main>
      <h1>Move Requests</h1>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>From</th>
            <th>Move to</th>
          </tr>
        </thead>
        <tbody>
          <template v-for="item in mediaMoves" :key="item.id">
            <tr>
              <td>{{ item.media }}</td>
              <td>{{ item.branchFrom }}</td>
              <td>{{ item.branchDestination }}</td>
            </tr>
          </template>
        </tbody>
      </table>
      <div class="back-button-container">
        <button @click="$router.push('/manage');">Back</button>
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

.details-container {
  display: flex;
  gap: 20px;
  padding: 20px;
  background-color: #f4f4f4;
  border: 1px solid #ddd;
  border-radius: 8px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
}

.back-button-container {
  margin-top: 20px;
  text-align: center;
}

button {
  padding: 10px 20px;
  background-color: var(--secondary-color);
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 1rem;
}

button:hover {
  background-color: var(--primary-color-hover);
}
</style>

