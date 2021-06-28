using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rationality.Models;
using Rationality.Models.AccountViewModels;
using Microsoft.AspNetCore.Authentication;

namespace Rationality.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILoggerFactory loggerFactory)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = loggerFactory.CreateLogger<AccountController>();
        }

        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(String returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            this.ViewData["ReturnUrl"] = returnUrl;
            return this.View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, String returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            if (this.ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    this.logger.LogInformation(1, "User logged in.");
                    return this.RedirectToLocal(returnUrl);
                }

                if (result.IsLockedOut)
                {
                    this.logger.LogWarning(2, "User account locked out.");
                    return this.View("Lockout");
                }

                this.ModelState.AddModelError(String.Empty, "Invalid login attempt.");
                return this.View(model);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        // GET: /Account/RegisterEmail
        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterEmail(String returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            return this.View("RegisterEmail");
        }

        // POST: /Account/RegisterEmail
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterEmail(RegisterEmailViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var bodyParametersViewModel = new RegisterBodyParametersViewModel
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password
                };

                return this.View("RegisterBodyParameters", bodyParametersViewModel);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        // GET: /Account/RegisterBodyParameters
        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterBodyParameters(RegisterBodyParametersViewModel model)
        {
            this.ViewBag.Gender = Enum.GetValues(typeof(Gender));
            this.ViewBag.Activity = Enum.GetValues(typeof(PhysicalActivity));
            this.ViewBag.Goal = Enum.GetValues(typeof(Goal));
            return this.View("RegisterBodyParameters", model);
        }

        // POST: /Account/RegisterBodyParameters
        [HttpPost, ActionName("RegisterBodyParameters")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterBodyParametersConfirm(RegisterBodyParametersViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var moneyViewModel = new RegisterMoneyViewModel
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    Age = model.Age,
                    Gender = model.Gender,
                    Weight = model.Weight,
                    Goal = model.Goal,
                    Activity = model.Activity,
                    Height = model.Height
                };

                return this.View("RegisterMoney", moneyViewModel);
            }

            // If we got this far, something failed, redisplay form
            return this.View("RegisterBodyParameters", model);
        }

        // GET: /Account/RegisterMoney
        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterMoney(RegisterMoneyViewModel model)
        {
            return this.View("RegisterBodyParameters", model);
        }

        // POST: /Account/RegisterMoney
        [HttpPost, ActionName("RegisterMoney")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterMoneyConfirm(RegisterMoneyViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Age = model.Age,
                    Gender = model.Gender,
                    Weight = model.Weight,
                    Goal = model.Goal,
                    Activity = model.Activity,
                    MoneyPerMonth = model.MoneyPerMonth,
                    Height = model.Height
                };
                var result = await this.userManager.CreateAsync(user, model.Password);
                var res = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: false);
                return this.RedirectToAction("Index", "Mockups");
                if (result.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    this.logger.LogInformation(3, "User created a new account with password.");
                    return this.RedirectToAction("Index", "Mockups");
                }
                this.AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return this.View("RegisterMoney", model);
        }



        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            this.logger.LogInformation(4, "User logged out.");
            return this.Redirect("/");
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(String.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(String returnUrl)
        {
            if (this.Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }
            else
            {
                return this.Redirect("/");
            }
        }

        #endregion
    }
}
