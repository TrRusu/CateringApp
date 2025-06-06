import { defineStore } from 'pinia'
import {navigateTo, useNuxtApp} from "nuxt/app";
import {useCartStore} from "~/store/CartStore";


export const useOrderStore = defineStore('order', () => {
  const orders = ref([]);
  const cartStore = useCartStore();

  function returnOrderCode(item) {
    return item.code
  }

  function returnOrderTime(item) {
    return item.time
  }

  function returnItemsList(order) {
    return order.items
  }

  function returnItemInfo(items) {
    let itemInfos = ''
    items.forEach((item, index) => {
      itemInfos += item.amount + ' x ' + item.Name
      if (index != items.length - 1) {
        itemInfos += ', '
      }
    })
    return itemInfos
  }

  function calculateTotalPrice(items) {
    let totalPrice = 0

    items.forEach((item) => {
      totalPrice += item.amount * item.Price
    })

    return totalPrice
  }

  function calculateTotalPriceOfOrders() {
    let totalPrice = 0

    orders.value.forEach((order) => {
      order.items.forEach((item) => {
        totalPrice += item.amount * item.Price
      })
    })

    return totalPrice
  }

  function getOrderByCode(code) {
    let potentialOrder = null

    orders.value.forEach((order) => {
      if (order.code === code) {
        potentialOrder = order
      }
    })

    return potentialOrder
  }

  function getOrderById(id) {
    let potentialOrder = null

    orders.value.forEach((order) => {
      if (order.id == id) {
        potentialOrder = order
      }
    })

    return potentialOrder
  }

  const newOrder = (order) => {
    const orderResult = {
      id: order.id,
      code: order.code,
      date: new Date(order.moment),
      price: calculateTotalPrice(cartStore.selectedItems),
      items: cartStore.selectedItems,
      status: order.current_status
    }

    orders.value.push(orderResult)

    navigateTo({ name: 'order-code', params: { code: order.code }})

    cartStore.emptyItems();
  }

  const clearOrders = () => {
    orders.value = [];
    cartStore.emptyItems();
  }

  return {
    orders,

    clearOrders,
    newOrder,
    calculateTotalPriceOfOrders,
    returnItemInfo,
    calculateTotalPrice,
    getOrderByCode,
    getOrderById,
    returnOrderCode,
    returnOrderTime,
    returnItemsList
  }
})
