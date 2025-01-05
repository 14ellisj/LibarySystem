<script lang="ts">
import ReturnItem from './ReturnItem.vue'
import ProfileService from '@/services/ProfileService';
import type { ProfileFilter } from '@/models/filters';
import { useUserStore } from '../../stores/profileInformation'
import { useMediaStore } from '../../stores/media'
import '../../styles/variables.css'
import { defineComponent } from 'vue'

export default defineComponent({
    name: 'logInValidation',
    components: {
        ReturnItem
    },
    setup() {
        const store = useUserStore();
        const mediaStore = useMediaStore();
        var userID = store.user['id']
        return {
            store,
            mediaStore,
        };
    },
    methods: {
      push() {
        this.$router.push('/logIn');
      },
      returnMedia() {
        
      }
    }
});
</script>

<template>
    <ReturnItem>
        <template #Heading> Return point </template>
        <template #Subheading> This is where you can return the media you have borrowed </template>
    </ReturnItem>

    <body>
        <main v-if="store.loggedIn == 'true'">
            <table>
                <thead>
                    <th> Media name </th>
                    <th> Status </th>
                    <th> Return </th>
                </thead>
                <tbody>
                    <template v-for="media in mediaStore.media" :key="store.user[0]['id']"> 
                        <tr>
                            <td> {{ media.name }} </td> 
                            <td> {{ }} </td> 
                            <td> <button @click="returnMedia()"> Return </button> </td> 
                        </tr>
                    </template>
                </tbody>
            </table>
        </main>
        <main v-else>
            <div class="button">
                <p> You are not logged in, please log in to see your borrowed media </p>
                <button @click="push()"> Log In </button>
            </div>
        </main>
    </body>
</template>

<style scoped>
    main {
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    table {
        text-align: center;
        background-color: white;
        border: 2px solid black;
        border-collapse: collapse;
    }

    th, td {
        padding: 1rem;
        border: 2px solid black;
    }

    .button {
        text-align: center;
    }
</style>