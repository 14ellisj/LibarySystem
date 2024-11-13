<script setup lang="ts">
import RegistrationItem from './RegistrationItem.vue'
</script>

<template>
    <RegistrationItem>
    <template #Heading>Register</template>
    </RegistrationItem>

    <form>
        <label for="Email">Email:</label><br>
        <input type="text" id="Email" name="Email"><br>
        <label for="FirstName">First Name:</label><br>
        <input type="text" id="FirstName" name="FirstName"><br>
        <label for="LastName">Last Name:</label><br>
        <input type="text" id="LastName" name="LastName"><br>
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
  
<style scoped> 
a {
    display: flex;
    margin: auto;
    position: relative;
    color: pink;
}

form {
    position: relative;
}

form label {
    color: pink;
}

</style>