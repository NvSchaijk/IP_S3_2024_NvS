<template>
<h1>Item</h1>
    <table>
        <thead>
            <tr>
            <th>ItemName</th><th>ItemDescription</th><th><router-link to="/ItemC" class="btn btn-primary">Create</router-link></th>
        </tr>
        </thead>
        <tbody v-if="this.posts.length > 0">
            <tr v-for="p in posts" :key="p.ItemID">
                <td>{{ p.ItemName }}</td> 
                <td>{{ p.ItemDescription }}</td> 
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
            posts: []
        }
    },
    mounted() {
        this.GetItems();
    },
    methods:{
        GetItems(){
            api.get('Item/GetItems')
        .then(response => this.posts = response.data)
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

<style scoped>
.read-the-docs {
  color: #888;
}
</style>