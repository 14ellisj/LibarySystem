<script lang="ts">
import { defineComponent } from 'vue';
import '../../styles/variables.css';

export default defineComponent({
  name: 'Profile',
  data() {
    return {
      hovering: false,
    };
  },
  methods: {
    async toOrders() {
      this.$router.push('');
    },
    async toWishlist() {
      this.$router.push('/Wishlist');
    },
    async toReturn() {
      this.$router.push('/Return');
    },
    async toSettings() {
      this.$router.push('');
    },
    async toLogIn() {
      this.$router.push('/logIn');
    },
  },
});
</script>

<template>
  <div class="profile-container">
    <h2>My Profile</h2>
    <div class="profile-card">
      <button @click="toOrders()">Orders</button>
      <button @click="toWishlist()">Wishlist</button>
      <button @click="toReturn()">Return Media</button>
      <button @click="toSettings()">Settings</button>
      <button @click="toLogIn()" class="logout-button">Log Out</button>
    </div>
  </div>
</template>

<style scoped>
.profile-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 2rem;
  background-color: var(--primary-bg);
  min-height: 100vh;
  color: var(--primary-text);
}

h2 {
  font-size: 2rem;
  margin-bottom: 1.5rem;
}

.profile-card {
  display: flex;
  flex-direction: column;
  background: var(--card-bg, #fff);
  border: 1px solid var(--border-color, #ddd);
  border-radius: 8px;
  padding: 2rem;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

button {
  background-color: var(--secondary-color, #007bff);
  color: #fff;
  border: none;
  border-radius: 4px;
  padding: 0.75rem 1rem;
  margin: 0.5rem 0;
  font-size: 1rem;
  cursor: pointer;
  transition: background-color 0.3s ease, transform 0.2s ease;
  text-align: center;
}

button:hover {
  background-color: var(--secondary-hover-color, #0056b3);
  transform: translateY(-2px);
}

button:focus {
  outline: 2px solid var(--focus-color, #0056b3);
}

.logout-button {
  background-color: var(--danger-color, #dc3545);
}

.logout-button:hover {
  background-color: var(--danger-hover-color, #c82333);
}
</style>
