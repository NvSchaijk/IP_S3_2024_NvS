<template>
 <Test v-if="crud = '0'"/>
<br/>
  <BrandCRUD v-if="crud == '1'"/>
  <br/>
  <CategoryCRUD v-if="crud == '2'"/>
</template>

<script setup>
import Test from '@/components/Test.vue';
import BrandCRUD from '@/components/BrandCRUD.vue';
import CategoryCRUD from '@/components/CategoryCRUD.vue';
defineProps({
  crud: String,
})
</script>