<template>
  <div class="layout-wrapper">
    <NuxtLayout name="order">
      <template #header>
        <h2>Received orders for kitchen</h2>
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
                :sort="false"
                @start="startMove"
              >
                <template #item="{ element }">
                  <div class="order-prepare--item" :style="{ border: `3px solid ${element.color}`}">
                    <h5>Order: #{{ element.orderName }}</h5>
                    <p>{{ element.name }} x {{ element.amount }}</p>
                  </div>
                </template>
              </draggable>
            </div>
          </div>
          <div class="order-cooking--wrapper">
            <h4>Cooking</h4>
            <div class="order-cooking--container">
              <draggable
                :list="itemsCooking"
                group="items"
                item-key="id"
                ghost-class="on-drag"
                animation="200"
                @change="addedOrderPreparing"
                :sort="false"
              >
                <template #item="{ element }">
                  <div class="order-cooking--item" :style="{ border: `3px solid ${element.color}`}">
                    <h5>Order: #{{ element.orderName }}</h5>
                    <p>{{ element.name }} x {{ element.amount }}</p>
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
                @change="addedOrderDone"
                :sort="false"
              >
                <template #item="{ element }">
                  <div class="order-ready--item" :style="{ border: `3px solid ${element.color}`}">
                    <h5>Order: #{{ element.orderName }}</h5>
                    <p>{{ element.name }} x {{ element.amount }}</p>
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
import draggable from 'vuedraggable'
import {clearInterval} from "timers";

const config = useRuntimeConfig()
const itemsCooking = ref([])
const itemsReady = ref([])
const orderItems = ref([])
const stopRefresh = ref(false)
const interval = ref(null);

const { data, refresh } = await useFetch(`order/get-orderitemlist-today`,
  {
    baseURL: config.apiBaseUrl,
    method: 'GET',
    headers: {
      ApiKey: config.apiKey
    }
})

const updateOrderItems = () => {
  if (!stopRefresh.value) {
    refresh()
  }
}

const getBackgroundColor = (stringInput) => {
  let stringUniqueHash = [...stringInput].reduce((acc, char) => {
    return char.charCodeAt(0) + ((acc << 5) - acc);
  }, 0);
  return `hsl(${stringUniqueHash % 360}, 95%, 35%)`;
}

const addedOrderPreparing = async (evt) => {
  if ('added' in evt) {
    const orderItem = evt.added.element;
    await useFetch(`order/update-orderitem-status`,
    {
      baseURL: config.apiBaseUrl,
      method: 'POST',
      params: {
        orderID: orderItem.orderId,
        itemID: orderItem.itemId,
        status: 1
      },
      headers: {
        ApiKey: config.apiKey
      }
    })

    stopRefresh.value = false
  }

  return false
}


const addedOrderDone = async (evt) => {
  if ('added' in evt) {
    const orderItem = evt.added.element;
    await useFetch(`order/update-orderitem-status`,
      {
        baseURL: config.apiBaseUrl,
        method: 'POST',
        params: {
          orderID: orderItem.orderId,
          itemID: orderItem.itemId,
          status: 2
        },
        headers: {
          ApiKey: config.apiKey
        }
      })

    stopRefresh.value = false
  }

  return false
}

const startMove = () => {
  stopRefresh.value = true
}

watch(
  () => data.value,
  (newOrders, _) => {
    const itemsC = []
    const itemsR = []
    const itemsP = []

    newOrders.forEach((order) => {
      const color = getBackgroundColor(order.Name)
      order.ItemOrders.forEach((orderItem) => {
        const newOrderItem = {
          orderId: order.ID,
          itemId: orderItem.ItemId,
          name: orderItem.Item.Name,
          orderName: order.Name,
          amount: orderItem.Amount,
          status: orderItem.Status,
          color: color
        }

        if (newOrderItem.status === 1) {
          itemsC.push(newOrderItem)
        } else if (newOrderItem.status === 2) {
          itemsR.push(newOrderItem)
        } else {
          itemsP.push(newOrderItem)
        }
      })

      itemsCooking.value = itemsC
      itemsReady.value = itemsR
      orderItems.value = itemsP
    })
  }
)

onMounted(() => {
  interval.value = setInterval(updateOrderItems, 5000)
})
</script>

<style scoped lang="scss">
h4 {
  text-align: center;
}

.order-preparing--container {
  background-color: $c-lightwhite;
  height: 100%;
  padding: 30px;
}

.order-cooking--container {
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
  grid-template-columns: repeat(3, 1fr);
  column-gap: 30px;
}

.order-preparing--wrapper {
  width: 100%;
}

.order-prepare--item,
.order-cooking--item,
.order-ready--item {
  padding: 10px 10px;
  margin-bottom: 10px;
  border: 1px solid cornflowerblue;
  background-color: $c-white;
  text-align: left;
  line-height: 24px;
  h5 {
    text-align: left;
    margin: 0;
    margin-bottom: 8px;
  }

  p {
    margin: 0;
  }
}



.on-drag {
  background-color: cornflowerblue;
}

.header-container {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}
</style>
