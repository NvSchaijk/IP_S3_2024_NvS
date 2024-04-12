<template>
    <h1>Brands</h1>
    <table>
        <thead>
            <tr>
            <th>BrandName</th><th>BrandDescription</th>
        </tr>
        </thead>
        <tbody>
            <tr v-for="p in posts" :key="p.id">
                <td>{{ p.BrandName }}</td> <td>{{ p.BrandDescription }}</td>
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
        api.get('Brand')
        .then(response => this.posts = response.data)
    },
}

</script>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>