<script lang="ts">
import '../styles/variables.css'
import { defineComponent } from 'vue'
import { useUserStore } from '../stores/profileInformation'
import ProfileOptions from '../components/ProfileView/Profile.vue'

export default defineComponent({
    name: 'profileView',
    components: {
      ProfileOptions
    },
    setup() {
        const store = useUserStore();
        return {
            store,
        };
    },
    methods: {
      pushLogIn() {
        this.$router.push('/logIn');
      },
      pushRegister() {
        this.$router.push('/register');
      }
    }
});
</script>

<template>
  <body>
    <main v-if="store.loggedIn == 'true'">
      <div class="profileContainer">
        <div class="profile">
          <ProfileOptions />
        </div>
      </div>
    </main>

    <main v-else>
      <div class="profileContainer">
        <div class="profile">
          <button @click="pushLogIn()"> Log In </button> <br>
          <button @click="pushRegister()"> Register </button>
        </div>
      </div>
    </main>
  </body>
</template>

<style scoped>
.profileContainer {
  margin: auto;
}

    .profile{
        text-align: center;
        padding-top: 10vh;
      }
</style>
