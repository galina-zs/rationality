using Microsoft.EntityFrameworkCore;
using Rationality.Data;
using Rationality.Models;
using Rationality.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Services
{
    public class GenerateWeekService : IGenerateWeekService
    {
        private readonly ApplicationDbContext _context;

        public GenerateWeekService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void GenerateWeek(ApplicationUser user, Nutrition userNutrition)
        {
            int mediumPriceForMeal = (user.MoneyPerMonth / 7) / 3;
            var recipes = _context.Recipes
                .SingleOrDefaultAsync(m => m.Meal == Meal.Breakfast && m.Price < mediumPriceForMeal);
            


        }
    }
}
