<script lang="ts">
import '../../styles/variables.css'
import { defineComponent, ref } from 'vue'
import { useUserStore } from '../../stores/profileInformation';

export default defineComponent({
    name: 'logInValidation',
    setup() {
        const store = useUserStore();

        if (store != null){
            console.log(store.user)
        }
        else {
            console.log('for fucks sake')
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
            <p> The name is: {{ store.user.first_name }} </p>
        </main>
    </body>
</template>