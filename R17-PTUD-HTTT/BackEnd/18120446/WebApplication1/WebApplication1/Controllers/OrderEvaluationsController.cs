using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entity;

namespace WebApplication1.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrderEvaluationsController : ControllerBase
    {
        private readonly OrderEvaluationContext _context;

        public OrderEvaluationsController(OrderEvaluationContext context)
        {
            _context = context;
        }

        // GET: api/OrderEvaluations
        [HttpGet]
        public IEnumerable<OrderEvaluation> GetOrderEvaluation()
        {
            return _context.OrderEvaluation.ToList();
        }

        // GET: api/OrderEvaluations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderEvaluation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderEvaluation = await _context.OrderEvaluation.FindAsync(id);

            if (orderEvaluation == null)
            {
                return NotFound();
            }

            return Ok(orderEvaluation);
        }

        // PUT: api/OrderEvaluations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderEvaluation([FromRoute] int id, [FromBody] OrderEvaluation orderEvaluation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderEvaluation.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderEvaluation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderEvaluationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderEvaluations
        [HttpPost]
        public async Task<IActionResult> PostOrderEvaluation([FromBody] OrderEvaluation orderEvaluation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderEvaluation.Add(orderEvaluation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderEvaluation", new { id = orderEvaluation.OrderId }, orderEvaluation);
        }

        // DELETE: api/OrderEvaluations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderEvaluation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderEvaluation = await _context.OrderEvaluation.FindAsync(id);
            if (orderEvaluation == null)
            {
                return NotFound();
            }

            _context.OrderEvaluation.Remove(orderEvaluation);
            await _context.SaveChangesAsync();

            return Ok(orderEvaluation);
        }

        private bool OrderEvaluationExists(int id)
        {
            return _context.OrderEvaluation.Any(e => e.OrderId == id);
        }
    }
}