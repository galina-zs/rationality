using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Models.ViewModels
{
    public class RecipesCreateEditModel
    {
        public string Name { get; set; }
        public int Kcal { get; set; }
        public int Proteins { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
        public double Price { get; set; }
        public string CookingMethod { get; set; }
        public Meal Meal { get; set; }
        public IFormFile File { get; set; }
    }
}
