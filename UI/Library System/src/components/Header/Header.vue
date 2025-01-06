<script lang="ts">
import { defineComponent, ref } from 'vue'
import MenuItem from './MenuItem.vue'
import { useUserStore } from '@/stores/profileInformation';

export default defineComponent({
  name: 'Header',
  data() {
    const user = ref(useUserStore().user);
    const userRoute = user.value?.id ? "/profile" : "/login"
    return {
      userRoute
    }
  },
  components: {
    MenuItem
  },
  methods: {},
})
</script>

<template>
  <div class="header-container header-container-in-place"></div>
  <div class="header-container">
    <div class="header-logo">
      <RouterLink to="/home"><img class="logo-img" src="@/images/LibraryLogoDone.png" /></RouterLink>
    </div>
    <div class="header-navigation">
      <MenuItem Title="Home" Path="/home"></MenuItem>
      <MenuItem Title="News" Path="/news"></MenuItem>
    </div>
    <div class="header-user">
      <RouterLink :to="userRoute"><img class="user-img" src="@/images/profile.webp" /></RouterLink>
    </div>
  </div>
</template>

<style scoped>
.logo-img {
  width: 5rem;
}

.user-img {
  width: 5rem;
}

.header-container {
  display: flex;
  flex-direction: row;
  height: 5rem;
  width: 100%;
  background-color: var(--tertiary-color);
  position: fixed;
  top: 0;
  z-index: 4;
}

a {
  text-decoration: none;
}

.header-container-in-place {
  position: relative;
  visibility: hidden;
}

.header-logo {
  flex: 0 1;
}

.header-navigation {
  flex: 1 1;
  padding: 0.5rem;
  display: flex;
  align-items: end;
  justify-content: center;
  flex-direction: row;
}

.header-user {
  flex: 0 1;
}
</style>
