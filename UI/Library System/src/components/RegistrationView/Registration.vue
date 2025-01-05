<script lang="ts">
import RegistrationItem from './RegistrationItem.vue'
import '../../styles/variables.css'
import ProfileService from '@/services/ProfileService';
import { useUserStore } from '@/stores/profileInformation';
import { defineComponent } from 'vue'
import toastr from 'toastr';
import type { ProfileFilter } from '@/models/filters';

export default defineComponent({
    name: "Register",
    setup() {
        const store = useUserStore();
        return {
            store
        }
    },
    components: {
            RegistrationItem,
        },
    data() {
    var email: string = "";
    var firstName: string = "";
    var lastName: string = "";
    var password: string = "";
    var confirmPassword: string = "";
    const profileService = new ProfileService();

    return {
        email,
        firstName,
        lastName,
        password,
        confirmPassword,
        profileService
    }
  },
  methods: {
    async Register() {         
        if (this.email != "" && this.firstName != "" && this.lastName != "" && this.password != "") {
            if (this.password == this.confirmPassword) {
                const filter: ProfileFilter = {
                    email: this.email
                } 
                await this.profileService.checkEmail(filter);
                const result = this.store.user;
                if (result?.length == 0) {
                    await this.profileService.createProfile(this.email, this.firstName, this.lastName, this.password);
            
                    this.$router.push('/logIn');
                }
                else{
                    toastr.error("That email is already in use.")
                }
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