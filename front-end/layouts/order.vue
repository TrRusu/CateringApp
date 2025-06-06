<template>
  <div>
    <header>
      <slot name="header" />
    </header>

    <section class="order-wrapper">
      <slot name="content" />
    </section>

    <footer>
      <slot name="footer" />
    </footer>
  </div>
</template>

<style lang="scss">
header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 20px;

  h2 {
    margin: 0;
  }
}

.order-wrapper {
  display: flex;
  flex-direction: column;
  margin: 0 auto;
  padding-bottom: 80px;
}
</style>
