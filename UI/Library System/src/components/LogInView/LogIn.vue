<script lang="ts">
import LogInItem from './LogInItem.vue'
import ProfileService from '@/services/ProfileService';
import type { ProfileFilter } from '@/models/filters';
import '../../styles/variables.css'
import { defineComponent } from 'vue'
import { useUserStore } from "@/stores/profileInformation";

export default defineComponent({
    name: "Log-In",
    components: {
            LogInItem,
        },
    data() {
    var email: string = "";
    var password: string = "";
    const profileService = new ProfileService();

    return {
        email,
        password,
        profileService
    }
  },
  methods: {
    async signIn() {
        const filter: ProfileFilter = {
            email: this.email
        }
        await this.profileService.filterData(filter, this.password);
            
        this.$router.push('/logInValidation');
        },
    async toRegister() {
        this.$router.push('/register');
    },
    async setNotLoggedIn() {
        useUserStore().setNotLoggedIn()
    }
    },
    beforeMount() {
        this.setNotLoggedIn();
    },
  }
);
</script>

<template>
    <LogInItem>
        <template #Heading>Log In</template>
    </LogInItem>

        <label for="logInEmail">Email:</label><br>
        <input type="text" id="logInEmail" name="logInEmail" v-model="email"><br>
        <label for="Password">Password:</label><br>
        <input type="password" id="Password" name="Password" v-model="password"><br>
        <button @click="signIn()"> Sign in </button><br>

        <button @click="toRegister()"> Go to registration </button><br>
</template>
  
<style scoped> 
a {
    margin-top: 2rem;
    position: relative;
    color: var(--secondary-color);
}

form {
    position: relative;
}

form label {
    color: var(--secondary-color);
}

</style>