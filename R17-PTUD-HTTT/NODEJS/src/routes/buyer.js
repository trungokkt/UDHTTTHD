const express = require('express');
const router = express.Router();

const buyerController = require('../app/controllers/BuyerController')
const Authenticated = require('../app/controllers/Authenticated')
//define route
router.get('/', Authenticated.checkNotAuthenticatedShipper, buyerController.showHome);
router.get('/store-detail/:storeid', Authenticated.checkAuthenticated, Authenticated.checkNotAuthenticatedShipper, buyerController.showShopDetail);
router.get('/checkout', Authenticated.checkAuthenticated, Authenticated.checkNotAuthenticatedShipper, buyerController.showCheckOut)
router.get('/user', Authenticated.checkAuthenticated, Authenticated.checkNotAuthenticatedShipper, buyerController.showUser)
router.post('/api/stores', Authenticated.checkNotAuthenticatedShipper, buyerController.getStoreNear)
router.post('/api/carts', Authenticated.checkNotAuthenticatedShipper, buyerController.getMyCart)
router.post('/api/cartitems', Authenticated.checkAuthenticated, Authenticated.checkNotAuthenticatedShipper, buyerController.addCartItem)
router.put('/api/cartitems', Authenticated.checkAuthenticated, Authenticated.checkNotAuthenticatedShipper, buyerController.editCartItem)
router.delete('/api/cartitems', Authenticated.checkAuthenticated, Authenticated.checkNotAuthenticatedShipper, buyerController.removeCartItem)
router.post('/api/order', Authenticated.checkAuthenticated, Authenticated.checkNotAuthenticatedShipper, buyerController.Order)
router.post('/api/order/huy', Authenticated.checkAuthenticated, Authenticated.checkNotAuthenticatedShipper, buyerController.HuyOrder)
router.post('/api/order/postcomment', Authenticated.checkAuthenticated, Authenticated.checkNotAuthenticatedShipper, buyerController.postComment)
router.get('/404', buyerController.show404)

//
router.get('/user/order', Authenticated.checkAuthenticated, Authenticated.checkNotAuthenticatedShipper, buyerController.showUserOrder)

module.exports = router;