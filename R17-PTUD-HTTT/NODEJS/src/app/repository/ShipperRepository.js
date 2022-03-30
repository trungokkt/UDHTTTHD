const axios = require("axios");
//
const httpDotNET = "https://localhost:44318/api";
//
const httpasp = "https://localhost:44324/api/shipper/";
const httpjava = "http://localhost:8080/api/shipper/";

const https = require('https');
const httpsAgent = new https.Agent({
    rejectUnauthorized: false,
})
axios.defaults.httpsAgent = httpsAgent
class ShipperRepository {
    async getShipperOrderList(shipperid) {
        const orders = await axios.get(httpasp + shipperid + '/history');
        return orders.data;
    }

    async getorderdetail(orderid) {
        const od = await axios.get(httpasp + orderid + '/orderdetails');
        return od.data;
    }

    async getorderhistory(orderid) {
        const his = await axios.get(httpasp + orderid + '/historystatus');
        return his.data;
    }

    async addOrderHistory(OrderId, OrderStatus, OrderStatusDate) {
        const p = await axios.post(httpjava + 'status/updatestatus',
            { orderid: OrderId, orderStatus: OrderStatus, orderStatusDate: OrderStatusDate });
        return p.data;
    }

    async searchForNewOrder(local) {
        const new_orders = await axios.get(httpjava + 'findorder', {
            params: {
                local: local,
            },
        });
        return new_orders.data;
    }
    async StatisticOrders(shipperid) {
        const statistic_orders = await axios.get(httpasp + 'statistic/' + shipperid);
        return statistic_orders.data;
    }
    async SelectOrder(OrderId, shipperId) {
        const statistic_orders = await axios({
            method: "PUT",
            url: httpDotNET + '/Orders',
            params: {
                OrderId: OrderId,
                shipperId: shipperId
            }
        });
        return statistic_orders.data;
    }
}

module.exports = new ShipperRepository();