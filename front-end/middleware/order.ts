import { useCartStore } from '~/store/CartStore'

export default defineNuxtRouteMiddleware(async (to, from) => {
  const store = useCartStore()

  if (store.selectedItems.length === 0) {
    return navigateTo('/menu')
  }
})
