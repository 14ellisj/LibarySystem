<script lang="ts">
import LogInItem from './LogInItem.vue'
import ProfileService from '@/services/ProfileService';
import type { ProfileFilter } from '@/models/filters';
import '../../styles/variables.css'
import { defineComponent } from 'vue'

export default defineComponent({
    name: "Log-In",
    data() {
    var query: string = "";

    return {
        query
    }
  },
  methods: {
    async submit() {
        const profileService = new ProfileService();
        const filter: ProfileFilter = {
            email: this.query
        }
        await profileService.filterData(filter);
        }
    }
  }
);
</script>

<template>
    <LogInItem>
        <template #Heading>Log In</template>
    </LogInItem>

    <form action="/logInValidation">
        <label for="logInEmail">Email:</label><br>
        <input type="text" id="logInEmail" name="logInEmail"><br>
        <label for="Password">Password:</label><br>
        <input type="text" id="Password" name="Password"><br>
        <button @click="submit()"> Sign in </button>
    </form>

    <a href="register"> Register </a>
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