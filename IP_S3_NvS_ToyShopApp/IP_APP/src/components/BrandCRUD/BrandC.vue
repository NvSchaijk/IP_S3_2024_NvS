<template>
    <h1>Create page</h1>
    <table>
        <tr>
            <th>Brand name</th> <th>Brand Description</th>
        </tr>
        <tr>
            <td><input type="text" v-model="brand.brandName"></td> 
            <td> <input type="text" v-model="brand.brandDescription"></td>
        </tr>
        <tr>
            <td>
                <button @click="createBrand(brand)">Create Brand</button>
            </td>
        </tr>
    </table>
</template>

<script>
import api from '@/API/api.js'
export default{
    data(){
        return{
            brand: {
                brandName: '',
                brandDescription: ''
            }
        }
    },
    methods: {
        createBrand(newbrand)
        {
            if (confirm('Are you sure?')) {
                console.log(newbrand)
                api.post(`Brand/`,newbrand)
                .then(res => [this.posts = res.data, this.$router.push({name: 'home'})])
                .catch(err => console.log(err));
            };
        }
    }
}
</script>