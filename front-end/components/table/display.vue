<template>
  <div class="table-results">
    <ul v-if="store.filteredTables.length > 0" class="table-results--headers">
      <li class="table-header body-small bold">Name</li>
      <li class="table-header body-small bold">Amount</li>
      <li class="table-header body-small bold">Status</li>
    </ul>

    <div v-if="store.filteredTables.length > 0" class="table-results--rows">
      <div
        v-for="table in store.filteredTables"
        :key="table.id"
        class="table-result--row"
      >
        <ul class="table-result--info">
          <li class="result-row--value body-normal">
            {{ table.name }}
          </li>

          <li class="result-row--value body-normal">{{ table.seats }} seats</li>

          <li class="result-row--value body-normal">
            {{ table.status }}
          </li>
        </ul>

        <FormControlsButton
          type="primary"
          text="Assign table"
          @click="selectTable(table.id)"
        />
      </div>
    </div>

    <div v-else>
      <h3>No tables were found.</h3>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { useTableStore } from '~/store/TableStore'

const config = useRuntimeConfig()
const store = useTableStore()
const router = useRouter()

const selectTable = (tableId: Number) => {
  useFetch(`/session/start?tableId=${tableId}`, {
    baseURL: config.apiBaseUrl,
    method: 'POST',
    headers: {
      Accept: '*/*',
      ApiKey: config.apiKey
    }
  }).then((response) => {
    const session = response.data.value;

    store.startSession(session)
    router.push({ path: '/menu' })
  })
};
</script>

<style scoped lang="scss">
.table-results {
  .table-results--headers {
    list-style-type: none;
    display: inline-grid;
    grid-template-columns: repeat(3, 1fr);
    padding-left: 20px;
    grid-gap: 100px;
    margin-bottom: 8px;
  }

  .table-results--rows {
    .table-result--row {
      display: grid;
      grid-template-columns: 1fr auto;
      grid-gap: 16px;

      .table-result--info {
        list-style-type: none;
        background-color: $c-lightgrey;
        display: grid;
        grid-template-columns: 1fr 1fr 1fr;
        grid-gap: 16px;
        margin: 0 0 16px 0;
        padding: 20px 18px 18px 20px;
        border-radius: 8px;

        .result-row--value {
          min-width: 60px;
        }
      }

      .di-button {
        align-self: flex-start;
      }
    }
  }
}
</style>
