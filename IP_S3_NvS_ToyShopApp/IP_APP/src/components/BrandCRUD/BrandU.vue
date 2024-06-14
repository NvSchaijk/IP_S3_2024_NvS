<template>
    <h1>Update page</h1>
<table>
    <tr>
        <th>Brand name</th> <th>Brand Description</th>
    </tr>
    <tr>
        <td><input type="text" v-model="brand.BrandName"></td> 
        <td> <input type="text" v-model="brand.BrandDescription"></td>
    </tr>
    <tr>
        <td>
            <button class="btn btn-warning" @click="updateBrand(brand)">Update Brand</button>
        </td>
    </tr>
</table>
</template>

<script>
import api from '@/API/api.js'
export default{
    data(){
        return{
            brand: []
        }
    },
    mounted()
    {
        this.GetBrand(this.$route.params.id)
        console.warn(this.$route.params.id)
    },
    methods: {
        GetBrand(id)
        {
            api.get(`Brand/${id}`)
            .then(response => [this.brand = response.data, console.log(response.data)])
        },
        updateBrand(newbrand)
        {
            if (confirm('Are you sure?')) {
                console.log(newbrand)
                api.patch(`Brand/`, newbrand)
                .then(res => [this.posts = res.data, this.$router.push({name: 'home'})])
                .catch(err => console.log(err));
            };
        }
    }
}
</script>