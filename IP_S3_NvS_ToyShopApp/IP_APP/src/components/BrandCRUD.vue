<template>
    <h1>Brands</h1>
    <table>
        <thead>
            <tr>
            <th>BrandName</th><th>BrandDescription</th><th><router-link to="/BrandC" class="btn btn-primary">Create</router-link></th>
        </tr>
        </thead>
        <tbody v-if="this.posts.length > 0">
            <tr v-for="p in posts" :key="p.BrandID">
                <td>{{ p.BrandName }}</td> 
                <td>{{ p.BrandDescription }}</td> 
                <td><router-link :to="'/BrandU/'+p.BrandID" class="btn btn-warning">update</router-link></td>
                <td><button type="button" class="btn btn-danger" @click="DeleteBrand(p.BrandID)">Delete</button></td>
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
        this.GetBrands();
    },
    methods:{
        GetBrands(){
            api.get('Brand')
        .then(response => this.posts = response.data)
        },
        DeleteBrand(Brandid){
            if (confirm('Are you sure?')) {
                console.log(Brandid)
                api.delete(`Brand/${Brandid}`)
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