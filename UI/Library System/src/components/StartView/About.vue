<script lang="ts">
import { defineComponent, ref } from 'vue'
import { useMediaStore } from '../../stores/media';
 

export default defineComponent({
  name: 'SingleMediaView',
  setup() {
    const store = useMediaStore();

    return {
      store,
    };
  },
});

</script>

<template>
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>About Us - Library</title>
</head>
<body>

  <header>
    <h1>Welcome to Our Library.........</h1>
    <p> Your gateway to knowledge and exploration.</p>
  </header>

  <section class="about">
    <h2>About Us</h2>
    <p>Our library has been a cornerstone of the community for over 50 years, providing access to a wide range of books, digital resources, and educational programs. We are committed to fostering a love for reading and lifelong learning for people of all ages.</p>
  </section>

  <h1>Locations</h1>

  <section class="locations">
    <div class="location">
      <h3>Central Branch</h3>
      <p><strong>Address:</strong> Sheffield </p>
      <p><strong>Hours:</strong> Mon-Fri 9:00 AM - 6:00 PM, Sat 10:00 AM - 4:00 PM</p>
      <p><strong>Contact:</strong> +44 4567 139642</p>
    </div>

    <div class="location">
      <h3>North Branch</h3>
      <p><strong>Address:</strong> Glasgow </p>
      <p><strong>Hours:</strong> Mon-Fri 9:00 AM - 5:00 PM, Closed on Sundays</p>
      <p><strong>Contact:</strong> +44 6789 109649</p>
    </div>

    <div class="location">
      <h3>South Branch</h3>
      <p><strong>Address:</strong>  London </p>
      <p><strong>Hours:</strong> Mon-Sat 10:00 AM - 6:00 PM</p>
      <p><strong>Contact:</strong> +44 2078 104582</p>
    </div>

  </section>
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
  padding: 20px;
}

header {
  background-color: var(--secondary-color);
  color: #fff;
  padding: 20px;
  text-align: center;
}

header h1 {
  margin-bottom: 10px;
}

header p {
  font-size: 1.2em;
}

section {
  margin: 30px 0;
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

footer p {
  font-size: 1em;
}

</style>