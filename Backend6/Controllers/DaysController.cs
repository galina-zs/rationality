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
        private readonly INutritionForUserService nutritionForUserService;
        private readonly IGenerateWeekService generateWeekService;

        public DaysController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IUserPermissionsService userPermissions,
            INutritionForUserService nutritionForUserService,
            IGenerateWeekService generateWeekService)
        {
            _context = context;
            this.userManager = userManager;
            this.userPermissions = userPermissions;
            this.nutritionForUserService = nutritionForUserService;
            this.generateWeekService = generateWeekService;
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
                .SingleOrDefaultAsync(m => m.ApplicationUserId == user.Id);

            if (items.Result == null)
            {
                List<Day> week = generateWeekService.GenerateWeek(user, nutritionForUserService.GetNutritionForUser(user));
            }

            return View(await items);
        }


        // POST: Days
        [HttpPost, ActionName("Index")]
        public async Task<IActionResult> IndexRandom()
        {

            return this.View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateWeek()
        {

            return this.View();


        }
        
    }
}
