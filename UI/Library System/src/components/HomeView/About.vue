<script lang="ts">
import { defineComponent, ref } from 'vue'

export default defineComponent({
  name: 'About-Section',
})
</script>

<template>
  <div class="about-container">
    <div class="about">
      <h2>About Us</h2>
      <p>
        Our library has been a cornerstone of the community for over 50 years, providing access to a
        wide range of books, digital resources, and educational programs. We are committed to
        fostering a love for reading and lifelong learning for people of all ages.
      </p>
    </div>

    <h1>Locations</h1>

    <div class="locations">
      <div class="location">
        <a
          href="https://www.google.com/maps/place/Sheffield/@53.3956027,-1.6646059,11z/data=!3m1!4b1!4m6!3m5!1s0x48790aa9fae8be15:0x3e2827f5af06b078!8m2!3d53.381129!4d-1.470085!16zL20vMG03NWc?entry=ttu&g_ep=EgoyMDI0MTExOS4yIKXMDSoASAFQAw%3D%3D"
        >
          <h3>Central Branch</h3>
          <p><strong>Address:</strong> Sheffield</p>
          <p><strong>Hours:</strong> Mon-Fri 9:00 AM - 6:00 PM, Sat 10:00 AM - 4:00 PM</p>
          <p><strong>Contact:</strong> +44 4567 139642</p>
        </a>
      </div>

      <div class="location">
        <a
          href="https://www.google.com/maps/place/Glasgow/@55.8553495,-4.3976075,11z/data=!3m1!4b1!4m6!3m5!1s0x488815562056ceeb:0x71e683b805ef511e!8m2!3d55.8616704!4d-4.2583345!16zL20vMGh5eHY?entry=ttu&g_ep=EgoyMDI0MTExOS4yIKXMDSoASAFQAw%3D%3D"
        >
          <h3>North Branch</h3>
          <p><strong>Address:</strong> Glasgow</p>
          <p><strong>Hours:</strong> Mon-Fri 9:00 AM - 5:00 PM, Closed on Sundays</p>
          <p><strong>Contact:</strong> +44 6789 109649</p>
        </a>
      </div>

      <div class="location">
        <a
          href="https://www.google.com/maps/place/London/@51.5281779,-0.4319226,10z/data=!3m1!4b1!4m6!3m5!1s0x47d8a00baf21de75:0x52963a5addd52a99!8m2!3d51.5072178!4d-0.1275862!16zL20vMDRqcGw?entry=ttu&g_ep=EgoyMDI0MTExOS4yIKXMDSoASAFQAw%3D%3D"
        >
          <h3>South Branch</h3>
          <p><strong>Address:</strong> London</p>
          <p><strong>Hours:</strong> Mon-Sat 10:00 AM - 6:00 PM</p>
          <p><strong>Contact:</strong> +44 2078 104582</p>
        </a>
      </div>
    </div>
  </div>
</template>

<style scoped>
.about {
  padding: 1rem;
}

.about h2,
.locations h2 {
  font-size: 2rem;
  color: #333;
  margin-bottom: 1rem;
}

.about p {
  font-size: 1.1rem;
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
  border-radius: 0.5rem;
  box-shadow: 0 0.25rem 0.5rem rgba(0, 0, 0, 0.1);
  padding: 1.25rem;
  text-align: center;
}

.location h3 {
  color: black;
  margin-bottom: 0.625rem;
}

.location p {
  font-size: 1.1rem;
  color: #666;
}
</style>
