<template>
  <div class="layout-wrapper">
    <NuxtLayout name="order">
      <template #header>
        <h2>Received orders</h2>
      </template>
      <template #content>
        <div class="order-results">
          <div v-show="false" class="order-results--rows">
            <div v-for="order in store.orders" class="order-result--row">
              <ul class="order-results--info">
                <li class="results-row--value">
                  {{ store.returnOrderCode(order) }}
                </li>
                <h4>{{ store.returnOrderTime(order) }}</h4>
                <FormControlsButton
                  text="Prepare order"
                  type="primary"
                  @click="goToBarOrderPage(order.id)"
                />
              </ul>
              <div v-if="order.id != store.orders.length">
                <hr />
              </div>
            </div>
          </div>
          <div class="hello">
            <h1>hey</h1>
            <FormControlsButton text="send message" @click="sendMessage()"></FormControlsButton>
          </div>
        </div>
      </template>
    </NuxtLayout>
  </div>
</template>

<script setup lang="ts">
import { useOrderStore } from '~/store/OrderStore'

const store = useOrderStore()
const runtimeConfig = useRuntimeConfig();

const router = useRouter()

const goToBarOrderPage = (id) => {
  router.push(`/bar/${id}`)
}

const connection = new WebSocket('wss://' + runtimeConfig.apiBaseUrl + '/order/ws/kitchen');

connection.onopen = () => {
  connection.send(JSON.stringify({ key: runtimeConfig.apiKey }))
}

connection.onmessage = (e) => {
  console.log(JSON.parse(e.data))
}

const sendMessage = () => {
  connection.send(JSON.stringify(store.orders))
}

const closeConnection = () => {
  connection.close()
}

onBeforeUnmount(() => { closeConnection() })

definePageMeta({
  layout: false,
})
</script>

<style scoped lang="scss">
.order-results {
  padding: 0 40px;
}

.layout-wrapper {
  display: flex;
  flex-direction: column;
  max-width: 1194px;
  margin: 0 auto;
  padding: 40px 30px;
}

.results-row--value {
  display: flex;
  align-items: center;
  font-size: large;
  font-weight: normal;
}

h4 {
  font-size: medium;
  font-weight: normal;
}

.order-results--row {
  width: 100%;
}

.order-results--info {
  display: flex;
  width: 100%;
  justify-content: space-between;
}

.order-results {
  background-color: $c-lightwhite;
}

.button-holder {
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
