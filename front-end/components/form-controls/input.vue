<template>
  <div class="di-input">
    <label class="di-input--label body-small bold"> {{ labelText }}</label>
    <input
      class="di-input--field body-normal"
      :value="value"
      :type="inputType"
      :min="min"
      :max="max"
      @input="handleInput"
    />
  </div>
</template>

<script setup>
const props = defineProps({
  value: {
    type: [String, Number],
    default: null,
    required: false,
  },
  labelText: {
    type: String,
    default: 'This is the label text',
    required: true,
  },

  inputType: {
    type: String,
    default: 'text',
    required: false,
  },

  placeholderText: {
    type: String,
    default: 'text',
    required: false,
  },

  min: {
    type: Number,
    default: null,
    required: false,
  },

  max: {
    type: Number,
    default: null,
    required: false,
  },
})

const emit = defineEmits(['input'])

function handleInput(event) {
  emit('input', event.target.value)
}
</script>

<style lang="scss" scoped>
.di-input {
  display: flex;
  flex-direction: column;

  .di-input--label {
    margin-bottom: 8px;
  }

  .di-input--field {
    padding: 19px 21px;
    background-color: $c-lightwhite;
    border-radius: 8px;
    border: none;
    font-family: 'Manrope', sans-serif;
  }
}
</style>
