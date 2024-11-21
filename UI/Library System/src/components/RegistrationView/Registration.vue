<script setup lang="ts">
import RegistrationItem from './RegistrationItem.vue'
import '../../styles/variables.css'
import ProfileService from '@/services/ProfileService';
import { useUserStore } from '@/stores/profileInformation';
import { ref } from 'vue'
</script>

<template>
    <RegistrationItem>
        <template #Heading>Register</template>
    </RegistrationItem>

    <form action="registration-check">
        <label for="registerEmail">Email:</label><br>
        <input type="text" id="registerEmail" name="registerEmail"><br>
        <label for="fName">First Name:</label><br>
        <input type="text" id="fName" name="fName"><br>
        <label for="lName">Last Name:</label><br>
        <input type="text" id="lName" name="lName"><br>
        <label for="DOB">Date Of Birth:</label><br>
        <input type="text" id="DOB" name="DOB"><br>
        <label for="Password">Password:</label><br>
        <input type="text" id="Password" name="Password"><br>
        <label for="ConfirmPassword">Confirm Password:</label><br>
        <input type="text" id="ConfirmPassword" name="ConfirmPassword"><br>
        <input type="submit" value="Confirm details">
    </form>

    <a href="login"> Log In </a>
</template>
<<<<<<< HEAD:UI/Library System/src/components/Registration.vue
  
<style> 
=======

<style scoped> 
>>>>>>> Joe-Drop:UI/Library System/src/components/RegistrationView/Registration.vue
a {
    margin: auto;
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