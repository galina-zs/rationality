using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rationality.Data;
using Rationality.Models;

namespace Rationality.Controllers
{

    public class ProductSnacksController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public ProductSnacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductSnacks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductSnacks.Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductSnacks/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(
                _context.Products
                .Where(x => x.IsSnack == true), 
                "Id", "Name");
            return View();
        }

        // POST: ProductSnacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Amount")] ProductSnack productSnack)
        {
            if (ModelState.IsValid)
            {
    
                _context.Add(productSnack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productSnack.ProductId);
            return View(productSnack);
        }

        // GET: ProductSnacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSnack = await _context.ProductSnacks
                .Include(p => p.Product)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (productSnack == null)
            {
                return NotFound();
            }

            return View(productSnack);
        }

        // POST: ProductSnacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productSnack = await _context.ProductSnacks.SingleOrDefaultAsync(m => m.Id == id);
            _context.ProductSnacks.Remove(productSnack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSnackExists(int id)
        {
            return _context.ProductSnacks.Any(e => e.Id == id);
        }
        
        
    }

}
