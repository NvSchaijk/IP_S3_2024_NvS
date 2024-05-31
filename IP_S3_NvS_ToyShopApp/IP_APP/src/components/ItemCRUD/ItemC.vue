<template>
    <h1>Create page</h1>
    <table>
        <tr>
            <th>Item name</th> <th>Item Description</th>
        </tr>
        <tr>
            <td><input type="text" v-model="item.itemName"></td> 
            <td> <input type="text" v-model="item.itemDescription"></td>
        </tr>
        <tr>
            <th>Item Price</th> <th>Item Brand</th>
        </tr>
        <tr>
            <td><input type="text" v-model="item.itemPrice"></td> 
            <td>
                <select v-model="item.brandID">
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
            <td><input type="text" v-model="item.itemQuantity"></td> 
            <td> <input type="text" v-model="item.itemQuantitySold"></td>
        </tr>
        <tr>
            <td>
                <button @click="createItem(item)">Create item</button>
            </td>
        </tr>
    </table>
</template>

<script>
import api from '@/API/api.js'
export default{
    data(){
        return{
            item: {
                brandID: null,
                itemName: "",
                itemDescription: "",
                itemPrice: null,
                itemQuantity: null,
                itemQuantitySold: null
            },
            brands: []
        }
    },
    mounted()
    {
        this.GetBrands();
    },
    methods: {
        createItem(newitem)
        {
            if (confirm('Are you sure?')) {
                console.log(newitem)
                api.post(`Item/`,newitem)
                .then(res => [this.posts = res.data, this.$router.push({name: 'itemcrud'})])
                .catch(err => console.log(err));
            };
        },
        GetBrands()
        {
            api.get(`Brand`)
            .then(response => [this.brands = response.data, console.log(response.data)])
        },
    }
}
</script>