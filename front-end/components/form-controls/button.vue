<template>
  <button
    class="di-button body-large bold"
    :disabled="disabled"
    :class="[type, { disabled: disabled }]"
    @click="handleClick"
  >
    {{ text }}
  </button>
</template>

<script setup>
const props = defineProps({
  text: {
    type: String,
    default: 'Button',
    required: true,
  },
  type: {
    type: String,
    default: 'primary',
    required: false,
  },
  disabled: {
    type: Boolean,
    default: false,
    required: false,
  },
})

const emit = defineEmits(['click'])

function handleClick() {
  if (!props.disabled) {
    emit('click')
  }
}
</script>

<style lang="scss" scoped>
.di-button {
  text-align: center;
  border-radius: 8px;
  font-family: 'Manrope', sans-serif;
  border: none;
  border-radius: 8px;
  display: block;
  padding: 18px 32px;
  cursor: pointer;

  &.secondary {
    background-color: $c-dark-blue;
    color: $c-white;
  }

  &.primary {
    background-color: $c-blue;
    color: $c-white;
  }

  &.tertiary {
    background-color: $c-white;
    color: $c-black;
  }

  &.disabled {
    cursor: not-allowed;
    background-color: $c-lightgrey;
    color: $c-dark-gray;
  }
}
</style>
