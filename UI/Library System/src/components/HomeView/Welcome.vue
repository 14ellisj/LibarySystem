<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: "Welcome-Area",
});
</script>

<template>
    <div class="home-container">
        <div class="welcome-area">
            <h1>Welcome to Our Library</h1>
            <p> Your gateway to knowledge and exploration</p>
        </div>
        <div class="welcome-area welcome-border"></div>
    </div>
</template>

<style scoped>

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
}
</style>
