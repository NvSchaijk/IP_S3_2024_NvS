import { createRouter, createWebHistory } from "vue-router";

const routes = [
        {
            path:'/',
            name:'dashboard',
            component: () => import('@/views/DashBoard.vue')
        },
        {
            path:'/Home',
            name:'home',
            component: () => import('@/views/Homeview.vue')
        },
        {
            path:'/About',
            name:'about',
            component: () => import('@/views/About.vue')
        },
        {
            path:'/BrandCRUD',
            name:'brandcrud',
            component: () => import('@/components/BrandCRUD.vue')
        },
        {
            path:'/BrandC',
            name:'brandc',
            component: () => import('@/components/BrandCRUD/BrandC.vue')
        },
        {
            path:'/BrandU/:id',
            name:'brandu',
            component: () => import('@/components/BrandCRUD/BrandU.vue')
        },

        {
            path:'/CategoryCRUD',
            name:'categorycrud',
            component: () => import('@/components/CategoryCRUD.vue')
        },
        {
            path:'/CategoryC',
            name:'categoryc',
            component: () => import('@/components/CategoryCRUD/CategoryC.vue')
        },
        {
            path:'/CategoryU/:id',
            name:'categoryu',
            component: () => import('@/components/CategoryCRUD/CategoryU.vue')
        },

        {
            path:'/ItemCRUD',
            name:'itemcrud',
            component: () => import('@/components/ItemCRUD.vue')
        },
        {
            path:'/ItemC',
            name:'itemc',
            component: () => import('@/components/ItemCRUD/ItemC.vue')
        },
        {
            path:'/ItemU/:id',
            name:'itemu',
            component: () => import('@/components/ItemCRUD/ItemU.vue')
        }
]

const router = createRouter({
    routes,
    history: createWebHistory(),
})

export default router