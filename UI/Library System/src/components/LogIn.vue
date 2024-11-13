<script setup lang="ts">
import LogInItem from './LogInItem.vue'
import '../styles/variables.css'
</script>

<template>
    <LogInItem>
        <template #Heading>Log In</template>
    </LogInItem>

    <form action="/">
        <label for="logInEmail">Email:</label><br>
        <input type="text" id="logInEmail" name="logInEmail"><br>
        <label for="Password">Password:</label><br>
        <input type="text" id="Password" name="Password"><br>
        <input type="submit" value="Log In">
    </form>

    <a href="register"> Register </a>
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