<script setup lang="ts">
import RegistrationItem from './RegistrationItem.vue'
import '../../styles/variables.css'
import ProfileService from '@/services/ProfileService'
import { useUserStore } from '@/stores/profileInformation'
</script>

<template>
  <RegistrationItem>
    <template #Heading>Register</template>
  </RegistrationItem>

  <form action="registration-check">
    <label for="registerEmail">Email:</label><br />
    <input type="text" id="registerEmail" name="registerEmail" /><br />
    <label for="fName">First Name:</label><br />
    <input type="text" id="fName" name="fName" /><br />
    <label for="lName">Last Name:</label><br />
    <input type="text" id="lName" name="lName" /><br />
    <label for="DOB">Date Of Birth:</label><br />
    <input type="text" id="DOB" name="DOB" /><br />
    <label for="Password">Password:</label><br />
    <input type="text" id="Password" name="Password" /><br />
    <label for="ConfirmPassword">Confirm Password:</label><br />
    <input type="text" id="ConfirmPassword" name="ConfirmPassword" /><br />
    <input type="submit" value="Confirm details" />
  </form>

  <RouterLink to="/login"> Log In </RouterLink>
</template>

<style scoped>
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
