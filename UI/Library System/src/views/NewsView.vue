<script lang="ts">
    import News from '../components/StartView/News.vue';
    import { defineComponent } from 'vue';

    export default defineComponent({
        name: "Item",
        components: {
            News
        }
    })
</script>

<template>
  <div> 
    <News/>
  </div>
</template>