<template>
  <h1>{{ msg }}</h1>
  <div class="card">
    <p> count is {{ count }} </p> <br>
    <button type="button" @click="count++">++</button>
    <button type="button" @click="count--">--</button>
  </div>
<p></p>
</template>

<script setup>
import { ref } from 'vue'

defineProps({
  msg: String,
})

const count = ref(0)
</script>
