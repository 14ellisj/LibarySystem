<script lang="ts">
import SearchBar from '@/components/HomeView/SearchBar.vue'
import WelcomeArea from '@/components/HomeView/Welcome.vue'
import AboutSection from '@/components/HomeView/About.vue'
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'Home-View',
  components: {
    WelcomeArea,
    SearchBar,
    AboutSection,
  },
})
</script>

<template>
  <main>
    <div class="home-container">
      <div class="welcome-area">
        <WelcomeArea />
      </div>
      <div class="welcome-area welcome-border"></div>
      <div class="introduction-area">
        <SearchBar />
      </div>
      <div class="about-area">
        <AboutSection />
      </div>
    </div>
  </main>
</template>

<style scoped>
.welcome-area {
  width: 100%;
  background-color: var(--secondary-color);
  height: 15rem;
  clip-path: polygon(0 0, 100% 0, 100% 75%, 0% 100%);
  position: absolute;
  z-index: 3;
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

  background-image: url('../assets/Welcome-background.jpg');
  background-position: center;
}

.about-area {
  border: 0;
  height: 50rem;
}
</style>
