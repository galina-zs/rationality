using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Models
{
    public class Snack
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public ICollection<ProductSnack> ProductSnacks { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
