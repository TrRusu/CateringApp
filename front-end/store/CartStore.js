import { defineStore } from 'pinia'

export const useCartStore = defineStore('cart', () => {
  const selectedItems = ref([])

  const getAmountSelectedItems = () => {
    let amount = 0

    selectedItems.value.forEach((item) => {
      amount += item.amount
    })

    return amount
  }

  const totalPrice = () => {
    let amount = 0

    selectedItems.value.forEach((item) => {
      amount += item.Price * item.amount
    })

    return amount
  }

  const selectItem = (item) => {
    // first check if there's an item that's already added.
    const selectedItem = selectedItems.value.find((x) => {
      return x.Id === item.Id
    })

    if (selectedItem) {
      selectedItem.amount = item.amount
    } else {
      selectedItems.value.push(item)
    }
  }

  const removeItem = (removeItemId) => {
    selectedItems.value = selectedItems.value.filter(
      (selectedItem) => selectedItem.id !== removeItemId
    )
  }

  const emptyItems = () => {
    selectedItems.value = []
  }

  return {
    selectedItems,

    removeItem,
    selectItem,
    totalPrice,
    emptyItems,
    getAmountSelectedItems,
  }
})
