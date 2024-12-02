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
        var isLoggedIn: "true" | undefined = undefined
        return {
            store,
            isLoggedIn
        };
    },
    methods: {
      push() {
        this.$router.push('/logIn');
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
          <button @click="push()"> Log In </button>
          <p> {{ store.loggedIn }}</p>
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
        padding-top: 15vh;
      }
</style>