<template>
    <h1>Create page</h1>
    <table>
        <tr>
            <th>Category name</th> <th>Category Description</th>
        </tr>
        <tr>
            <td><input type="text" v-model="category.categoryName"></td> 
            <td> <input type="text" v-model="category.categoryDescription"></td>
        </tr>
        <tr>
            <td>
                <button @click="createCategory(category)">Create category</button>
            </td>
        </tr>
    </table>
</template>

<script>
import api from '@/API/api.js'
export default{
    data(){
        return{
            category: {
                categoryName: '',
                categoryDescription: ''
            }
        }
    },
    methods: {
        createCategory(newcategory)
        {
            if (confirm('Are you sure?')) {
                console.log(newcategory)
                api.post(`Category/`,newcategory)
                .then(res => [this.posts = res.data, this.$router.push({name: 'home'})])
                .catch(err => console.log(err));
            };
        }
    }
}
</script>