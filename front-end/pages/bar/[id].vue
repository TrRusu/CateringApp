<template>
  <div class="layout-wrapper">
    <NuxtLayout name="order">
      <template #header>
        <h2>{{ 'Order: ' + order.code }}</h2>

        <FormControlsButton
          class="back-button"
          text="<- Go back"
          type="primary"
          @click="goBack"
        />
      </template>
      <template #content>
        <div class="order-status--category">
          <div class="order-preparing--wrapper">
            <h4>Preparing</h4>
            <div class="order-preparing--container">
              <draggable
                :list="orderItems"
                group="items"
                item-key="id"
                ghost-class="on-drag"
                animation="200"
              >
                <template #item="{ element }">
                  <div class="order-prepare--item">
                    {{ element.amount + ' x ' + element.name }}
                  </div>
                </template>
              </draggable>
            </div>
          </div>
          <div class="order-ready--wrapper">
            <h4>Ready</h4>
            <div class="order-ready--container">
              <draggable
                :list="itemsReady"
                group="items"
                item-key="id"
                ghost-class="on-drag"
                animation="200"
              >
                <template #item="{ element }">
                  <div class="order-ready--item">
                    {{ element.amount + ' x ' + element.name }}
                  </div>
                </template>
              </draggable>
            </div>
          </div>
        </div>
      </template>
    </NuxtLayout>
  </div>
</template>

<script setup lang="ts">
import { useOrderStore } from '~~/store/OrderStore'

import draggable from 'vuedraggable'

const orderStore = useOrderStore()

const order = ref(null)

const itemsReady = ref([])

const route = useRoute()

const orderId = route.params.id

order.value = orderStore.getOrderById(orderId)

definePageMeta({
  layout: false,
})

const orderItems = computed(() => {
  return orderStore.returnItemsList(order.value)
})

const goBack = () => {
  navigateTo('/bar')
}
</script>

<style scoped lang="scss">
.layout-wrapper {
  display: flex;
  flex-direction: column;
  max-width: 1194px;
  margin: 0 auto;
  padding: 40px 30px;
}

h4 {
  text-align: center;
}

.order-preparing--container {
  background-color: $c-lightwhite;
  height: 100%;
  padding: 30px;
}

.order-ready--container {
  background-color: $c-lightwhite;
  height: 100%;
  padding: 30px;
}

.order-status--category {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  column-gap: 30px;
  place-items: center;
}

.order-preparing--wrapper {
  width: 70%;
}

.order-ready--wrapper {
  width: 70%;
  align-self: flex-start;
}

.order-prepare--item {
  padding: 10px 10px;
  margin-bottom: 10px;
  border: 1px solid cornflowerblue;
  background-color: $c-white;
  text-align: center;
}

.order-ready--item {
  padding: 10px 10px;
  margin-bottom: 10px;
  border: 1px solid cornflowerblue;
  background-color: $c-white;
  text-align: center;
}

.on-drag {
  background-color: cornflowerblue;
}

.header-container {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.button-holder {
  align-self: center;
}
</style>
