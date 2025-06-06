import { defineStore } from 'pinia'

export const useTableStore = defineStore('table', () => {
  const tables = ref([])
  const currentSession = ref(null)
  const selectedTableItems = ref([])
  const tableSeats = ref([])

  const filteredTables = ref([])

  const findAvailableTables = amount => {
    filteredTables.value = tables.value.filter((table) => {
      if (table.seats == amount) {
        return table
      }
    })
  };

  const resetSearch = () => {
    tableSeats.value = null
    filteredTables.value = tables.value
  };

  const startSession = table => {
    currentSession.value = table
  };

  const getCurrentTable = () => {
    return tables.value.find((table) => {
      if (table.id == currentSession.value.table_id) return table.name
    })
  }
  const setTables = (tablesData) => {
    let transformedTables = ref(tablesData.map((table) => {
      return {
        id: table.Id,
        name: table.Name,
        seats: table.amount_seats,
        status: table.Status,
      }
    }))

    let transformed_tables = ref(transformedTables.value.filter((table) => {
      return table.status === 0
    }))

    filteredTables.value = transformed_tables.value
    tables.value = transformed_tables.value
  };

  const endSession = () => {
    currentSession.value = null
  };

  return {
    tables,
    currentSession,
    selectedTableItems,
    filteredTables,
    startSession,
    endSession,
    findAvailableTables,
    resetSearch,
    setTables,
    getCurrentTable,
  }
})
