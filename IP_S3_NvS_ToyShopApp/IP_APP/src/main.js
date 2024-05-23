import { createApp } from 'vue'
import App from '@/App.vue'
import router from '@/plugins/router'
import '@/style.css'
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

createApp(App).use(router).mount('#app')
