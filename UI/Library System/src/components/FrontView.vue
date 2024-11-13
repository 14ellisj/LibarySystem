<script setup lang="ts">
</script>

<template>
  <header>
    <img src="../images/LibraryLogoDone.png" alt="Logo Image" class="logo">
    </header>
    <body>
    <tbody>
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
                <td><a href="SingleMediaView.vue">Cd 1</a> </td>
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
        display: block;
    margin-left: 0;
    width: 20%;
    height: 20%;
    padding-bottom: 5%;
    }
  
</style>