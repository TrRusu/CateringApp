<template>
  <div>
    <NuxtLayout name="order">
      <template #header>
        <FormControlsButton text="<- Go back" type="primary" @click="goBack" />
      </template>

      <template #content>
        <div class="content" v-if="categoryItem">
          <img class="menu-item--image" :src="categoryItem.ImageUrl" />
          <div class="menu-item--info">
            <h2>{{ categoryItem.Name }}</h2>
            <p>{{ categoryItem.Description }}</p>

            <div class="menu-item--allergies">
              <IconAllergieNoGluten />
              <IconAllergieNoMilk />
              <IconAllergieNoStroller />
            </div>

            <div class="menu-item--price body-large bold">
              {{ $convert(categoryItem.Price) }}
            </div>

            <div class="buttons">
              <FormControlsButton
                text="-"
                type="secondary"
                @click="decreaseItemAmount"
              />
              <div class="amount body-large bold">
                {{ categoryItem.amount }}
              </div>
              <FormControlsButton
                text="+"
                type="secondary"
                @click="increaseItemAmount"
              />

              <FormControlsButton
                text="Add to cart"
                type="primary"
                :disabled="!validateCartAdd"
                @click="addItemToCart(categoryItem)"
              />
            </div>
          </div>
        </div>
      </template>

      <template #footer>
        <CartBar />
      </template>
    </NuxtLayout>
  </div>
</template>

<script lang="ts" setup>
import { definePageMeta } from '#imports'

definePageMeta({
  middleware: 'session',
})

import { useMenuStore } from '~/store/MenuStore'
import { useCartStore } from '~/store/CartStore'

const cartStore = useCartStore()
const menuStore = useMenuStore()
const route = useRoute()
const categoryItem = ref(null)

const categoryItemId = route.params.id
const possibleCategoryItem = menuStore.getCategoryItem(categoryItemId)

const validateCartAdd = computed(() => {
  return categoryItem.value.amount > 0
})

if (possibleCategoryItem === undefined) {
  navigateTo('/menu')
}

const increaseItemAmount = () => {
  if (categoryItem.value.amount < 11) {
    categoryItem.value.amount = categoryItem.value.amount + 1
  }
}

const decreaseItemAmount = () => {
  if (categoryItem.value.amount > 0) {
    categoryItem.value.amount -= 1

    if (categoryItem.value.amount == 0) {
      cartStore.removeItem(categoryItem.value.id)
    }
  }
}

const goBack = () => {
  navigateTo('/menu')
}

const addItemToCart = (selectedItem) => {
  cartStore.selectItem(selectedItem)
}

categoryItem.value = possibleCategoryItem
</script>

<style scoped lang="scss">
.content {
  padding: 32px 0;
  justify-content: center;
  align-items: center;
  display: flex;
  flex-direction: column;

  .menu-item--image {
    margin-bottom: 40px;
    border-radius: 8px;
    max-width: 350px;
  }

  .menu-item--info {
    background-color: $c-lightwhite;
    border-radius: 8px;
    padding: 20px;

    h2 {
      margin-top: 0;
    }

    .menu-item--allergies {
      padding-bottom: 16px;
      display: flex;
      align-items: flex-end;

      svg {
        max-width: 32px;
        max-height: 32px;
      }
    }

    .menu-item--price {
      margin-bottom: 16px;
    }

    .buttons {
      display: grid;
      grid-template-columns: 83px 83px 83px 1fr;
      grid-gap: 8px;

      .amount {
        background-color: $c-white;
        color: $c-black;
        border-radius: 8px;
        display: grid;
        place-items: center;
      }
    }
  }
}
</style>
