<template>
    <v-data-table :headers="headers" :items="stockItems" :items-per-page="5" class="elevation-1"></v-data-table>
</template>

<script>
import * as itemHelper from '../handlers/stockItems'
export default {
    data() {
        return {
            headers: [
                { text: 'Id', value: 'stockItemId', align: 'start' },
                { text: 'Name', value: 'stockItemName' },
                { text: 'Supplier', value: 'supplierId' },
                { text: 'Brand', value: 'brand' },
                { text: 'Price x unit', value: 'unitPrice' },
                { text: 'Retail Price', value: 'recommendedRetailPrice' },
                { text: 'Comments', value: 'marketingComments' },
                { text: 'Photo', value: 'photo' },
                { text: 'Tag', value: 'tags' },
            ],
            stockItems: [
            ],
        }
    },
    methods: {
       GetStockItems(){
            itemHelper.GetStockItems().then(
                (resp)=>{
                    console.log(resp);
                    this.stockItems = resp;
                }
            ).catch((error) => console.log(error));
       } 
    },
    mounted() {
        this.GetStockItems();
    }
    
}
</script>