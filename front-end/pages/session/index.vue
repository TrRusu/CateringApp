<template>
  <div>
    <NuxtLayout name="order">
      <template #header>
        <FormControlsButton text="<- Go back" type="primary" @click="goBack" />

        <h2>Your orders</h2>
      </template>

      <template #content>
        <div v-if="store.orders.length > 0" class="order-results--rows">
          <div v-for="order in store.orders" class="order-result--row">
            <h2>{{ 'Order ' + order.code }}</h2>
            <p>{{ store.returnItemInfo(order.items) }}</p>

            <div class="order-pricedate--row">
              <h4>{{ $date(order.date) }}</h4>
              <h4 class="order-totalprice">{{ $convert(order.price) }}</h4>
            </div>
            <hr />
          </div>

          <div class="order-total--row">
            <h4>Total price:</h4>
            <h2>{{ $convert(store.calculateTotalPriceOfOrders()) }}</h2>
          </div>
        </div>

        <div class="button-holder">
          <FormControlsButton @click="paySession()" class="pay-button" text="Pay" type="secondary" />
        </div>
      </template>
    </NuxtLayout>
  </div>
</template>

<script setup lang="ts">
import {definePageMeta} from "#imports";

definePageMeta({
  middleware: 'session',
})

import { useOrderStore } from '~/store/OrderStore'
import {useTableStore} from "~/store/TableStore";
import {useCartStore} from "~/store/CartStore";

const store = useOrderStore()
const tableStore = useTableStore()
const { $convert } = useNuxtApp()
const config = useRuntimeConfig()

const goBack = () => {
  navigateTo('/menu')
}

const paySession = async () => {
  await useFetch(`/session/close?sessionId=${tableStore.currentSession.id}`,
    {
      baseURL: config.apiBaseUrl,
      method: 'PUT',
      headers: {
        ApiKey: config.apiKey
      }
    }).then((response) => {
      store.clearOrders();
      tableStore.endSession();

      navigateTo('/')
  })
}
</script>

<style lang="scss">
.order-results--rows {
  background-color: $c-lightwhite;
  padding: 20px 32px;
  justify-content: center;
  align-items: center;
  display: flex;
  flex-direction: column;
  border-radius: 8px;
  margin-bottom: 40px;

  .order-result--row {
    width: 100%;

    h2 {
      margin-bottom: 8px;
    }

    p {
      margin-bottom: 0;
    }
  }

  .order-total--row {
    background-color: $c-lightwhite;
    padding: 12px 0;
    align-items: center;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    width: 100%;

    h2, h4 {
      margin: 0;
    }
  }

  .order-pricedate--row {
    width: 100%;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
  }

  h3 {
    font-size: medium;
    font-weight: normal;
  }

  hr {
    background-color: black;
  }
}

.button-holder {
  display: flex;
  justify-content: center;
  align-items: center;
  align-self: flex-end;

  .pay-button {
    width: 244px;
  }
}
</style>
