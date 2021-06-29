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
            Random rnd = new Random();

        }

        public void GenerateDay(ApplicationUser user, Nutrition userNutrition)
        {
            int caloriesScatter = 200, fatsScatter = 10, carbohydratesScatter = 15, proteinsScatter = 10;
            int mediumPriceForMeal = (user.MoneyPerMonth / 7) / 4;
            var breakfasts = _context.Recipes
                .Where(m => m.Meal == Meal.Breakfast && m.Price <= mediumPriceForMeal).ToList();
            var lunches = _context.Recipes
               .Where(m => m.Meal == Meal.Lunch && m.Price <= mediumPriceForMeal).ToList();
            var dinners = _context.Recipes
               .Where(m => m.Meal == Meal.Dinner && m.Price <= mediumPriceForMeal).ToList();
            var snacks = _context.Recipes
               .Where(m => m.Meal == Meal.Snack && m.Price <= mediumPriceForMeal).ToList();

            var selections = BrutForceSelections(breakfasts, lunches, dinners);
            selections = GetGoodPriceSelections(selections, user);
            selections = AddSnacksIfCan(selections, user);
            selections = FilterSelectionsOnCalories(selections, userNutrition.Calories, caloriesScatter);
            selections = FilterSelectionsOnPFC(selections, userNutrition, proteinsScatter, fatsScatter, carbohydratesScatter);


        }

        private List<List<Recipe>> BrutForceSelections(List<Recipe> breakfasts, List<Recipe> lunches, List<Recipe> dinners)
        {
            List<List<Recipe>> selections = new List<List<Recipe>>();
            foreach (Recipe breakfast in breakfasts)
            {
                foreach (Recipe lunch in lunches)
                {
                    foreach (Recipe dinner in dinners)
                    {
                        List<Recipe> temp = new List<Recipe>();
                        temp.Add(breakfast);
                        temp.Add(lunch);
                        temp.Add(dinner);
                        selections.Add(temp);
                    }
                }
            }
            return selections;
        }

        private List<List<Recipe>> GetGoodPriceSelections(List<List<Recipe>> selections, ApplicationUser user)
        {
            double priceForUser = user.MoneyPerMonth / 7;
            foreach (List<Recipe> selection in selections)
            {
                double price = selection[0].Price + selection[1].Price + selection[2].Price;
                if(price > priceForUser)
                {
                    selection.Clear();
                }
            }
            return selections;
        }

        private List<List<Recipe>> AddSnacksIfCan(List<List<Recipe>> selections, ApplicationUser user)
        {
            double priceForUser = user.MoneyPerMonth / 7;
            List<Recipe> userSnacks = new List<Recipe>();
            foreach (List<Recipe> selection in selections)
            {
                double price = selection[0].Price + selection[1].Price + selection[2].Price;
                if (price < priceForUser)
                {
                    double diff = priceForUser - price;
                    var snacks = _context.Recipes
                        .Where(m => m.Meal == Meal.Snack && m.Price <= diff).ToList();
                    if (snacks.Count != 0){
                        foreach(Recipe snack in snacks)
                        {
                            if(price + snack.Price < priceForUser)
                            {
                                selection.Add(snack);
                                price += snack.Price;
                            }
                        }
                    }
                }
            }
            return selections;
        }

        private List<List<Recipe>> FilterSelectionsOnCalories(List<List<Recipe>> selections, int userCalories, int caloriesScatter)
        {
            foreach(List<Recipe> selection in selections)
            {
                double selectionCalories = 0;
                foreach(Recipe recipe in selection)
                {
                    selectionCalories += recipe.Price;
                }
                if(selectionCalories > userCalories + caloriesScatter || selectionCalories < userCalories - caloriesScatter)
                {
                    selection.Clear();
                }
            }
            return null;
        }

        private List<List<Recipe>> FilterSelectionsOnPFC(List<List<Recipe>> selections, 
            Nutrition user, 
            int proteinsScatter,
            int fatsScatter,
            int carbohydratesScatter)
        {
            foreach (List<Recipe> selection in selections)
            {
                double selectionProteins = 0;
                double selectionFats = 0;
                double selectionCarbohydrates = 0;
                foreach (Recipe recipe in selection)
                {
                    selectionProteins += recipe.Proteins;
                    selectionFats += recipe.Fats;
                    selectionCarbohydrates += recipe.Carbohydrates;
                }
                if (selectionFats > user.Fats + fatsScatter || selectionFats < user.Fats - fatsScatter)
                {
                    selection.Clear();
                    break;
                }
                if (selectionProteins > user.Proteins + proteinsScatter|| selectionProteins< user.Proteins - proteinsScatter)
                {
                    selection.Clear();
                    break;
                }
                if (selectionCarbohydrates > user.Сarbohydrates + carbohydratesScatter 
                    || selectionCarbohydrates < user.Сarbohydrates - carbohydratesScatter)
                {
                    selection.Clear();
                    break;
                }
            }
            return selections;
        }
    }
}
