<script setup lang="ts">
import { defineComponent } from 'vue';
import MenuItem from './MenuItem.vue';

defineComponent({
    name: 'Header',
    data() {

    },
    methods: {

    }
})
</script>

<template>
    <div class="header-container header-container-in-place"></div>
    <div class="header-container">
        <div class="header-logo">
            <a href="home"><img class="logo-img" src="@/images/LibraryLogoDone.png" /></a>
        </div>
        <div class="header-navigation">
            <MenuItem Title="Home" Path="/home"></MenuItem>
            <MenuItem Title="About" Path="/about"></MenuItem>
            <MenuItem Title="News" Path="/news"></MenuItem>
        </div>
        <div class="header-user">
            <a href="Profile"><img class="user-img" src="@/images/profile.webp" /></a>
        </div>
    </div>
</template>
  
<style scoped> 

    .logo-img {
        width: 5rem;
    }

    .user-img {
        width: 5rem;
    }

    .header-container {
        display: flex;
        flex-direction: row;
        height: 5rem;
        width: 100%;

        background-color: var(--tertiary-color);
        position: fixed;
        top: 0;
        z-index: 4;
    }

    .header-container-in-place {
        position: relative;
        visibility: hidden;
    }

    .header-logo {
        flex: 0 1;
    }

    .header-navigation {
        flex: 1 1;
        padding: 0.5rem;
        display: flex;
        align-items: end;
        justify-content: center;
        flex-direction: row;
    }

    .header-user {
        flex: 0 1;

    }
</style>