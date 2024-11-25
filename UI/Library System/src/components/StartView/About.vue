<script lang="ts">
import { defineComponent, ref } from 'vue'
import SearchBar from '@/components/HomeView/SearchBar.vue';
 

export default defineComponent({
        name: "HomeView",
        components: {
            SearchBar,
        }
    })

</script>

<template>
<body>
  <Section>
    <div class="home-container">
            <div class="welcome-area">
              <h1>Welcome to Our Library</h1>
              <p> Your gateway to knowledge and exploration</p>
            </div>
            <div class="welcome-area welcome-border"></div> 
            <div class = "introduction-area">
                <SearchBar />
            </div>
        </div>
  </Section>
<div class="padding">
  <section class="about">
    <h2>About Us</h2>
    <p>Our library has been a cornerstone of the community for over 50 years, providing access to a wide range of books, digital resources, and educational programs. We are committed to fostering a love for reading and lifelong learning for people of all ages.</p>
  </section>

  <h1>Locations</h1>

  <section class="locations">
    <div class="location"><a href="https://www.google.com/maps/place/Sheffield/@53.3956027,-1.6646059,11z/data=!3m1!4b1!4m6!3m5!1s0x48790aa9fae8be15:0x3e2827f5af06b078!8m2!3d53.381129!4d-1.470085!16zL20vMG03NWc?entry=ttu&g_ep=EgoyMDI0MTExOS4yIKXMDSoASAFQAw%3D%3D">
      <h3>Central Branch</h3>
      <p><strong>Address:</strong> Sheffield </p>
      <p><strong>Hours:</strong> Mon-Fri 9:00 AM - 6:00 PM, Sat 10:00 AM - 4:00 PM</p>
      <p><strong>Contact:</strong> +44 4567 139642</p>
      </a>
    </div>

    <div class="location"><a href="https://www.google.com/maps/place/Glasgow/@55.8553495,-4.3976075,11z/data=!3m1!4b1!4m6!3m5!1s0x488815562056ceeb:0x71e683b805ef511e!8m2!3d55.8616704!4d-4.2583345!16zL20vMGh5eHY?entry=ttu&g_ep=EgoyMDI0MTExOS4yIKXMDSoASAFQAw%3D%3D">
      <h3>North Branch</h3>
      <p><strong>Address:</strong> Glasgow </p>
      <p><strong>Hours:</strong> Mon-Fri 9:00 AM - 5:00 PM, Closed on Sundays</p>
      <p><strong>Contact:</strong> +44 6789 109649</p>
      </a>
    </div>

    <div class="location"><a href="https://www.google.com/maps/place/London/@51.5281779,-0.4319226,10z/data=!3m1!4b1!4m6!3m5!1s0x47d8a00baf21de75:0x52963a5addd52a99!8m2!3d51.5072178!4d-0.1275862!16zL20vMDRqcGw?entry=ttu&g_ep=EgoyMDI0MTExOS4yIKXMDSoASAFQAw%3D%3D">
      <h3>South Branch</h3>
      <p><strong>Address:</strong>  London </p>
      <p><strong>Hours:</strong> Mon-Sat 10:00 AM - 6:00 PM</p>
      <p><strong>Contact:</strong> +44 2078 104582</p>
      </a>
    </div>
  
  </section>
  </div>
</body>
</template>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  font-family: Arial, sans-serif;
  line-height: 1.6;
  background-color: var(--background-color);
  color: #333;
}



.about h2, .locations h2 {
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

.padding{
 padding: 20px
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