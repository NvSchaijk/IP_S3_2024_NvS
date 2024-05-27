<template>
  <HelloWorld msg="this is very cool" />
<br/>
  <BrandCRUD />
  <br/>
  <CategoryCRUD/>
  <br/>
  <Test />
  <!-- <CRUDS crud="{{cruds}}"/> -->
</template>

<script setup>
import Test from '@/components/Test.vue';
import BrandCRUD from '@/components/BrandCRUD.vue';
import CategoryCRUD from '@/components/CategoryCRUD.vue';
import { ref } from 'vue';
let cruds = ref();
</script>
