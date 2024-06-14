<template>
    <h1>Update page</h1>
    <table>
        <tr>
            <th>Item name</th> <th>Item Description</th>
        </tr>
        <tr>
            <td><input type="text" v-model="item.ItemName"></td> 
            <td> <input type="text" v-model="item.ItemDescription"></td>
        </tr>
        <tr>
            <th>Item Price</th> <th>Item Brand</th>
        </tr>
        <tr>
            <td><input type="text" v-model="item.ItemPrice"></td>
            <td>
                <select v-model="item.BrandID">
                    <option v-for="brand in brands" :key="brand.BrandID" :value="brand.BrandID">
                        {{ brand.BrandName }}
                    </option>
                </select>
            </td>
        </tr>
        <tr>
            <th>Item Quantity</th> <th>Item QuantitySold</th>
        </tr>
        <tr>
            <td><input type="text" v-model="item.ItemQuantity"></td> 
            <td> <input type="text" v-model="item.ItemQuantitySold"></td>
        </tr>
        <tr>
            <td>
                <button class="btn btn-warning" @click="updateItem(item)">Update Item</button>
            </td>
        </tr>
    </table>
</template>

<script>
import api from '@/API/api.js'
export default{
    data(){
        return{
            item: [],
            brands: []
        }
    },
    mounted()
    {
        this.GetItem(this.$route.params.id);
        this.GetBrands();
        console.warn(this.$route.params.id);
    },
    methods: {
        GetItem(id)
        {
            api.get(`Item/${id}`)
            .then(response => [this.item = response.data, console.log(response.data)])
        },
        GetBrands()
        {
            api.get(`Brand`)
            .then(response => [this.brands = response.data, console.log(response.data)])
        },
        updateItem(newitem)
        {
            if (confirm('Are you sure?')) {
                console.log(newitem)
                api.patch(`Item/`, newitem)
                .then(res => [this.posts = res.data, this.$router.push({name: 'itemcrud'})])
                .catch(err => console.log(err));
            };
        }
    }
}
</script>