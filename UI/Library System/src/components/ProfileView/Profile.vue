<script lang="ts">
import { defineComponent } from 'vue';
import '../../styles/variables.css'
import type { MediaFilter } from '@/models/filters';
import { useUserStore } from '@/stores/profileInformation';
import MediaService from '@/services/MediaService';

export default defineComponent({
    name: 'Profile',
    data() {
        var hovering = false

        return {
            hovering
        }
    },
    setup() {
        const store = useUserStore();
        var userID = store.user[0]['id']
        return {
            store,
            userID
        };
    },
    methods: {
        async toOrders() {  
            this.$router.push('');
        },
        async toWishlist() {  
            this.$router.push('/Wishlist');
        },
        async toReturn() {  
            const mediaService = new MediaService();
            const returnMedia = await mediaService.getBorrowedMedia(this.userID);
            this.$router.push('/Return');
        },
        async toSettings() {  
            this.$router.push('');
        },
        async toLogIn() {  
            this.$router.push('/logIn');
        },
    }
})
</script>

<template>
    <h2>Profile</h2>
    <button @click="toOrders()"> Orders </button> <br>
    <button @click="toWishlist()"> Wishlist </button> <br>
    <button @click="toReturn()"> Return Media </button> <br>
    <button @click="toSettings()"> Settings </button> <br>
    <button @click="toLogIn()"> Log Out </button>
</template>
  
<style scoped> 
    button {
        color: var(--secondary-color);
        padding: 1%;
        text-align: center;
        margin: 0.81rem;
    }
</style>