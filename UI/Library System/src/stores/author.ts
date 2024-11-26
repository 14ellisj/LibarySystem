import { defineStore } from 'pinia'
import type { Author } from '@/models/author'

export const useAuthorStore = defineStore('author', {
  state: () => ({
    author: [{
    }] as Author[],
    count: 0
  }),
  actions: {
    setAuthor(authorInput: Author[]) {
      this.author = authorInput;
      console.log(this.author);
    }
  }
})
