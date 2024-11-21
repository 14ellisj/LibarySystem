<script setup lang="ts">
import { defineComponent } from 'vue';

defineProps<{
    Title: string,
    Path: string
}>();

defineComponent({
    name: 'MenuItem',
    methods: {

    }
})
</script>

<template>
    <div class="item-container">
        <RouterLink :to="Path">{{ Title }}</RouterLink>
    </div>
</template>
  
<style scoped> 
    .item-container {
        color: white;
        font-size: 1.5rem;
        padding: 0 2rem;

    }

    a {
        color: white;
        text-decoration: none;
        font-family: Arial, Helvetica, sans-serif;
        justify-content: center;
    }

    a:hover {
        color: #aaaaaa
    }

    .router-link-active {

            font-weight: 400;
            color: var(--background-color);
            text-decoration: underline;
    }
</style>