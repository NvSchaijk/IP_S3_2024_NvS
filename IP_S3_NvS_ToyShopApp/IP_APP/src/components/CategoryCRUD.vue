<template>
    <h1>Categories</h1>
    <table>
        <thead>
            <tr>
            <th>CategoryName</th><th>CategoryDescription</th><th><router-link to="/CategoryC" class="btn btn-primary">Create</router-link></th>
        </tr>
        </thead>
        <tbody v-if="this.posts.length > 0">
            <tr v-for="p in posts" :key="p.CategoryID">
                <td>{{ p.CategoryName }}</td> 
                <td>{{ p.CategoryDescription }}</td> 
                <td><router-link :to="'/CategoryU/'+p.BrandID" class="btn btn-warning">update</router-link></td>
                <td><button type="button" class="btn btn-danger" @click="DeleteCategory(p.CategoryID)">Delete</button></td>
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
        this.GetCategories();
    },
    methods:{
        GetCategories(){
            api.get('Category')
        .then(response => this.posts = response.data)
        },
        DeleteCategory(Categoryid){
            if (confirm('Are you sure?')) {
                console.log(Categoryid)
                api.delete(`Category/${Categoryid}`)
                .then(res => this.posts = res.data)
                .catch(err => console.log(err));
            };
        }
        
    }
}

</script>