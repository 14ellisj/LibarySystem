<script setup lang="ts">
import ProfileOptions from '../components/ProfileView/Profile.vue'
</script>

<template>
  <body>
    <main>
      <div class="profileContainer">
        <div class="profile">
          <ProfileOptions />
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
        display: flex;
        align-items: center;
        justify-content: center;
      }
</style>