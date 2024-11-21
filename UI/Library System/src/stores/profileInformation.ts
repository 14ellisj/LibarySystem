import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import type { ProfileDetails } from '@/models/profileDetials'

export const useUserStore = defineStore('user', {
  state: () => ({
    user: [] as ProfileDetails[],
    count: 0
  }),
  actions: {
    setUser(userInput: ProfileDetails[]) {
      this.user = userInput
    }
  }
})
