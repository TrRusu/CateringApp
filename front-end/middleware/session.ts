import { useTableStore } from '~/store/TableStore'

export default defineNuxtRouteMiddleware(async (to, from) => {
  const store = useTableStore()

  if (store.currentSession === null) {
    return navigateTo('/')
  }
})
