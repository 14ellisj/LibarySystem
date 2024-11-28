<script lang="ts">
import { defineComponent, ref } from 'vue'
import { useMediaStore } from '../../stores/media';
 
export default defineComponent({
  name: 'SingleMediaView',
  setup() {
    const store = useMediaStore();

    return {
      store,
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
            <tr v-for="media in store.media" :key="media.id">
              <td><a :href="`/item/${media.id}`">{{ media.name }}</a></td>
              <td>{{ media.author.first_name }} {{ media.author.last_name }}</td>
              <td>{{ media.genre }}</td>
              <td>{{ media.is_available }}</td>
              <td>{{ media.type }}</td>
            </tr>
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
    background-color: var( --background-color);
    color: #333;
}

header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 20px;
    color: white;
}

.logo img {
    height: 100px;
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

footer {
    text-align: center;
    padding: 20px;
    background-color: #333;
    color: white;
    position: fixed;
    width: 100%;
    bottom: 0;
}
</style>