<script lang="ts">
import RegistrationItem from './RegistrationItem.vue'
import '../../styles/variables.css'
import ProfileService from '@/services/ProfileService';
import { useUserStore } from '@/stores/profileInformation';
import { defineComponent } from 'vue'
import toastr from 'toastr';

export default defineComponent({
    name: "Register",
    components: {
            RegistrationItem,
        },
    data() {
    var email: string = "";
    var firstName: string = "";
    var lastName: string = "";
    var DOB: string = "";
    var password: string = "";
    var confirmPassword: string = "";
    const profileService = new ProfileService();

    return {
        email,
        firstName,
        lastName,
        DOB,
        password,
        confirmPassword,
        profileService
    }
  },
  methods: {
    async Register() {         
        if (this.email != "" && this.firstName != "" && this.lastName != "" && this.password != "") {
            if (this.password == this.confirmPassword) {
            await this.profileService.createProfile(this.email, this.firstName, this.lastName, this.password);
            

            this.$router.push('/logIn');
            }
            else {
                toastr.error("The passwords do not match");
            }
        }
        else {
            toastr.error("You must fill in all of the fields");
        }
    },
    async ToLogin() {
        this.$router.push('/logIn');
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
    <RegistrationItem>
        <template #Heading>Register</template>
    </RegistrationItem>

    <label for="registerEmail">Email:</label><br>
    <input type="text" id="registerEmail" name="registerEmail" v-model="email"><br>
    <label for="fName">First Name:</label><br>
    <input type="text" id="fName" name="fName" v-model="firstName"><br>
    <label for="lName">Last Name:</label><br>
    <input type="text" id="lName" name="lName" v-model="lastName"><br>
    <label for="DOB">Date Of Birth:</label><br>
    <input type="date" id="DOB" name="DOB" v-model="DOB"><br>
    <label for="Password">Password:</label><br>
    <input type="text" id="Password" name="Password" v-model="password"><br>
    <label for="ConfirmPassword">Confirm Password:</label><br>
    <input type="text" id="ConfirmPassword" name="ConfirmPassword" v-model="confirmPassword"><br>

    <button @click="Register()"> Confirm Details </button><br>

    <button @click="ToLogin()"> Go to Log In </button><br>
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