<script setup lang="ts">
import '../../styles/variables.css'
</script>

<template>
    <h2>Profile</h2>
    <button onclick="window.location.href = '';"> Orders </button> <br>
    <button onclick="window.location.href = '';"> Wishlist </button> <br>
    <button onclick="window.location.href = 'Return';"> Return Media </button> <br>
    <button onclick="window.location.href = '';"> Settings </button> <br>
    <button onclick="window.location.href = 'logIn';"> Log Out </button>
</template>
  
<style scoped> 
    button {
        color: var(--secondary-color);
        padding: 1%;
        text-align: center;
        margin: 0.81rem;
    }
</style>