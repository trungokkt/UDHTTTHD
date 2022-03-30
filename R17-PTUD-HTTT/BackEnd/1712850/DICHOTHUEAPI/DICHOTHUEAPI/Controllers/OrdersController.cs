using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DICHOTHUEAPI.Models;
using DICHOTHUEAPI.FactModels;

namespace DICHOTHUEAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly QuanLyDiChoThueContext db;
        private readonly ModelFactory _modelFactory = new ModelFactory();
        public OrdersController(QuanLyDiChoThueContext context)
        {
            db = context;
        }

        // GET: api/Orders
        // get Order
        [HttpGet]
        public IActionResult GetOrders([FromQuery] int userId)
        {
            // check dữ liệu vào userId
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // select tất cả hớa đơn theo OrderId desc (mới nhất)
            var orders = db.Orders.Where(s => s.BuyerId == userId).OrderByDescending(s=> s.OrderId).ToList();
            //null thì không có hoá đơn
            if (orders == null)
            {
                return NotFound();
            }
            //trả kết quả
            return Ok(orders.Select(s=> _modelFactory.Create(s)));
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult PostOrders([FromBody] Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Orders newOrder = new Orders()
                    {
                        OrderQuantity = orders.OrderQuantity,
                        OrderPrice = orders.OrderPrice,
                        OrderDate = DateTime.Now,
                        OrderCode = "DH" + DateTime.Now.ToString("yyyymmddhhmmss") + orders.BuyerId,
                        OrderAddress = orders.OrderAddress,
                        OrderPhone = orders.OrderPhone,
                        BuyerId = orders.BuyerId,
                        DeliveryMoney = 15000,
                        PaymentType = "Tiền Mặt",
                        PaymentStatus = 0,
                    };
                    db.Orders.Add(newOrder);
                    db.SaveChanges();

                    foreach (OrderItems orderItems in orders.OrderItems)
                    {
                        OrderItems newOrderItems = new OrderItems()
                        {
                            OrderId = newOrder.OrderId,
                            ProductId = orderItems.ProductId,
                            OrderItemDiscount = orderItems.OrderItemDiscount,
                            OrderItemPrice = orderItems.OrderItemPrice,
                            OrderItemQuantity = orderItems.OrderItemQuantity,
                        };
                        db.OrderItems.Add(newOrderItems);
                        db.SaveChanges();
                    }

                    transaction.Commit();
                    Orders resultOrder = new Orders()
                    {
                        OrderId = newOrder.OrderId,
                        OrderQuantity = orders.OrderQuantity,
                        OrderPrice = orders.OrderPrice,
                        OrderAddress = orders.OrderAddress,
                        OrderPhone = orders.OrderPhone,
                        BuyerId = orders.BuyerId
                    };
                    return Ok(resultOrder);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error occurred.");
                    return BadRequest();
                }
            }
        }


        // Put: api/Orders
        [HttpPut]
        public IActionResult PutOrders(int OrderId, int shipperId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Orders orders =  db.Orders.Where(s => s.OrderId == OrderId).FirstOrDefault();
                    orders.ShipperId = shipperId;
                    db.SaveChanges();
                    transaction.Commit();

                    return Ok( _modelFactory.Create(orders));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error occurred.");
                    return BadRequest();
                }
            }
        }


        private bool OrdersExists(int id)
        {
            return db.Orders.Any(e => e.OrderId == id);
        }
    }
}