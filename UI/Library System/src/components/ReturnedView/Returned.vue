<script lang="ts">
import { defineComponent } from 'vue';
import '../../styles/variables.css'
import type { MediaFilter, mediaItemsFilter } from '@/models/filters';
import MediaService from '@/services/MediaService';
import toastr from 'toastr';
import { useMediaStore } from '@/stores/media';
import { useUserStore } from '@/stores/profileInformation';

export default defineComponent({
    name: 'Returned Media',
    setup() {
        const mediaStore = useMediaStore();
        var title = mediaStore.title
        const store = useUserStore();
        var userID = store.user[0]['id'];

        return {
            mediaStore,
            title,
            store,
            userID
        };
    },
    methods: {
        async goBack() {    
            const mediaService = new MediaService();
            const filter: mediaItemsFilter = {
                profileID: this.userID,
            };
            const returnMedia = await mediaService.getBorrowedMedia(filter);
                if (returnMedia.length != 0) {
                    this.$router.push('/Return');
                }
                else {
                    toastr.error("You have nothing to return, redirecting you back to profile");
                    this.$router.push('/Profile')
                }
        }
    }
})
</script>

<template>
    <h2>Success!</h2>
    <p>Successfully returned {{ this.title }}  </p>
    <button @click="goBack()"> Back </button>
</template>
  
<style scoped> 
    button {
        color: var(--secondary-color);
        padding: 1%;
        text-align: center;
        margin: 0.81rem;
    }
</style>