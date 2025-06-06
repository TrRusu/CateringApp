<template>
  <div class="menu-item" @click="goToItemPage(id)">
    <div
      class="menu-item--image"
      :style="{ backgroundImage: `url('${image}')` }"
    />
    <div class="menu-item--info">
      <h3 class="body-normal bold">{{ name }}</h3>
      <p class="body-normal">{{ description }}</p>

      <div class="menu-price">
        <div class="menu-item--allergies">
          <IconAllergieNoGluten />
          <IconAllergieNoMilk />
          <IconAllergieNoStroller />
        </div>

        <p class="body-large bold">{{ $convert(price) }}</p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
defineProps({
  id: Number,
  image: String,
  name: String,
  description: String,
  allergies: Array,
  price: Number,
})

const { $convert } = useNuxtApp()

const router = useRouter()

const goToItemPage = (id) => {
  router.push(`/menu/${id}`)
}
</script>

<style scoped lang="scss">
.menu-item {
  overflow: hidden;
  border-radius: 8px;
  background-color: $c-lightwhite;
  cursor: pointer;

  .menu-item--image {
    background-position: center;
    background-size: cover;
    padding-bottom: 200px;
  }

  .menu-item--info {
    padding: 0px 20px;

    p {
      display: -webkit-box;
      -webkit-line-clamp: 2;
      -webkit-box-orient: vertical;
      text-overflow: ellipsis;
      word-wrap: break-word;
      overflow: hidden;
      max-height: 2.8rem;
      line-height: 1.4rem;
    }
  }

  .menu-price {
    display: flex;
    justify-content: space-between;

    .menu-item--allergies {
      padding-bottom: 16px;
      display: flex;
      align-items: flex-end;

      svg {
        max-width: 32px;
        max-height: 32px;
      }
    }
  }
}
</style>
