<template>
    <div class="dashboard">
      <h1>DashBoard</h1>
      <br>
      <br>
      <div class="tables-container">
        <div class="table-wrapper">
          <h2>Best Selling</h2>
          <table class="styled-table">
            <thead>
              <tr>
                <th>ItemName</th>
                <th>ItemDescription</th>
                <th>QuantitySold</th>
              </tr>
            </thead>
            <tbody v-if="BestSelling.length > 0">
              <tr v-for="bs in BestSelling" :key="bs.ItemID">
                <td>{{ bs.ItemName }}</td>
                <td>{{ bs.ItemDescription }}</td>
                <td>{{ bs.ItemQuantitySold }}</td>
              </tr>
            </tbody>
          </table>
        </div>
        <div class="table-wrapper">
          <h2>Worst Selling</h2>
          <table class="styled-table">
            <thead>
              <tr>
                <th>ItemName</th>
                <th>ItemDescription</th>
                <th>QuantitySold</th>
              </tr>
            </thead>
            <tbody v-if="WorstSelling.length > 0">
              <tr v-for="ws in WorstSelling" :key="ws.ItemID">
                <td>{{ ws.ItemName }}</td>
                <td>{{ ws.ItemDescription }}</td>
                <td>{{ ws.ItemQuantitySold }}</td>
              </tr>
            </tbody>
          </table>
        </div>
        <div class="table-wrapper">
          <h2>Best Profit</h2>
          <table class="styled-table">
            <thead>
              <tr>
                <th>ItemName</th>
                <th>ItemDescription</th>
                <th>Total Profit</th>
              </tr>
            </thead>
            <tbody v-if="BestProfit.length > 0">
              <tr v-for="bp in BestProfit" :key="bp.ItemID">
                <td>{{ bp.ItemName }}</td>
                <td>{{ bp.ItemDescription }}</td>
                <td> $ {{ bp.Totalprofit }}</td>
              </tr>
            </tbody>
          </table>
        </div>
        <div class="table-wrapper">
          <h2>Worst Profit</h2>
          <table class="styled-table">
            <thead>
              <tr>
                <th>ItemName</th>
                <th>ItemDescription</th>
                <th>Total Profit</th>
              </tr>
            </thead>
            <tbody v-if="WorstProfit.length > 0">
              <tr v-for="wp in WorstProfit" :key="wp.ItemID">
                <td>{{ wp.ItemName }}</td>
                <td>{{ wp.ItemDescription }}</td>
                <td>$ {{ wp.Totalprofit }}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </template>

<script>
import api from '@/API/api'
export default{
  data() {
    return {
      BestSelling: [],
      WorstSelling: [],
      BestProfit: [],
      WorstProfit: []
    };
  },
  async mounted() {
    await this.GetBestSelling();
    await this.GetWorstSelling();
    await this.GetBestProfit();
    await this.GetWorstProfit();
  },
  methods: {
    async GetBestSelling() {
      try {
        const response = await api.get('/DashBoard/BestSelling');
        this.BestSelling = response.data;
        console.log('BestSelling:', this.BestSelling);
      } catch (err) {
        console.log(err);
      }
    },
    async GetWorstSelling() {
      try {
        const response = await api.get('/DashBoard/WorstSelling');
        this.WorstSelling = response.data;
        console.log('WorstSelling:', this.WorstSelling);
      } catch (err) {
        console.log(err);
      }
    },
    async GetBestProfit() {
      try {
        const response = await api.get('/DashBoard/BestProfit');
        this.BestProfit = response.data;
        console.log('BestProfit:', this.BestProfit);
      } catch (err) {
        console.log(err);
      }
    },
    async GetWorstProfit() {
      try {
        const response = await api.get('/DashBoard/WorstProfit');
        this.WorstProfit = response.data;
        console.log('WorstProfit:', this.WorstProfit);
      } catch (err) {
        console.log(err);
      }
    }
  }
}
</script>