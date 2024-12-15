<script lang="ts">
import type { MediaFilter } from '@/models/filters'
import { SearchType } from '@/models/searchType'
import MediaService from '@/services/MediaService'
import { useUserStore } from '@/stores/profileInformation'
import { defineComponent } from 'vue'
import { useMediaStore } from '@/stores/media'

export default defineComponent({
  name: 'Search-Bar',
  data() {
    var query: string = ''
    var searchType: number = 0
    var autoCompleteResults: string[] = []
    var autoCompleteTimeout: number = 0
    var userStore = useUserStore()
    var mediaStore = useMediaStore()


    const searchTypesCount = Object.keys(SearchType).length / 2

    const mediaService = new MediaService()
    

    return {
      query,
      searchType,
      searchTypesCount,
      SearchType,
      autoCompleteResults,
      autoCompleteTimeout,
      mediaService,
      userStore,
      mediaStore
    }
  },
  methods: {
    async submit(fromSuggestions: boolean) {
    
      const filter: MediaFilter = {
        title: this.searchType === SearchType.Title ? this.query : undefined,
        author: this.searchType === SearchType.Author ? this.query : undefined,
        is_selected: fromSuggestions,
        profile_id: this.userStore.user?.id
      }
      await this.mediaService.filterData(filter)
      this.$router.push('/front')

    },
    selectAutocompleteOption(e: MouseEvent, selected: string) {
      this.query = selected
      this.submit(true)
    },
    async getAutoComplete() {
      if (this.query.trim().length < 2) {
        this.autoCompleteResults = []
        return
      }

      clearTimeout(this.autoCompleteTimeout)
      this.autoCompleteTimeout = setTimeout(async () => {
        this.autoCompleteResults = await this.mediaService.getAutoComplete(
          this.query,
          this.searchType,
        )
      }, 300)
    },
    handleKeyPress(e: KeyboardEvent) {
      if (e.key === 'Enter') this.submit(false)
    },
  },
})
</script>

<template>
  <div class="search-container">
    <div class="search-bar-container">
      <div class="search-bar-area">
        <input
          type="text"
          v-model="query"
          placeholder="Find your next... "
          @input="getAutoComplete()"
          @keypress="handleKeyPress($event)"
        />
      </div>
      <div class="search-bar-select-area">
        <div class="search-bar-select-dropdown">
          <label>Searching For...</label>
          <select v-model="searchType" name="search-for">
            <option v-for="(n, index) in searchTypesCount" :value="index">
              {{ SearchType[index] }}
            </option>
          </select>
        </div>
      </div>
      <div class="search-bar-button-area">
        <button class="search-bar-button" @click="submit(false)">Search</button>
      </div>
    </div>
    <div class="auto-complete-container" v-show="autoCompleteResults.length > 0">
      <ul class="auto-complete-item-container">
        <li
          v-for="author in autoCompleteResults"
          class="auto-complete-item"
          @click="selectAutocompleteOption($event, author)"
        >
          {{ author }}
        </li>
      </ul>
    </div>
  </div>
</template>

<style scoped>
.search-container {
  display: block;
  width: 70%;
}

.auto-complete-container {
  position: absolute;
  width: 70%;
  border-radius: 2.5rem;
  background-color: white;
  border: solid black 2px;
  padding: 1rem 0;
  box-shadow: -4px 4px 5px 0px rgba(0, 0, 0, 0.75);
}

.auto-complete-item-container {
  list-style: none;
  font-size: 1.25rem;
  cursor: pointer;
  padding: 0;
}

.auto-complete-item {
  padding: 1rem 2rem;
}

.auto-complete-item:hover {
  background-color: #ccc;
  text-decoration: underline;
}

.search-bar-container {
  background-color: white;
  border-radius: 2.5rem;
  height: 5rem;
  outline: solid black 2px;

  display: flex;
  box-shadow: -4px 4px 5px 0px rgba(0, 0, 0, 0.75);
}

.search-bar-select-dropdown {
  display: flex;
  width: 100%;
  height: 100%;
  flex-direction: column;

  label {
    margin-top: 0.25rem;
    font-family: Arial, Helvetica, sans-serif;
    font-weight: 100;
    font-size: 0.75rem;
    padding: 0 1rem;
  }

  select {
    height: 100%;
    font-size: 1.5rem;
    background-color: white;
    border: none;
    padding: 0 1rem;
    appearance: none;
    background-image: url('../../assets/drop-down-arrow.svg');
    background-repeat: no-repeat;
    background-size: 2rem 2rem;
    background-position: calc(100% - 1rem);
  }
}

.search-bar-area {
  flex-direction: column;
  flex: 3 1 0;
  border-right: solid black 2px;
  padding-left: 2.5rem;
}

input[type='text'] {
  border: 0;
  outline: 0;
  height: 100%;
  width: 99%;

  font-size: 1.5rem;
}

.search-bar-select-area {
  flex: 1 0 0;
  flex-direction: column;
  border-right: solid black 2px;
}

.search-bar-button-area {
  flex: 1 0 0;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  text-align: center;
}

.search-bar-button {
  background: linear-gradient(0, var(--primary-color) 50%, var(--tertiary-color) 100%);
  border-radius: 0 10rem 10rem 0;
  color: white;
  width: 100%;
  height: 100%;
  margin: 0;
  border: 0;
  cursor: pointer;
  font-size: 1.25rem;
}

.search-bar-button:hover {
  filter: brightness(85%);
}
</style>
