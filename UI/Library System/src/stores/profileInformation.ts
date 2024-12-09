import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import type { Profile } from '@/models/profile'

export const useUserStore = defineStore('user', {
  state: () => ({
    user: {} as Profile,
  }),
  actions: {
    setUser(userInput: Profile) {
      this.user = userInput
    },
  },
})
