<template>
  <div class="bar">
    <div class="bar-wrapper" :scroll-left.camel="scrollLeft">
      <div
        v-for="(category, index) in store.menuItems"
        ref="categoryItems"
        :key="category.id"
        class="bar-category body-large bold"
        :class="{ active: store.selectedCategory.id === category.id }"
        @click="clickOnCategory($event, category.id, index)"
      >
        {{ category.name }}
      </div>
    </div>
  </div>
</template>

<script setup>
import { useMenuStore } from '~/store/MenuStore'

const store = useMenuStore()
const scrollLeft = ref(0)
const categoryItems = ref([])

const clickOnCategory = ($event, categoryId, index) => {
  const categoryItem = categoryItems.value[index]
  categoryItem.scrollIntoView({ behavior: 'smooth', inline: 'center' })
  store.selectCategory(categoryId)
}
</script>

<style lang="scss" scoped>
.bar {
  position: relative;

  .bar-wrapper {
    margin-top: 0px;
    width: 100%;
    overflow-x: scroll;
    display: flex;
    margin-bottom: 24px;

    -ms-overflow-style: none;
    scrollbar-width: none;
    &::-webkit-scrollbar {
      width: 0;
      height: 0;
    }

    .bar-category {
      padding-top: 20px;
      padding-bottom: 20px;
      margin-right: 70px;

      &.active {
        border-bottom: 2px solid $c-black;
      }
    }
  }

  .arrow-right {
    display: block;
    padding: 20px;
    font-size: 20px;
    position: absolute;
    right: 0;
    background-color: $c-lightgrey;
    text-align: center;
    border-radius: 4px;
    top: 50%;
    transform: translateY(-50%);
  }
}
</style>
