using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using ptud_httt_doan_api.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ptud_httt_doan_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public OrderItemsController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/<OrderItemsController>
        [HttpGet]
        public IEnumerable<OrderItems> Get()
        {
            return _context.OrderItems;
        }

        // GET api/<OrderItemsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<OrderItems> orderitems = _context.OrderItems.Where(m => m.OrderId == id).ToList();
            if (orderitems == null)
                return NotFound();
            return Ok(orderitems);
        }

        // POST api/<OrderItemsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
