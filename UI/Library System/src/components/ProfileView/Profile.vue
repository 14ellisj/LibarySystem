<script setup lang="ts">
import '../../styles/variables.css'
</script>

<template>
    <h2>Profile</h2>
    <button onclick="window.location.href = 'logIn';"> Orders </button> <br>
    <button onclick="window.location.href = 'logIn';"> Wishlist </button> <br>
    <button onclick="window.location.href = 'logIn';"> Return Media</button> <br>
    <button onclick="window.location.href = 'logIn';"> Settings </button> <br>
    <button onclick="window.location.href = 'logIn';"> Log Out </button>
</template>
  
<style scoped> 
    button {
        color: var(--secondary-color);
        padding: 1%;
        align-items: center;
    }
</style>