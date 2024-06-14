<template>
    <h1>Update page</h1>
<table>
    <tr>
        <th>Category name</th> <th>Category Description</th>
    </tr>
    <tr>
        <td><input type="text" v-model="category.CategoryName"></td> 
        <td> <input type="text" v-model="category.CategoryDescription"></td>
    </tr>
    <tr>
        <td>
            <button class="btn btn-warning" @click="updateCategory(Category)">Update Category</button>
        </td>
    </tr>
</table>
</template>

<script>
import api from '@/API/api.js'
export default{
    data(){
        return{
            category: []
        }
    },
    mounted()
    {
        this.GetCategory(this.$route.params.id)
        console.warn(this.$route.params.id)
    },
    methods: {
        GetCategory(id)
        {
            api.get(`Category/${id}`)
            .then(response => [this.category = response.data, console.log(response.data)])
        },
        updateCategory(newcategory)
        {
            if (confirm('Are you sure?')) {
                console.log(newcategory)
                api.patch(`Category/`, newcategory)
                .then(res => [this.posts = res.data, this.$router.push({name: 'home'})])
                .catch(err => console.log(err));
            };
        }
    }
}
</script>