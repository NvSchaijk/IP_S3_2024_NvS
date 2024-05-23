<template>
  <h1>Test Text</h1>
  <p>
    Message is: 
    <br> {{ text }}
  </p>
<input v-model="text" placeholder="edit me" />
<p>
    Message is: 
    <br> {{ text2 }}
  </p>
<input v-model="text2" placeholder="edit me" />
<br>

</template>

<script>
import { ref} from "vue";
import {useStorage} from '@vueuse/core'

const text = useStorage('vue-use-local-storage');
const text2 = ref("");

</script>