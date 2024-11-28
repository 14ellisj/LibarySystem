<script lang="ts">
import '../../styles/variables.css'
import { defineComponent, ref } from 'vue'
import { useUserStore } from '../../stores/profileInformation';

export default defineComponent({
    name: 'logInValidation',
    setup() {
        const store = useUserStore();

        if (store != null){
            console.log(store)
        }

        return {
            store,
        };
    },
});
</script>

<template>
    <body>
        <main>
            <p v-for = "user in store.user"> The ID is: {{ user.id }} </p>
        </main>
    </body>
</template>