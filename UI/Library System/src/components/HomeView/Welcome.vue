<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'Welcome-Area',
})
</script>

<template>
  <div class="home-container">
    <div class="welcome-area">
      <h1>Welcome to Our Library</h1>
      <p>Your gateway to knowledge and exploration</p>
    </div>
    <div class="welcome-area welcome-border"></div>
  </div>
</template>

<style scoped>
.about h2,
.locations h2 {
  font-size: 2em;
  color: #333;
  margin-bottom: 20px;
}

.about p {
  font-size: 1.1em;
  color: #555;
}

.locations {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  gap: 20px;
}

a {
  text-decoration: none;
}

.location {
  background-color: #fff;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  padding: 20px;
  text-align: center;
}

.location h3 {
  color: black;
  margin-bottom: 10px;
}

.location p {
  font-size: 1.1em;
  color: #666;
}

footer {
  text-align: center;
  padding: 20px;
  background-color: #333;
  color: #fff;
  margin-top: 40px;
}

.padding {
  padding: 20px;
}

footer p {
  font-size: 1em;
}

.welcome-area {
  width: 100%;
  background-color: var(--secondary-color);
  height: 15rem;
  clip-path: polygon(0 0, 100% 0, 100% 75%, 0% 100%);
  position: absolute;
  z-index: 3;
  color: #fff;
  padding: 20px;
  text-align: center;
  font-size: 1.2em;
  margin-bottom: 10px;
}

.welcome-border {
  background-color: black;
  z-index: 2;
  margin-top: 8px;
}

.home-container {
  display: grid;
}

.introduction-area {
  display: grid;
  border-bottom: solid black 8px;
  margin-top: 11.5rem;
  height: 30rem;
  align-content: center;
  justify-items: center;
  background-image: url('../../assets/Welcome-background.jpg');
  background-position: center;
}
</style>
