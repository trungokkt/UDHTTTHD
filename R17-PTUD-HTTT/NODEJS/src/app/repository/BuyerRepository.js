const axios = require("axios");
const https = require("https")
const httpJava = "http://localhost:8081/api/v1";
const httpDotNET = "https://localhost:44318/api";
const OanhJava = "http://localhost:8082"

const httpsAgent = new https.Agent({
    rejectUnauthorized: false,
})
axios.defaults.httpsAgent = httpsAgent
class BuyerRepository {
    //trung
    async getNearbyStore(local) {
        const stores = await axios.get(httpJava + "/stores", {
            params: {
                local: local,
            },
        });
        return stores.data
    }
    async getProductTypeOfStore(storeid) {
        const producttype = await axios.get(httpJava + '/producttype/' + storeid)
        return producttype.data
    }
    async getProductOfStore(storeid) {
        const products = await axios.get(httpJava + '/products', {
            params: {
                storeid: storeid
            }
        })
        return products.data
    }
    async getMyCart(UserId) {
        const cart = await axios.get(httpDotNET + '/carts/' + UserId);
        return cart.data
    }
    async addCartItems(item, userId) {
        const cartItem = await axios({
            method: "POST",
            url: httpDotNET + "/CartItems",
            params: { userId: userId },
            data: { ...item }
        })
        return cartItem.data
    }
    async removeCartItem(cartId, productId, userId) {

        const cartItem = await axios({
            method: "delete",
            url: httpDotNET + "/cartitems",
            params: { cartId: cartId, productId: productId, userId: userId }
        })
        return cartItem.data
    }
    async editCartItem(item, userId) {
        const cartItem = await axios({
            method: "put",
            url: httpDotNET + "/cartitems",
            params: { userId: userId },
            data: { ...item }
        })
        return cartItem.data
    }
    async Order(data) {
        const order = await axios({
            method: "post",
            url: httpDotNET + "/Orders",
            data: { ...data }
        })
        return order.data
    }
    //Oanh
    async getOrdersById(OrderId) {
        const orders = await axios({
            method: "get",
            url: OanhJava + "/api/buyer/order",
            params: { OrderId: OrderId }
        })
        return orders.data
    }
    async getOrders(userid) {
        const orders = await axios({
            method: "get",
            url: httpDotNET + "/Orders",
            params: { userId: userid }
        })
        return orders.data
    }
    async HuyOrder(orderId) {
        var data = {
            "orderStatus": -1,
            "orderid": orderId
        };
        console.log(data)
        const history = await axios({
            method: "post",
            url: OanhJava + "/api/buyer/status/updatestatus",
            data: data
        })
        return history.data
    }
    async postComment(comment, userId, orderId) {
        var now = new Date();
        
        var data = {
            "OrderId": orderId,
            "UserId": userId,
            "Evaluation": comment,
            "EvaluationDate": now,
        };
        const result = await axios({
            method: "post",
            url: httpDotNET + "/OrderEvaluations",
            data: data
        })
        return result.data
    }
}

module.exports = new BuyerRepository();