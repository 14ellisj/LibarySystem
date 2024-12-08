import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import type { ProfileDetails } from '@/models/profile'

export const useUserStore = defineStore('user', {
  state: () => ({
    user: {} as ProfileDetails,
  }),
  actions: {
    setUser(userInput: ProfileDetails) {
      this.user = userInput
    },
  },
})
