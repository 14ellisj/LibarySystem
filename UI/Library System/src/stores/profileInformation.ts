import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import type { ProfileDetails } from '@/models/profile'

export const useUserStore = defineStore('user', {
  state: () => ({
    user: {
      id: 1,
      email: "test@test",
      first_name: "testName",
      last_name: "Test",
    } as ProfileDetails,
    count: 0
  }),
  actions: {
    setUser(userInput: ProfileDetails) {
      this.user = userInput
      console.log(this.user);
    }
  }
})
