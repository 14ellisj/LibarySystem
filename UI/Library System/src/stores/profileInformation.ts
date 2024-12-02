import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import type { Profile } from '@/models/profile'

export const useUserStore = defineStore('user', {
  state: () => ({
    user: {} as Profile,
    password: "" as string,
    loggedIn: "false" as string
  }),
  actions: {
    setUser(userInput: Profile) {
      this.user = userInput
    },
    setPassword(password: string) {
      this.password = password
    },
    setLoggedIn() {
      this.loggedIn = "true"
    },
    setNotLoggedIn() {
      this.loggedIn = "false"
    }
  }
})
