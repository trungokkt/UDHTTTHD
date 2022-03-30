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
    public class OrderEvaluationsController : ControllerBase
    {
        private readonly QuanLyDiChoThueContext _context;
        private readonly ModelFactory _modelFactory = new ModelFactory();

        public OrderEvaluationsController(QuanLyDiChoThueContext context)
        {
            _context = context;
        }

        // POST: api/OrderEvaluations
        // đăng bài dánh giá
        [HttpPost]
        public async Task<IActionResult> PostOrderEvaluation([FromBody] OrderEvaluation orderEvaluation)
        {
            //Kiểm tra dữ liệu đúng chưa
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Thêm bài đánh giá
            _context.OrderEvaluation.Add(orderEvaluation);
            try
            {
                //save vào trong data
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                //xử lý lỗi
                if (OrderEvaluationExists(orderEvaluation.OrderId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            //trả kết quả
            return Ok(_modelFactory.Create(orderEvaluation));
        }

        private bool OrderEvaluationExists(int id)
        {
            return _context.OrderEvaluation.Any(e => e.OrderId == id);
        }
    }
}