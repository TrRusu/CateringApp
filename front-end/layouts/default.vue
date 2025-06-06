<template>
  <div class="default-wrapper">
    <slot />
  </div>
</template>

<style scoped>
.default-wrapper {
  display: flex;
  flex-direction: column;
  max-width: 744px;
  margin: 0 auto;
  padding: 40px 30px;
}
</style>
