<script lang="ts">
import MediaService from '@/services/MediaService'
import { defineComponent } from 'vue'
import { type Media } from '../../models/media';
import { useMediaStore } from '@/stores/media';

export default defineComponent({
    name: 'Front-View',
    data() {
        const mS = useMediaStore() 
        console.log("ajkshgd");
        var query: string = "";
        var author: string = "Author";

        return {
            author,
            mS
        }
    },
    methods: {
        change() {
            this.author = 'Changed';
        }
    }
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
                    <th>Book Name</th> 
                    <th>Author</th>
                    <th>Availability</th>
                    <th>Type</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><a href="Item">IT</a></td> 
                    <td>Stephen King</td>
                    <td>{{ mS.media[0].name }}</td> 
                    <button :click="change()">Change</button>
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
    background-color: #f4f4f4;
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

.remove-btn {
    background-color: #f44336;
    color: white;
    border: none;
    padding: 6px 12px;
    cursor: pointer;
    border-radius: 4px;
}
</style>