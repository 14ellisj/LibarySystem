<script setup lang="ts">
</script>

<template>
    <header>
    <!--<img src="../../images/LibraryLogoDone.png" alt="Logo Image" class="logo">-->
    </header>
    <body class="body">
        <tbody>
            <table class="table_item">
                <tr>
                    <td></td>
                    <td><div class="title">Title</div></td>
                    <td><div class="stars">Stars</div></td>
                </tr>
                <tr>
                    <td></td>
                    <td><div class="media_art">Media Art</div></td>
                    <td><div class="description">Description</div></td>
                </tr>
                <tr>
                    <td></td>
                    <td><div class="wishlist">Wishlist</div></td>
                    <td><div class="borrow">Borrow</div></td>
                </tr>
                <tr>
                    <td colspan="3"> <div class="reviews">Reviews</div></td>
                </tr>
            </table>
        </tbody>
    </body>
</template>

<style scopped>
    .table_item{
       
    }

    .body{
        margin: auto;
    }

    .logo{
    position: fixed;
    margin-top: 0%;
    padding-bottom: 5%;
    display: block;
    margin-left: 0;
    width: 120px;
    height: 120px;
    }
    
    .media_art{
        text-align: center;
        border: solid;
    }

    .title{
        text-align: center;
        border: solid;
    }

    .description{
        text-align: center;
        border: solid;
    }

    .reviews{
        text-align: center;
        border: solid;
    }

    .wishlist{
        text-align: center;
        border: solid;
    }
    
    .borrow{
        text-align: center;
        border: solid;
    }

    .stars{
        text-align: center;
        border: solid;
    }
</style>