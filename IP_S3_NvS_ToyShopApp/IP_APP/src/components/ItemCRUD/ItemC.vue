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
            <td> <input type="text" v-model="item.brandID"></td>
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
                itemID: 0,
                brandID: 0,
                itemName: "",
                itemDescription: "",
                itemPrice: 0,
                itemQuantity: 0,
                itemQuantitySold: 0
            }
        }
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
        }
    }
}
</script>