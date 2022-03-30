using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DICHOTHUEAPI.Models;

namespace DICHOTHUEAPI.FactModels
{
    public class ModelFactory
    {
        public CartModel Create(Cart cart)
        {
            return new CartModel()
            {
                CartId = cart.CartId,
                UserId = cart.UserId,
                CartQuantity = cart.CartQuantity,
                CartPrice = cart.CartPrice,
                CartItems = cart.CartItems.Select(s => Create(s)).ToList()
            };
        }
        public CartItemsModel Create(CartItems cartItems)
        {
            return new CartItemsModel()
            {
                CartId = cartItems.CartId,
                ProductId = cartItems.ProductId,
                CartItemPrice = cartItems.CartItemPrice,
                CartItemQuantity = cartItems.CartItemQuantity,
                Product = Create(cartItems.Product)
            };
        }
        public ProductModel Create(Product product)
        {
            return new ProductModel()
            {
                ProductId = product.ProductId,
                ProductDescription = product.ProductDescription,
                ProductImage = product.ProductImage,
                ProductInventory = product.ProductInventory,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductTypeId = product.ProductTypeId,
                ProductUnit = product.ProductUnit,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate,
                ProductType = Create(product.ProductType)
            };
        }
        public ProductTypeModel Create(ProductType productType)
        {
            return new ProductTypeModel()
            {
                ProductTypeId = productType.ProductTypeId,
                ProductTypeName = productType.ProductTypeName,
                StoreId = productType.StoreId,
                Store = Create(productType.Store)
            };
        }
        public StoreModel Create(Store store)
        {
            return new StoreModel()
            {
                StoreId = store.StoreId,
                StoreAddress = store.StoreAddress,
                StoreArea = store.StoreArea,
                StoreImg = store.StoreImg,
                StoreLat = store.StoreLat,
                StoreLng = store.StoreLng,
                StoreName = store.StoreName,
                StorePhone = store.StorePhone,
                StoreRate = store.StoreRate,
                UserId = store.UserId
            };
        }
        public OrdersModel Create(Orders orders)
        {
            return new OrdersModel()
            {
                OrderId = orders.OrderId,
                BuyerId = orders.BuyerId,
                OrderPhone = orders.OrderPhone,
                OrderAddress = orders.OrderAddress,
                OrderQuantity = orders.OrderQuantity,
                OrderPrice = orders.OrderPrice,
                DeliveryMoney = orders.DeliveryMoney,
                PaymentType = orders.PaymentType,
                PaymentStatus = orders.PaymentStatus,
                ShipperId = orders.ShipperId,
                HistoryOrderStatus = orders.HistoryOrderStatus.Select(s => Create(s)).ToList(),
                OrderItems = orders.OrderItems.Select(s => Create(s)).ToList()
            };
        }
        public OrderItemsModel Create(OrderItems orderItems)
        {
            return new OrderItemsModel()
            {
                OrderId = orderItems.OrderId,
                ProductId = orderItems.ProductId,
                OrderItemDiscount = orderItems.OrderItemDiscount,
                OrderItemPrice = orderItems.OrderItemPrice,
                OrderItemQuantity = orderItems.OrderItemQuantity,
                Product = Create(orderItems.Product),
            };
        }
        public HistoryOrderStatusModel Create(HistoryOrderStatus historyOrderStatus)
        {
            return new HistoryOrderStatusModel()
            {
                OrderId = historyOrderStatus.OrderId,
                HistoryId = historyOrderStatus.HistoryId,
                OrderStatus = historyOrderStatus.OrderStatus,
                OrderStatusDate = historyOrderStatus.OrderStatusDate,
                OrderStatusNavigation = Create(historyOrderStatus.OrderStatusNavigation)
            };
        }
        public StatusModel Create(Status status)
        {
            return new StatusModel()
            {
                Code = status.Code,
                Lable = status.Lable
            };
        }
        public OrderEvaluationModel Create(OrderEvaluation orderEvaluation)
        {
            return new OrderEvaluationModel()
            {
                OrderId = orderEvaluation.OrderId,
                Evaluation = orderEvaluation.Evaluation,
                EvaluationDate = orderEvaluation.EvaluationDate,
                UserId = orderEvaluation.UserId
            };
        }
    }
}
