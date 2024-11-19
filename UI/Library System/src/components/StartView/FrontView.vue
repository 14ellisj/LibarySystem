<script setup lang="ts">
import { defineComponent, ref } from 'vue'
import { type Media } from '../../models/media';
import MediaService from '@/services/MediaService'


</script>

<template>
<head>
    <title>Single Media View</title>
</head>
<body>
    <header>
        <div class="logo">
            <a href="home"><img src="../../images/LibraryLogoDone.png" alt="Logo"></a>
        </div>
        <div class="logo">
            <a href="Profile"><img src="../../images/profile.webp" alt="Profile"></a>
        </div>
    </header>

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
                    <td>Available</td>
                    <td>Book</td>
                </tr>
                <tr>
                    <td>1984</td>
                    <td>George Orwell</td>
                    <td>Not Available</td>
                    <td>CD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
                </tr>
                <tr>
                    <td>To Kill a Mockingbird</td>
                    <td>Harper Lee</td>
                    <td>Available</td>
                    <td>DVD</td>
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
</style>