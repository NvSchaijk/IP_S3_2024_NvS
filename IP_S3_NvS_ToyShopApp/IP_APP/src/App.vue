<template>
  <div id="app">
    <header>
      <div class="title">
        <h1>My Vue App</h1>
      </div>
    </header>
    <div class="main-container">
      <div class="sidebar">
      <router-link class="btn btn-outline-dark btn-lg" :to="{name:'home'}">Home</router-link>
      <router-link class="btn btn-outline-dark btn-lg" :to="{name:'itemcrud'}">Item</router-link>
      <router-link class="btn btn-outline-dark btn-lg" :to="{name:'brandcrud'}">Brand</router-link>
      <router-link class="btn btn-outline-dark btn-lg" :to="{name:'categorycrud'}">Category</router-link>
      <router-link class="btn btn-outline-dark btn-lg" :to="{name:'about'}">About</router-link>
    </div>
    <div class="content">
      <router-view/>
    </div>
  </div>
    </div>
</template>

<script setup>
import {RouterLink, RouterView} from 'vue-router'
</script>