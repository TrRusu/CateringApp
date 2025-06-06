<template>
  <div>
    <slot name="header">
      <FormControlsButton disabled text="<- Log out" type="primary" />
    </slot>

    <slot name="content">
      <TableSearch />
      <hr />
      <TableDisplay v-if="!pending" />
      <h3 v-else>Loading tables...</h3>
    </slot>
  </div>
</template>

<script lang="ts" setup>
import {useTableStore} from "~/store/TableStore";

const store = useTableStore()
const config = useRuntimeConfig()

const { data, pending } = useFetch('/table/all', {
  baseURL: config.apiBaseUrl,
  method: 'GET'
})

watchEffect(() => {
  if (pending.value) {
    if (data.value != null) {
      store.setTables(data.value)
    }
  }
})

</script>

<style lang="scss" scoped>
.display {
  display: block;
}
</style>
