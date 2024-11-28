<script lang="ts">
import '../../styles/variables.css'
import { defineComponent, ref } from 'vue'
import { useUserStore } from '../../stores/profileInformation';

export default defineComponent({
    name: 'SingleMediaView',
    setup() {
        const userStore = useUserStore();

        if (userStore != null){
            console.log(userStore)
        }

        return {
            userStore,
        };
    },
});
</script>

<template>
    <p v-for="user in userStore.user"> {{ user.firstName }} </p>
</template>