<script setup lang="ts">
import ReturnItem from './ReturnItem.vue'
import ProfileService from '@/services/ProfileService';
import type { ProfileFilter } from '@/models/filters';
import '../../styles/variables.css'
import { defineComponent } from 'vue'
</script>

<template>
    <ReturnItem>
        <template #Heading> Return point </template>
        <template #Subheading> This is where you can return the media you have borrowed </template>
    </ReturnItem>

    <body>
        <main>
            <table>
                <thead>
                    <th> Media name </th>
                    <th> Borrowed date </th>
                    <th> Status </th>
                    <th> Return </th>
                </thead>
                <tbody>
                    <tr>
                        <td> Item 3 </td> 
                        <td> 02/11/24 </td> 
                        <td> Borrowed </td> 
                        <td> <button> Return </button> </td> 
                    </tr>
                    <tr>
                        <td> Item 2 </td> 
                        <td> 13/09/24 </td> 
                        <td> Overdue </td> 
                        <td> <button> Return </button> </td> 
                    </tr>
                    <tr>
                        <td> Item 1 </td> 
                        <td> 02/09/24 </td> 
                        <td> Returned </td> 
                        <td> <button> Returned </button> </td> 
                    </tr>
                </tbody>
            </table>
        </main>
    </body>
</template>

<style scoped>
    main {
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    table {
        text-align: center;
        background-color: white;
        border: 2px solid black;
        border-collapse: collapse;
    }

    th, td {
        padding: 1rem;
        border: 2px solid black;
    }
</style>