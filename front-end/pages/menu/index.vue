<template>
  <div>
    <NuxtLayout name="order">
      <template #header>
        <h2>Table: {{ table.name }}</h2>
      </template>

      <template #content>
        <MenuBar />
        <MenuDisplay />
      </template>

      <template #footer>
        <CartBar />
      </template>
    </NuxtLayout>
  </div>
</template>

<script setup lang="ts">
import { definePageMeta } from '#imports'

definePageMeta({
  middleware: 'session',
})

import { useMenuStore } from '~/store/MenuStore';
import {useTableStore} from "~/store/TableStore";

const store = useMenuStore()
const tableStore = useTableStore()
const config = useRuntimeConfig()

const table = ref(tableStore.getCurrentTable());

if (store.menuItems.length === 0) {
  const { data, pending } = useFetch('/item/all', {
    baseURL: config.apiBaseUrl,
    method: 'GET'
  })

  watchEffect(() => {
    if (pending.value) {
      if (data.value != null) {
        store.setMenuItems(data.value)
      }
    }
  })
}
</script>
