<script lang="ts">
import '../../styles/variables.css'
import { defineComponent } from 'vue'
import { useUserStore } from '../../stores/profileInformation';

export default defineComponent({
    name: 'logInValidation',
    setup() {
        const store = useUserStore();
        return {
            store,
        };
    },
    methods: {
        async push() {
            this.$router.push('/home');
        },
        async setLoggedIn() {
            await this.store.setLoggedIn()
        }
    }
});
</script>

<template>
    <main v-if="store.user.id">
        <h2>
            Welcome back {{ store.user.first_name }} {{ store.user.last_name }}
        </h2>
        <button @click="push(); setLoggedIn();">
            Go searching!
        </button>
    </main>
    <main v-else>
        <p>Your email or password was incorrect, please try again</p>
        <a href="logIn"> Go back </a>
    </main>
</template>

<style scoped>
    main {
        text-align: center;
    }

    button {
        padding: 2vh;
    }
</style>
