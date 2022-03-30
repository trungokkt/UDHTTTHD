using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ptud_httt_doan_api.Model;

namespace ptud_httt_doan_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryOrderStatusController : Controller
    {
        private DatabaseContext _context;

        [HttpGet("orderid")]
        public async Task<IActionResult> GetOrderStatusHistory(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<HistoryOrderStatus> his = _context.HistoryOrderStatus.Where(x => x.orderId == id).ToList();
            if (his == null)
                return NotFound();
            return Ok(his);
        }

        // GET: HistoryorderStatus
        public ActionResult Index()
        {
            return View();
        }

        // GET: HistoryorderStatus/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HistoryorderStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistoryorderStatus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HistoryorderStatus/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistoryorderStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HistoryorderStatus/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistoryorderStatus/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
