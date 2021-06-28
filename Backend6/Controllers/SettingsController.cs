using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rationality.Data;
using Rationality.Models;
using Rationality.Models.ViewModels;
using Rationality.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserPermissionsService userPermissions;

        public SettingsController (ApplicationDbContext context, UserManager<ApplicationUser> userManager, IUserPermissionsService userPermissions)
        {
            this.context = context;
            this.userManager = userManager;
            this.userPermissions = userPermissions;
        }
        // GET: SettingsController
        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var model = new SettingsViewModel { 
                UserName = user.UserName,
                Email = user.Email,
                Age = user.Age,
                Weight = user.Weight,
                Height = user.Height,
                Goal = user.Goal,
                PhysicalActivity = user.Activity,
                MoneyPerWeek = user.MoneyPerMonth
            };
            return View(model);
        }

        // GET: SettingsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SettingsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SettingsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInfo(SettingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await this.userManager.GetUserAsync(this.HttpContext.User);
                user.Gender = model.Gender;
                user.Email = model.Email;
                user.Activity = model.PhysicalActivity;
                user.Age = model.Age;
                user.Height = model.Height;
                user.Weight = model.Weight;
                user.Goal = model.Goal;
                user.MoneyPerMonth = model.MoneyPerWeek;
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: SettingsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SettingsController/Edit/5
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

        // GET: SettingsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SettingsController/Delete/5
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
