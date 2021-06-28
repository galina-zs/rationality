using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Models.ViewModels
{
    public class RecipeDetailsViewModel
    {
        public ICollection<RecipeProduct> RecipeProducts { get; set; }
        public Recipe Recipe { get; set; }
    }
}
