<script lang="ts">
import '../styles/variables.css'
import { defineComponent } from 'vue'
import { useUserStore } from '../stores/profileInformation'
import Returned from '../components/ReturnedView/Returned.vue'

export default defineComponent({
    name: 'returnedView',
    components: {
      Returned
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
    <main>
      <div class="returnedMediaContainer">
        <div class="returnedMedia">
          <Returned />
        </div>
      </div>
    </main>
  </body>
</template>

<style scoped> 
    .returnedMediaContainer {
      margin: auto;
    }

    .returnedMedia{
        text-align: center;
        padding-top: 10vh;
      }
</style>