using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Models.ViewModels
{
    public class RecipeProductsCreateModel
    {
        public int ProductId { get; set; }
        public Unit Unit { get; set; }
        public double Amount { get; set; }
    }
}
