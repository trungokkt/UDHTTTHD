using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ptud_httt_doan_api.Model;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ptud_httt_doan_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public ShipperController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/<ShipperController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}/history")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<Orders> order = _context.Orders.Where(m => m.ShipperId == id).OrderByDescending(x => x.OrderDate).ToList();
            
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        // GET api/<OrderItemsController>/5
        [HttpGet("{id1}/orderdetails")]
        public async Task<IActionResult> GetOrderDetailsForShipper(int id1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<OrderItems> orderitems = _context.OrderItems.Where(x => x.OrderId == id1).ToList();
            List<Product> products = _context.Product.ToList();

            var innerjoin = from orderitem in orderitems join prod in products on orderitem.ProductId equals prod.ProductId select new CombinedModel_OrderItems_Products { OrderId = orderitem.OrderId, ProductName= prod.ProductName, OrderItemDiscount = orderitem.OrderItemDiscount, OrderItemPrice = orderitem.OrderItemPrice, OrderItemQuantity = orderitem.OrderItemQuantity};

            return Ok(innerjoin);
        }

        [HttpGet("{id}/historystatus")]
        public async Task<IActionResult> getOrderStatusHistory(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<HistoryOrderStatus> his = _context.HistoryOrderStatus.Where(x => x.orderId == id).ToList();

            var toview = from h in his select new historyorderstatus_convert { orderId = h.orderId, OrderStatusDate = h.OrderStatusDate, OrderStatus = (h.OrderStatus == 0) ? "đang tới cửa hàng" : (h.OrderStatus == 1) ? "đang giao hàng" : "đã nhận"};

            return Ok(toview);
        }
        [HttpGet("statistic/{id}")]
        public async Task<IActionResult> getShipperOrderStatistic(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<Orders> order = _context.Orders.Where(x => x.ShipperId == id).ToList();

            var result = order.Select(k => new { k.OrderDate.Month, k.OrderDate.Year, k.OrderPrice }).GroupBy(x => new { x.Year, x.Month }, (key, group) => new
            {
                year = key.Year,
                month = key.Month,
                sum = group.Sum(k => k.OrderPrice)
            });
            return Ok(result);
        }
        // POST api/<ShipperController>
        [HttpPost("SelectOrder")]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/<ShipperController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
