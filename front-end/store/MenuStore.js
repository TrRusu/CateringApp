import { defineStore } from 'pinia'

export const useMenuStore = defineStore('menu', () => {
  const menuItems = ref([])

  const selectedCategory = ref(null)

  const setMenuItems = (menus) => {
    let mappedItems = menus.map((menu) => {
      return {
        ...menu,
        items: menu.items.map((item) => {
          return {
            ...item,
            amount: 0
          }
        })
      }
    })

    menuItems.value = mappedItems;
    selectedCategory.value = mappedItems[0]
  }

  const selectCategory = (categoryId) => {
    selectedCategory.value = menuItems.value.find((category) => {
      return category.id == categoryId
    })
  }

  const getCategoryItem = (categoryItemId) => {
    return selectedCategory.value.items.find((item) => {
      return item.Id == categoryItemId
    })
  }

  return { menuItems, selectedCategory, setMenuItems, selectCategory, getCategoryItem }
})
