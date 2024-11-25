<script lang="ts">
    import AboutView from '../components/StartView/About.vue';
    import { defineComponent } from 'vue';

    export default defineComponent({
        name: "Item",
        components: {
            AboutView
        }
    })
</script>

<template>
  <div> 
    <AboutView/>
  </div>
</template>