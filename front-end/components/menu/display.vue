<template>
  <div v-if="store.selectedCategory" class="display">
    <MenuItem
      v-for="menuItem in store.selectedCategory.items"
      :id="menuItem.Id"
      :key="menuItem.Id"
      :image="menuItem.ImageUrl"
      :name="menuItem.Name"
      :description="menuItem.Description"
      :allergies="[]"
      :price="menuItem.Price"
    />
  </div>
</template>

<script setup lang="ts">
import { useMenuStore } from '~/store/MenuStore'

const store = useMenuStore()
</script>

<style scoped>
.display {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-gap: 16px;
}
</style>
