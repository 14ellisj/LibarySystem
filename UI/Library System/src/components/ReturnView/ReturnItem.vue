<template>
  <div class="item">
    <div class="details">
      <h2>
        <slot name="Heading"></slot>
      </h2>

      <h3>
        <slot name="Subheading"></slot>
      </h3>

      <body>
        <slot name="Body"></slot>
      </body>
    </div>
  </div>
</template>

<style scoped>
.item {
  margin-top: 2rem;
  text-align: center;
  position: relative;
}

.details {
  margin-top: 2rem;
  flex: 1;
  margin-left: 1rem;
}

h2 {
  font-size: 1.2rem;
  font-weight: 700;
  margin-bottom: 0.4rem;
  color: var(--color-heading);
}

h3 {
  font-size: 1.2rem;
  font-weight: 500;
  margin-bottom: 0.4rem;
  color: var(--color-heading);
}

@media (min-width: 1024px) {
  .item {
    margin-top: 0;
    padding: 0.4rem 0 1rem calc(var(--section-gap) / 2);
  }
}
</style>
