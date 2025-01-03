<script lang="ts">
import ReturnItem from './ReturnItem.vue'
import ProfileService from '@/services/ProfileService';
import type { ProfileFilter } from '@/models/filters';
import { useUserStore } from '../../stores/profileInformation'
import { useMediaStore } from '../../stores/media'
import '../../styles/variables.css'
import { defineComponent } from 'vue'
import MediaService from '@/services/MediaService';
import toastr from 'toastr';

export default defineComponent({
    name: 'logInValidation',
    components: {
        ReturnItem
    },
    setup() {
        const store = useUserStore();
        const mediaStore = useMediaStore();
        var userID = store.user.id
        return {
            store,
            mediaStore,
            userID
        };
    },
    methods: {
      push() {
        this.$router.push('/logIn');
      },
      async returnMedia(id: number, title: string) {
        const mediaService = new MediaService();
        const returnMedia = await mediaService.returnMedia(id, this.userID);
        this.mediaStore.setTitle(title)
        toastr.success("Successfully returned " + title)
        this.$router.push('/Returned')
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
                    <th> Author </th>
                    <th> Return </th>
                </thead>
                <tbody>
                    <template v-for="media in mediaStore.media" :key="store.user.id"> 
                        <tr>
                            <td> {{ media.name }} </td> 
                            <td></td>
                            <td> <button @click="returnMedia(media.id, media.name)"> Return </button> </td> 
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
