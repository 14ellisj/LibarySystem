<script setup lang="ts">
</script>

<template>
  <header>
        <table>
            <tr class="tabletop">
                <td>Library</td>
            </tr>
            <tr class="headers">
                <td>Title</td>
                <td>Author</td>
                <td>Availability</td>
                <td>Type Media</td>
            </tr>
            <tr>
                <td>CD 1</td>
                <td>Joe Denton</td>
                <td>1</td>
                <td>CD</td>
            </tr>
            <tr>
                <td>Book 1</td>
                <td>Henry Baker</td>
                <td>0</td>
                <td>Book</td>
            </tr>
        </table>
    </header>
</template>

<style>
    body {
    font-family: helvetica, arial, sans-serif;
    font-size: 1em;
    padding: 0%;
    background-color: #C1CFA1;
    color: black;
  }
  table{
    width: 100%;
    background-color: #EDE8DC;
    text-align: center;
    border: 1px solid;
    border-color: black;
    padding: 0%;
    font-size: small;
  }
  .tabletop{
    text-align: center;
    font-size: large;
    border: 1px solid;
    border-color: black;
  }
  .headers{
    font-size: medium;
    border: 1px solid;
    border-color: black;
  }

</style>