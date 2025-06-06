<template>
  <div>
    <NuxtLayout name="order">
      <template #header>
        <FormControlsButton
          text="<- Go back"
          type="primary"
          @click="goToMenu()"
        />
      </template>

      <template #content v-if="order">
        <h2>Order {{ code }}</h2>
        <div class="order-information">
          <div class="order-information--header">
            <h3 class="bold">
              {{ orderStore.returnItemInfo(order.items) }}
            </h3>
            <h2>{{ $convert(order.price) }}</h2>
          </div>

          <div class="date">{{ order.moment }}</div>

          <hr>

          <div class="order-progress">
            <div class="order-state" v-for="(state, index) in status" :class="[{'active': order.status === index}]">
              <span class="progress"></span>
              <span class="body-small">{{ state }}</span>
            </div>
          </div>
        </div>
      </template>
    </NuxtLayout>
  </div>
</template>

<script lang="ts" setup>
import {useOrderStore} from "~/store/OrderStore";

const status = ref(['Preparing', 'Cooking', 'Ready'])

const orderStore = useOrderStore()
const route = useRoute()
const code = route.params.code
const order = ref(null)

const goToMenu = () => {
  navigateTo('/menu')
}

if (code) {
  const possibleOrder = orderStore.getOrderByCode(code)

  if (possibleOrder) {
    order.value = possibleOrder
  } else {
    goToMenu()
  }
} else {
  goToMenu()
}
</script>

<style scoped lang="scss">
.order-information {
  padding: 20px;
  background-color: $c-lightwhite;
  border-radius: 8px;
  margin-bottom: 24px;

  .order-information--header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    gap: 16px;

    h3,
    h2 {
      margin: 0;
    }
  }

  .date {
    margin-bottom: 20px;
  }

  .order-progress {
    display: grid;
    margin: 0 auto;
    grid-template-columns: repeat(3, 42px);
    grid-gap: 140px;
    place-items: center;
    justify-content: center;

    .order-state {
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      position: relative;

      &.active {
        .progress {
          border: 2px solid $c-dark-blue;
          background-color: $c-blue;
        }
      }

      &.done {
        .progress {
          border: 2px solid $c-dark-blue;
          background-color: $c-dark-blue;
        }
      }

      &:not(:last-of-type)::after {
        position: absolute;
        top: 30%;
        right: -106px;
        content: "";
        width: 100px;
        border: 2px dashed $c-dark-blue;
      }

      .progress {
        width: 42px;
        height: 42px;
        display: block;
        border-radius: 42px;
        background-color: $c-white;
      }
    }
  }
}
</style>
