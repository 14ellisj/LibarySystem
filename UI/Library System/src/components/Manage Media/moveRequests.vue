<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useMediaStore } from '../../stores/media';
import MediaService from '@/services/MediaService';

export default defineComponent({
  name: 'moveRequests',
  setup() {
    const mediaStore = useMediaStore(); 
    const mediaMoves = ref(mediaStore.mediaMoves); 
    const showRejectConfirmDialog = ref(false); 
    const showAcceptConfirmDialog = ref(false); 
    const selectedMoveId = ref<number | null>(null); 
    const selectedAcceptedMoveId = ref<number | null>(null); 
    const selectedAcceptedMoveItem = ref<any | null>(null); 

    const handleRejectMove = (id: number) => {
      selectedMoveId.value = id; 
      showRejectConfirmDialog.value = true; 
    };

    const confirmRejection = () => {
      const rejectedMoveId = selectedMoveId.value;

      if (rejectedMoveId === null) return;
      mediaStore.mediaMoves = mediaStore.mediaMoves.filter(item => item.Id !== rejectedMoveId);
      mediaMoves.value = mediaStore.mediaMoves;
      selectedMoveId.value = null;
      showRejectConfirmDialog.value = false;
    };

    const cancelRejection = () => {
      showRejectConfirmDialog.value = false; 
    };

    const handleAcceptMove = (item: any) => {
      selectedAcceptedMoveItem.value = item; 
      showAcceptConfirmDialog.value = true; 
    };

    const confirmAcceptance = async () => {
      const acceptedMoveItem = selectedAcceptedMoveItem.value;
      if (acceptedMoveItem === null) return;
      await moveMedia(acceptedMoveItem.mediaId, acceptedMoveItem.branchDestinationId);
      mediaStore.mediaMoves = mediaStore.mediaMoves.filter(item => item.Id !== acceptedMoveItem.Id);
      mediaMoves.value = mediaStore.mediaMoves;
      selectedAcceptedMoveItem.value = null;
      showAcceptConfirmDialog.value = false;
    };

    const cancelAcceptance = () => {
      showAcceptConfirmDialog.value = false; 
    };

    const moveMedia = async (mediaId: number, branchDestinationId: number) => {
      const mediaService = new MediaService();
      const success = await mediaService.moveMedia(mediaId, branchDestinationId);
    };

    return {
      mediaMoves,
      showRejectConfirmDialog,
      showAcceptConfirmDialog,
      selectedMoveId,
      selectedAcceptedMoveId,
      selectedAcceptedMoveItem,
      handleRejectMove,
      confirmRejection,
      cancelRejection,
      handleAcceptMove,
      confirmAcceptance,
      cancelAcceptance,
      moveMedia,
    };
  },
});
</script>

<template>
  <body>
    <main>
      <h1>Move Requests</h1>
      <table v-if="mediaMoves.length > 0">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>From</th>
            <th>Move to</th>
            <th>Accept</th>
            <th>Reject</th>
          </tr>
        </thead>
        <tbody>
          <template v-for="item in mediaMoves" :key="item.Id">
            <tr>
              <td>{{ item.mediaId }}</td>
              <td>{{ item.mediaName }}</td>
              <td>{{ item.branchFrom }}</td>
              <td>{{ item.branchDestination }}</td>
              <td><button class="accept-button" @click="handleAcceptMove(item)">Accept Move</button></td>
              <td><button class="reject-button" @click="handleRejectMove(item.Id)">Reject Move</button></td>
            </tr>
          </template>
        </tbody>
      </table>
      <p v-else>No move requests</p>

      <div class="back-button-container">
        <button @click="$router.push('/manage');">Back</button>
      </div>

      <div v-if="showRejectConfirmDialog" class="confirm-dialog-overlay">
        <div class="confirm-dialog">
          <p>Are you sure you want to reject this move?</p>
          <div class="dialog-buttons">
            <button @click="confirmRejection">Yes</button>
            <button @click="cancelRejection">No</button>
          </div>
        </div>
      </div>

      <div v-if="showAcceptConfirmDialog" class="confirm-dialog-overlay">
        <div class="confirm-dialog">
          <p>Are you sure you want to accept this move?</p>
          <div class="dialog-buttons">
            <button @click="confirmAcceptance">Yes</button>
            <button @click="cancelAcceptance">No</button>
          </div>
        </div>
      </div>
    </main>
  </body>
</template>


<style scoped>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  font-family: Arial, sans-serif;
  background-color: var(--background-color);
  color: #333;
}

main {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 50px 20px;
}

h1 {
  font-size: 2rem;
  margin-bottom: 20px;
}

table {
  width: 80%;
  border-collapse: collapse;
  background-color: white;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

th,
td {
  padding: 12px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}

th {
  background-color: var(--secondary-color);
  color: white;
}

.back-button-container {
  margin-top: 20px;
  text-align: center;
}

button {
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 1rem;
}

button:hover {
  background-color: var(--primary-color-hover);
}

.accept-button {
  background-color: green;
  color: white;
}

.accept-button:hover {
  background-color: darkgreen;
}

.reject-button {
  background-color: red;
  color: white;
}

.reject-button:hover {
  background-color: darkred;
}

.confirm-dialog-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
}

.confirm-dialog {
  background-color: white;
  padding: 20px;
  border-radius: 8px;
  text-align: center;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}

.dialog-buttons {
  display: flex;
  gap: 10px;
  margin-top: 20px;
}
</style>
