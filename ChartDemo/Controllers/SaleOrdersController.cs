using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChartDemo.Models;

namespace ChartDemo.Controllers
{
    public class SaleOrdersController : Controller
    {
        private readonly MyDbContext _context;

        public SaleOrdersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: SaleOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.SaleOrder.ToListAsync());
        }

        // GET: SaleOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder
                .FirstOrDefaultAsync(m => m.Sale_id == id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            return View(saleOrder);
        }

        // GET: SaleOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sale_id,Zone,Sale_Amount")] SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleOrder);
        }

        // GET: SaleOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder.FindAsync(id);
            if (saleOrder == null)
            {
                return NotFound();
            }
            return View(saleOrder);
        }

        // POST: SaleOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sale_id,Zone,Sale_Amount")] SaleOrder saleOrder)
        {
            if (id != saleOrder.Sale_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleOrderExists(saleOrder.Sale_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(saleOrder);
        }

        // GET: SaleOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder
                .FirstOrDefaultAsync(m => m.Sale_id == id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            return View(saleOrder);
        }

        // POST: SaleOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleOrder = await _context.SaleOrder.FindAsync(id);
            _context.SaleOrder.Remove(saleOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleOrderExists(int id)
        {
            return _context.SaleOrder.Any(e => e.Sale_id == id);
        }
    }
}
