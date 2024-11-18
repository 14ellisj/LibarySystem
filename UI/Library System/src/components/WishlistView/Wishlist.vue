<script setup lang="ts">
</script>

<template>
<head>
</head>
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
                <tr>
                    <td>Harry Potter</td>
                    <td>J.K. Rowling</td>
                    <td>Available</td>
                    <td>Book</td>
                    <td><button class="remove-btn">Remove</button></td>
                </tr>
                <tr>
                    <td>The Hobbit</td>
                    <td>J.R.R. Tolkien</td>
                    <td>Out of Stock</td>
                    <td>CD</td>
                    <td><button class="remove-btn">Remove</button></td>
                </tr>
                <!-- Add more books here as needed -->
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
    background-color: #f0f0f0;
    display: flex;
    justify-content: center;
    align-items: center;
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

th, td {
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