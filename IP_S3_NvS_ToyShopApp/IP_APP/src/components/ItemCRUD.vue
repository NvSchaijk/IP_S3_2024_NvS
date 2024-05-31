<template>
<h1>Item</h1>
    <table class="styled-table">
        <thead>
            <tr>
            <th>ItemName</th><th>ItemDescription</th><th>Brand</th><th><router-link to="/ItemC" class="btn btn-primary">Create</router-link></th><th></th>
        </tr>
        </thead>
        <tbody v-if="this.posts.length > 0">
            <tr v-for="p in posts" :key="p.ItemID">
                <td>{{ p.ItemName }}</td> 
                <td>{{ p.ItemDescription }}</td> 
                <td>{{ getBrandName(p.BrandID) }}</td>
                <td><router-link :to="'/ItemU/'+p.ItemID" class="btn btn-warning">update</router-link></td>
                <td><button type="button" class="btn btn-danger" @click="DeleteItem(p.ItemID)">Delete</button></td>
            </tr>
        </tbody>
    </table>
</template>

<script>
import api from '@/API/api'
export default{
    data()
    {
        return{
            posts: [],
            brands: [],
        }
    },
    mounted() {
        this.GetItems();
        this.GetBrands();
    },
    methods:{
        GetItems() {
        api.get('Item/GetItems')
            .then(response => {
            this.posts = response.data;
            console.log('Items:', this.posts);
            })
            .catch(err => console.log(err));
        },
        GetBrands() {
        api.get('Brand')
            .then(response => {
            this.brands = response.data;
            console.log('Brands:', this.brands);
            })
            .catch(err => console.log(err));
        },
        getBrandName(brandId) {
            const brand = this.brands.find(b => b.BrandID === brandId);
            console.log('BrandID:', brandId, 'Brand:', brand);
            return brand ? brand.BrandName : 'Unknown';
        },
        DeleteItem(Itemid){
            if (confirm('Are you sure?')) {
                console.log(Itemid)
                api.delete(`Item/${Itemid}`)
                .then(res => this.posts = res.data)
                .catch(err => console.log(err));
            };
        }
        
    }
}

</script>