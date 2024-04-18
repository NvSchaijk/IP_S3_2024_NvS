<template>
    <h1>Categories</h1>
    <table>
        <thead>
            <tr>
            <th>CategoryName</th><th>CategoryDescription</th>
        </tr>
        </thead>
        <tbody>
            <tr v-for="p in posts" :key="p.id">
                <td>{{ p.CategoryName }}</td> <td>{{ p.CategoryDescription }}</td>
            </tr>
        </tbody>
    </table>
</template>

<script>
import api from '../API/api'
export default{
    data()
    {
        return{
            posts: []
        }
    },
    mounted() {
        api.get('Category')
        .then(response => this.posts = response.data)
    },
}

</script>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>