<script lang="ts">
import '../../styles/variables.css'
import { defineComponent, ref } from 'vue'
import { useUserStore } from '../../stores/profileInformation';

export default defineComponent({
    name: 'SingleMediaView',
    setup() {
        const userStore = useUserStore();

        if (userStore != null){
            console.log("the user store has something in it")
        }

        return {
            userStore,
        };
    },
});
</script>

<template>
    <p v-for="user in userStore.user" :key="user.id"> {{ user.first_name }} </p>
</template>