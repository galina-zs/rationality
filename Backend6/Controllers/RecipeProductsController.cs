﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rationality.Data;
using Rationality.Models;
using Rationality.Models.ViewModels;

namespace Rationality.Controllers
{
    public class RecipeProductsController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public RecipeProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecipeProducts
        public async Task<IActionResult> Index(int? recipeId)
        {
            if(recipeId == null)
            {
                return this.NotFound();
            }

            var recipe = await this._context.Recipes
                .SingleOrDefaultAsync(x => x.Id == recipeId);

            if (recipe == null)
            {
                return this.NotFound();
            }

            var items = await this._context.RecipeProducts
                .Include(h => h.Recipe)
                .Include(h => h.Product)
                .Where(x => x.RecipeId== recipe.Id)
                .ToListAsync();

            this.ViewBag.Recipe = recipe;
            return View(items);
        }

        // GET: RecipeProducts/Create
        public async Task<IActionResult> Create(int? recipeId)
        {
            if(recipeId == null)
            {
                return NotFound();
            }

            var recipe = await this._context.Recipes
                .SingleOrDefaultAsync(x => x.Id == recipeId);

            if (recipe == null)
            {
                return this.NotFound();
            }

            this.ViewBag.Recipe = recipe;
            this.ViewData["ProductId"] = new SelectList(
                this._context.Products
                .Where(x => x.IsSnack == false),
                "Id", "Name");
            return this.View(new RecipeProductsCreateModel());
        }

        // POST: RecipeProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? recipeId, RecipeProductsCreateModel model)
        {
            if (recipeId == null)
            {
                return NotFound();
            }

            var recipe = await this._context.Recipes
                .SingleOrDefaultAsync(x => x.Id == recipeId);

            if (recipe == null)
            {
                return this.NotFound();
            }
            var product = await _context.Products
                    .SingleOrDefaultAsync(x => x.Id == model.ProductId);
            if (ModelState.IsValid)
            {
                var recipeProduct = new RecipeProduct { 
                    ProductId = model.ProductId,
                    RecipeId = recipe.Id,
                    Unit = product.Unit,
                    Amount = model.Amount
                };


                recipe.Kcal += product.Kcal * (int)model.Amount;
                recipe.Proteins += product.Proteins * (int)model.Amount;
                recipe.Fats += product.Fats * (int)model.Amount;
                recipe.Carbohydrates += product.Carbohydrates * (int)model.Amount;
                recipe.Price += product.Price * model.Amount;
                _context.Update(recipe);

                _context.Add(recipeProduct);
                await _context.SaveChangesAsync();
                return this.RedirectToAction("Index", new { recipeId = recipe.Id });
            }
            return View(model);
        }

        // GET: RecipeProducts/Delete/5
        public async Task<IActionResult> Delete(int? recipeId, int? productId)
        {
            if (recipeId == null || productId == null)
            {
                return this.NotFound();
            }

            var recipeProduct = await _context.RecipeProducts
                .Include(r => r.Product)
                .Include(r => r.Recipe)
                .SingleOrDefaultAsync(m => m.RecipeId == recipeId && m.ProductId == productId);
            if (recipeProduct == null)
            {
                return NotFound();
            }

            return View(recipeProduct);
        }

        // POST: RecipeProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? recipeId, int? productId)
        {
            var recipeProduct = await _context.RecipeProducts.SingleOrDefaultAsync(m => m.RecipeId == recipeId && m.ProductId == productId);            

            var recipe = await this._context.Recipes
                .SingleOrDefaultAsync(x => x.Id == recipeId);
            var product = await _context.Products
                    .SingleOrDefaultAsync(x => x.Id == productId);
            recipe.Kcal -= product.Kcal * (int)recipeProduct.Amount;
            recipe.Proteins -= product.Proteins * (int)recipeProduct.Amount;
            recipe.Fats -= product.Fats * (int)recipeProduct.Amount;
            recipe.Carbohydrates -= product.Carbohydrates * (int)recipeProduct.Amount;
            recipe.Price -= product.Price * recipeProduct.Amount;
            _context.Update(recipe);

            _context.RecipeProducts.Remove(recipeProduct);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { recipeId = recipeId });
        }
        
    }
}
