<template>
  <div class="cart-bar">
    <div class="cart-bar--content">
      <div class="counter">
        <span class="count body-large bold">
          {{ cartStore.getAmountSelectedItems() }}
        </span>

        <div class="total-price">
          <span class="body-small bold">Total price</span>
          <span class="price bold">{{ totalPrice }}</span>
        </div>
      </div>

      <div class="buttons">
        <FormControlsButton
          v-show="clientHasOrder"
          text="View all orders"
          type="primary"
          @click="toAllOrders"
        />

        <FormControlsButton
          type="tertiary"
          text="View my order"
          :disabled="!validateCart"
          @click="viewCurrentOrder"
        />
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { useCartStore } from '~/store/CartStore'
import { useOrderStore } from '~/store/OrderStore'

const cartStore = useCartStore()
const orderStore = useOrderStore()
const { $convert } = useNuxtApp()

const totalPrice = computed(() => {
  return $convert(cartStore.totalPrice())
})

const validateCart = computed(() => {
  return cartStore.selectedItems.length > 0
})

const clientHasOrder = computed(() => {
  return orderStore.orders.length > 0
})

const viewCurrentOrder = () => {
  navigateTo('/order/current')
}

const toAllOrders = () => {
  navigateTo('/session')
}
</script>

<style lang="scss">
.cart-bar {
  position: fixed;
  bottom: 0;
  left: 0;
  padding: 20px;
  width: 100%;
  background-color: $c-dark-blue;

  .cart-bar--content {
    max-width: 744px;
    margin: 0 auto;
    padding: 0 30px;
    display: flex;
    justify-content: space-between;
    align-items: center;

    .counter {
      display: flex;
      align-items: center;
      .count {
        width: 40px;
        height: 40px;
        border-radius: 40px;
        display: grid;
        place-items: center;
        background-color: $c-white;
      }

      .total-price {
        margin-left: 16px;
        display: flex;
        flex-direction: column;
        color: $c-white;

        .price {
          font-size: 24px;
          margin-top: 0;
          margin-bottom: 0;
        }
      }
    }

    .buttons {
      display: flex;
      flex-direction: row;
      gap: 8px;
    }
  }
}
</style>
