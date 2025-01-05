<script lang="ts">
import { defineComponent } from 'vue';
import MenuItem from './MenuItem.vue';

export default defineComponent({
    name: 'Header',
    components: {
            MenuItem,
        },
    data() {
        var hovering = false

        return {
            hovering
        }
    },
    methods: {
        async toHome() {  
            this.$router.push('/home');
        },
        async toProfile() {  
            this.$router.push('/profile');
        },
        async darkenImage() {
            this.hovering = true
        }
    }
})
</script>

<template>
    <div class="header-container header-container-in-place"></div>
    <div class="header-container">
        <div class="header-logo" @click= "toHome()">
            <img class="logo-img" src="@/images/LibraryLogoDone.png"><img>
        </div>
        <div class="header-navigation">
            <MenuItem Title="Home" Path="/home"></MenuItem>
            <MenuItem Title="News" Path="/news"></MenuItem>
        </div>
        <div class="header-user" @click= "toProfile()" @hover= "darkenImage()" v-if="hovering == false">
            <img class="user-img" src="@/images/profile.webp"><img>
        </div>
        <div class="header-user-dark" @click= "toProfile()" @hover= "darkenImage()" v-else>
            <img class="user-img-dark" src="@/images/profile.webp"><img>
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

    .user-img-dark {
        width: 5rem;
        filter: brightness(50%);
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

    a {
        text-decoration: none;
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

    .header-user-dark {
        flex: 0 1;
    }
</style>
