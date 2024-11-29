<script lang="ts">
import '../../styles/variables.css'
import { defineComponent, ref } from 'vue'
import { useUserStore } from '../../stores/profileInformation';

export default defineComponent({
    name: 'logInValidation',
    setup() {
        const store = useUserStore();
        return {
            store,
        };
    },
});
</script>

<template>
    <body>
        <main>
            <p> The name is: {{ store.user[0]['firstName'] }} </p>
        </main>
    </body>
</template>