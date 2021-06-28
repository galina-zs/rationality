using Rationality.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Rationality.Models;

namespace Rationality.Services
{
    public class NutritionForUserService : INutritionForUserService
    {
        public Nutrition GetNutritionForUser(ApplicationUser user)
        {
            int height = user.Height, weight = user.Weight, age = user.Age;
            Gender gender = user.Gender;
            PhysicalActivity activity = user.Activity;
            Goal goal = user.Goal;
            int calories = 1700, fats = 90, proteins = 50, carbohydrates = 110;
            double A = 1.55;
            switch (activity)
            {
                case PhysicalActivity.Poor:
                    fats = 86;
                    proteins = 47;
                    carbohydrates = 105;
                    A = 1.2;
                    break;
                case PhysicalActivity.Minimal:
                    fats = 89;
                    proteins = 48;
                    carbohydrates = 109;
                    A = 1.375;
                    break;
                case PhysicalActivity.Moderate:
                    fats = 92;
                    proteins = 50;
                    carbohydrates = 113;
                    A = 1.55;
                    break;
                case PhysicalActivity.Heavy:
                    fats = 98;
                    proteins = 54;
                    carbohydrates = 129;
                    A = 1.7;
                    break;
                case PhysicalActivity.Extreme:
                    fats =  105;
                    proteins = 58;
                    carbohydrates = 141;
                    A = 1.9;
                    break;
            }
                
            if(gender == Gender.Female)
            {
                calories = Convert.ToInt32((10 * weight + 6.25 * height - 5 * age - 161) * A);
            }
            else if(gender == Gender.Male)
            {
                calories = Convert.ToInt32((10 * weight + 6.25 * height - 5 * age + 5) * A);
            }

            switch (goal)
            {
                case Goal.LoseWeight:
                    fats = Convert.ToInt32(fats * 0.8); 
                    proteins = Convert.ToInt32(proteins * 0.8); 
                    carbohydrates = Convert.ToInt32(carbohydrates * 0.8);
                    calories -= 200;
                    break;
                case Goal.GainWeight:
                    fats = Convert.ToInt32(fats * 1.2);
                    proteins = Convert.ToInt32(proteins * 1.2);
                    carbohydrates = Convert.ToInt32(carbohydrates * 1.2);
                    calories += 200;
                    break;
            }

            return new Nutrition {
                Proteins = proteins,
                Fats = fats,
                Calories = calories,
                Сarbohydrates = carbohydrates
            };
        }
    }
}
