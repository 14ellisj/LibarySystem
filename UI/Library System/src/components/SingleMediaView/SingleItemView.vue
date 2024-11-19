<script setup lang="ts">
</script>

<template>
   <!DOCTYPE html>
<body>
    <div class="product-page">
        <div class="product-container">
            <!-- Product Image -->
            <div class="product-image">
                <img src="../../images/It_(1986)_front_cover,_first_edition.jpg" alt="Product Image">
            </div>
            
            <!-- Product Info -->
            <div class="product-info">
                <h1 class="product-title">IT</h1>

                <!-- Star Review -->
                <div class="product-reviews">
                    <span class="stars">★★★★★</span>
                    <span class="review-count">(120 reviews)</span>
                </div>

                <!-- Product Description -->
                <p class="product-description">
                    The story begins when a band of seven “uncool” 11-year-olds, led by Bill Denbrough, discovers and battles an evil, shape-changing monster that the children call “It.
                </p>

                <!-- Customer Reviews Section -->
                <div class="customer-reviews">
                    <h2>Customer Reviews</h2>
                    <div class="review">
                        <p><strong>John Doe:</strong> Great product, highly recommend!</p>
                    </div>
                    <div class="review">
                        <p><strong>Jane Smith:</strong> It exceeded my expectations. Worth the price!</p>
                    </div>
                </div>
                <div class="button-single">
                <button class="borrow-button">Borrow</button>
                <a href="Wishlist"><button class="borrow-button">+ Wish-list</button></a>
                <button class="borrow-button">Join waiting list</button>
                </div>
            </div>
        <div>
            <a href="Front"><-- Back</a>
        </div>
        </div>
    </div>
</body>
</template>

<style scoped>
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

body {
    font-family: Arial, sans-serif;
    background-color: var(--background-color);
    padding: 20px;
    display: flex;
    justify-content: center;
}

.product-page {
    max-width: 900px;
    margin: auto;
    background-color: white;
    padding: 20px;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.product-container {
    display: flex;
    flex-direction: row;
    gap: 20px;
}

.product-image img {
    width: 300px;
    height: 300px;
    object-fit: cover;
    border-radius: 8px;
}

.product-info {
    flex: 1;
}

.product-title {
    font-size: 2rem;
    font-weight: bold;
    color: #333;
    margin-bottom: 10px;
}

.product-reviews {
    font-size: 1.1rem;
    margin-bottom: 10px;
}

.stars {
    color: gold;
}

.review-count {
    margin-left: 10px;
    color: #888;
}

.product-description {
    font-size: 1rem;
    color: #555;
    margin-bottom: 20px;
}

.customer-reviews {
    margin-bottom: 20px;
}

.customer-reviews h2 {
    font-size: 1.4rem;
    color: #333;
    margin-bottom: 10px;
}

.review {
    font-size: 1rem;
    color: #555;
    margin-bottom: 10px;
}

.borrow-button {
    background-color: #28a745;
    color: white;
    font-size: 1.2rem;
    padding: 12px 20px;
    border: none;
    border-radius: 5px;
    cursor: pointer;
}

.borrow-button:hover {
    background-color: #218838;
}

.button-single {
    display: flex;
    justify-content: space-between;
}

</style>