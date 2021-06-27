using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Kcal { get; set; }
        public int Proteins { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public string CookingMethod { get; set; }
        public Meal Meal { get; set; }
    }

    public enum Meal
    {
        Breakfast,
        Lunch,
        Dinner,
        Snack
    }
}
