<template>
  <section class="table-manager">
    <h2>Table manager</h2>
    <div class="table-manager--search">
      <FormControlsInput
        label-text="Amount seats"
        :value="tableSeats"
        input-type="number"
        :min="0"
        :max="10"
        @input="handleAmountInput"
      />
      <FormControlsButton text="Reset" type="secondary" @click="reset" />
    </div>
  </section>
</template>

<script setup lang="ts">
import { useTableStore } from '~/store/TableStore'

const store = useTableStore()
const tableSeats = ref(1)

function reset() {
  tableSeats.value = 0
  store.resetSearch()
}

function handleAmountInput(value) {
  store.findAvailableTables(value)
}
</script>

<style scoped lang="scss">
.table-manager {
  margin-bottom: 32px;

  .table-manager--search {
    display: flex;
    gap: 16px;

    .di-button {
      flex: 0;
      align-self: flex-end;
    }
  }
}
</style>
