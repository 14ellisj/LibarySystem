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
    <body>
        <main v-if="store.user[0]['Password'] == store.password" >
            <h2>
                Welcome back {{ store.user[0]['firstName'] }} {{ store.user[0]['lastName'] }}
            </h2>
            <button @click="push(); setLoggedIn();">
                Go searching!
            </button>
        </main>
        <main v-else>
            <p>Your email or password was incorrect, please try again</p>
            <a href="logIn">Go back</a>
        </main>
    </body>
</template>

<style scoped>
    main {
        text-align: center;
    }

    button {
        padding: 2vh;
    }
</style>