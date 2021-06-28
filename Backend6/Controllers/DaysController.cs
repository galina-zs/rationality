using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rationality.Data;
using Rationality.Models;
using Rationality.Services;

namespace Rationality.Controllers
{
    public class DaysController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserPermissionsService userPermissions;

        public DaysController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IUserPermissionsService userPermissions)
        {
            _context = context;
            this.userManager = userManager;
            this.userPermissions = userPermissions;
        }

        // GET: Days
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var items = _context.Days
                .Include(d => d.Breakfast)
                .Include(d => d.Dinner)
                .Include(d => d.Lunch)
                .Include(d => d.Snack)
                .OrderBy(p => p.Date)
                .SingleOrDefaultAsync(m => m.ApplicationUserId.ToString() == user.Id);
            
            return View(await items);
        }


        // POST: Days
        [HttpPost, ActionName("Index")]
        public async Task<IActionResult> IndexRandom()
        {
            ////////////////////////
            ////////////////////////
            ////////////////////////

            ///    Рандомное генерирование дня   ///

            return this.View();






            //var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            //var items = _context.Days
            //    .Include(d => d.Breakfast)
            //    .Include(d => d.Dinner)
            //    .Include(d => d.Lunch)
            //    .Include(d => d.Snack)
            //    .SingleOrDefaultAsync(m => m.ApplicationUserId.ToString() == user.Id);
            //return View(await items);
        }

        //// GET: Days/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var day = await _context.Days
        //        .Include(d => d.Breakfast)
        //        .Include(d => d.Dinner)
        //        .Include(d => d.Lunch)
        //        .Include(d => d.Snack)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (day == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(day);
        //}

        //// GET: Days/Create
        //public IActionResult Create()
        //{
        //    ViewData["BreakfastId"] = new SelectList(_context.Recipes, "Id", "Id");
        //    ViewData["DinnerId"] = new SelectList(_context.Recipes, "Id", "Id");
        //    ViewData["LunchId"] = new SelectList(_context.Recipes, "Id", "Id");
        //    ViewData["SnackId"] = new SelectList(_context.Snacks, "Id", "Id");
        //    return View();
        //}

        //// POST: Days/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Date,ApplicationUserId,SnackId,BreakfastId,LunchId,DinnerId")] Day day)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(day);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["BreakfastId"] = new SelectList(_context.Recipes, "Id", "Id", day.BreakfastId);
        //    ViewData["DinnerId"] = new SelectList(_context.Recipes, "Id", "Id", day.DinnerId);
        //    ViewData["LunchId"] = new SelectList(_context.Recipes, "Id", "Id", day.LunchId);
        //    ViewData["SnackId"] = new SelectList(_context.Snacks, "Id", "Id", day.SnackId);
        //    return View(day);
        //}

        //// GET: Days/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var day = await _context.Days.SingleOrDefaultAsync(m => m.Id == id);
        //    if (day == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["BreakfastId"] = new SelectList(_context.Recipes, "Id", "Id", day.BreakfastId);
        //    ViewData["DinnerId"] = new SelectList(_context.Recipes, "Id", "Id", day.DinnerId);
        //    ViewData["LunchId"] = new SelectList(_context.Recipes, "Id", "Id", day.LunchId);
        //    ViewData["SnackId"] = new SelectList(_context.Snacks, "Id", "Id", day.SnackId);
        //    return View(day);
        //}

        //// POST: Days/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Date,ApplicationUserId,SnackId,BreakfastId,LunchId,DinnerId")] Day day)
        //{
        //    if (id != day.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(day);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DayExists(day.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["BreakfastId"] = new SelectList(_context.Recipes, "Id", "Id", day.BreakfastId);
        //    ViewData["DinnerId"] = new SelectList(_context.Recipes, "Id", "Id", day.DinnerId);
        //    ViewData["LunchId"] = new SelectList(_context.Recipes, "Id", "Id", day.LunchId);
        //    ViewData["SnackId"] = new SelectList(_context.Snacks, "Id", "Id", day.SnackId);
        //    return View(day);
        //}

        //// GET: Days/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var day = await _context.Days
        //        .Include(d => d.Breakfast)
        //        .Include(d => d.Dinner)
        //        .Include(d => d.Lunch)
        //        .Include(d => d.Snack)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (day == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(day);
        //}

        //// POST: Days/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var day = await _context.Days.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Days.Remove(day);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DayExists(int id)
        //{
        //    return _context.Days.Any(e => e.Id == id);
        //}
        
    }
}
