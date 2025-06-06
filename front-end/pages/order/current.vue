<template>
  <div>
    <NuxtLayout name="order">
      <template #header>
        <FormControlsButton
          text="<- Go back"
          type="primary"
          @click="goToMenu()"
        />
        <h2>Your current order</h2>
      </template>

      <template #content>
        <div class="current-order">
          <div class="current-order--header">
            <h3 class="bold">
              {{ orderStore.returnItemInfo(cartStore.selectedItems) }}
            </h3>
            <h2>{{ totalPrice }}</h2>
          </div>

          <div
            v-for="item in cartStore.selectedItems"
            v-if="cartStore.selectedItems.length > 0"
            class="selected-item"
          >
            <img :src="item.ImageUrl" :alt="item.Name" />
            <div class="selected-item--info">
              <p class="body-large bold">{{ item.Name }}</p>
              <p class="body-normal">
                {{ $convert(item.amount * item.Price) }}
              </p>

              <div v-if="item.amount > 1" class="buttons">
                <FormControlsButton
                  text="-"
                  type="tertiary"
                  @click="decreaseItemAmount(item)"
                />
                <div class="amount body-large bold">{{ item.amount }}</div>
                <FormControlsButton
                  text="+"
                  type="tertiary"
                  @click="increaseItemAmount(item)"
                />
              </div>

              <div v-else class="remove-item">
                <FormControlsButton
                  text="Remove item"
                  type="secondary"
                  @click="decreaseItemAmount(item)"
                />
              </div>
            </div>
          </div>
        </div>

        <FormControlsButton
          type="secondary"
          text="Place order"
          @click="placeOrder"
        />
      </template>
    </NuxtLayout>
  </div>
</template>

<script lang="ts" setup>
import { useOrderStore } from '~/store/OrderStore'
import { useCartStore } from '~/store/CartStore'
import { definePageMeta } from '#imports'
import {useTableStore} from "~/store/TableStore";
import * as repl from "repl";

definePageMeta({
  middleware: 'order',
})

const orderStore = useOrderStore()
const tableStore = useTableStore()
const cartStore = useCartStore()
const { $convert } = useNuxtApp()
const config = useRuntimeConfig()

const totalPrice = computed(() => {
  return $convert(cartStore.totalPrice())
})

const goToMenu = () => {
  navigateTo('/menu')
}

const increaseItemAmount = (item) => {
  if (item.amount < 11) {
    item.amount = item.amount + 1
  }
}

const decreaseItemAmount = (item) => {
  if (item.amount > 0) {
    item.amount -= 1

    if (item.amount == 0) {
      cartStore.removeItem(item.id)
    }
  }
}

const placeOrder = async () => {
  const items = cartStore.selectedItems.map((item) => {
    return {
      id: item.Id,
      amount: item.amount
    }
  });

  await useFetch(`/order/create?sessionId=${tableStore.currentSession.id}`, {
    body: items,
    baseURL: config.apiBaseUrl,
    method: 'POST',
    headers: {
      ApiKey: config.apiKey
    }
  }).then((response) => {
    orderStore.newOrder(response.data.value)
  })
}
</script>

<style scoped lang="scss">
.current-order {
  padding: 20px;
  background-color: $c-lightwhite;
  border-radius: 8px;
  margin-bottom: 24px;

  .current-order--header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    gap: 16px;
    border-bottom: 1px solid $c-dark-gray;
    padding-bottom: 20px;

    h3,
    h2 {
      margin: 0;
    }
  }

  .selected-item {
    display: flex;
    gap: 32px;
    padding-bottom: 20px;
    padding-top: 20px;
    width: 100%;

    &:not(:last-of-type) {
      border-bottom: 1px solid $c-dark-gray;
    }

    &:last-of-type {
      padding-bottom: 0;
    }

    img {
      max-width: 160px;
      border-radius: 8px;
      max-height: 180px;
    }

    .selected-item--info {
      display: flex;
      flex-direction: column;
      justify-content: center;

      h2 {
        margin-top: 0;
        margin-bottom: 8px;
      }

      p {
        margin-top: 0;
      }

      .remove-item {
        .button {
          width: 100%;
        }
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

  & + .di-button {
    align-self: flex-end;
  }
}
</style>
