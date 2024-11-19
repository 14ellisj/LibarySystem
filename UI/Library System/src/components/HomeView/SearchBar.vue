<script lang="ts">
import type { Filter } from '@/models/filters';
import MediaService from '@/services/MediaService';
import { useMediaStore } from '@/stores/media';
import { defineComponent } from 'vue'

export default defineComponent({
  name: "SearchBar",
  data() {

    var query: string = "";
    var searchType: string = "Title";

    return {
        query,
        searchType
    }
  },
  methods: {
    async submit() {
        const mediaService = new MediaService();
        const filter: Filter = {
            author: this.searchType === "Author" ? this.query : undefined,
            title: this.searchType === "Title" ? this.query : undefined
        }
        await mediaService.filterData(filter);
        this.$router.push('/front');
    },
    handleKeyPress(e: KeyboardEvent) {
        if (e.key === 'Enter')
            this.submit();
    } 
  }
});

</script>

<template>
    <div class="search-container">
        <div class="search-area">
            <input type="text" v-model="query" placeholder="Find your next... " @keypress="handleKeyPress($event)"/>
        </div>
        <div class="search-select-area">
            <div class="search-for-dropdown">
                <label>Searching For...</label>
                <select v-model="searchType" name="search-for">
                    <option>Title</option>
                    <option>Author</option>
                </select>
            </div>
        </div>
        <div class="search-button-area">
            <button class="search-button" @click="submit()">Search</button>
        </div>
    </div>
</template>

<style scoped>


    .search-container {
        background-color: white;
        border-radius: 2.5rem;
        height: 5rem;
        width: 70%;
        outline: solid black 2px;

        display: flex;
        box-shadow: -4px 4px 5px 0px rgba(0,0,0,0.75);
    }

    .search-for-dropdown {
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

    .search-area {
        flex-direction: column;
        flex: 3 1 0;
        border-right: solid black 2px;
        padding-left: 2.5rem;

    }

    input[type=text] {
        border: 0;
        outline: 0;
        height: 100%;
        width: 99%;

        font-size: 1.5rem;
    }

    .search-select-area {
        flex: 1 0 0;
        flex-direction: column;
        border-right: solid black 2px;
    }

    .search-button-area {
        flex: 1 0 0;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        text-align: center;
    }

    .search-button {
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

    .search-button:hover {
        filter: brightness(85%);
    }

</style>