<script setup lang="ts">
import { defineComponent, ref } from 'vue'
import { type Media } from '../../models/media';
import MediaService from '@/services/MediaService'


</script>

<template>
  <header>
    <a href="home"><img src="../../images/LibraryLogoDone.png" alt="Logo Image" class="logo"></a>
    <a href="profile"><img src="../../images/profile.webp" alt="Profile" class="logo-profile"></a>
    </header>
    <body>
    <tbody class="table-flex">
        <table>
            <tr class="table-top">
                <td colspan="4">Library</td>
            </tr>
            <tr class="headers">
                <td>Title</td>
                <td>Author</td>
                <td>Availability</td>
                <td>Type Media</td>
            </tr>
            <tr>
                <td><a href="Item">Cd 1</a> </td>
                <td>BOB</td>
                <td>1</td>
                <td>CD</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
            </table>
        </tbody>
    </body>
</template>

<style>
    body {
    font-family: helvetica, arial, sans-serif;
    font-size: 1rem;
    padding: 0%;
    background-color: var(--background-color);
    color: black;
  }

  table{
    width:100%;
    background-color: var(--highlight-color);
    text-align: center;
    border: solid;
    border-color: black;
    padding: 0%;
    font-size: small;
    margin-left: 10%;
    margin-right: 10%;
    overflow: auto;
    padding-bottom: 0%;
    margin-bottom: 0%;
    height: 50%;
    border-radius: 3%;
    color: black;
  }

  .table-flex{
    width: 50%;
    margin-left: 30%;
    margin-right: 30%;
    margin-top: 30%;
  }

  .table-top{
    text-align: center;
    font-size: large;
    border: 1px solid;
    border-color: black;
    color: black;
  }

  .headers{
    font-size: medium;
    border: 1px solid;
    border-color: black;
    color: black;
  }

  td{
    padding-top: 5%;
    padding-left: 5%;
    border-bottom: solid 1px;
    text-align: center;
    padding-bottom: 5%;
    color: black;
  }

    .logo{
        position: fixed;
        display: block;
        margin-left: 0%;
        width: 30%;
        height: 30%;
        padding-bottom: 5%;
    }

    .logo-profile{
        position: fixed;
        margin-left: 0%;
        width: 15%;
        height: 20%;
    }
</style>