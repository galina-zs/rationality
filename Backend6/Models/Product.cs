using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Kcal { get; set; }
        public int Proteins { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
        public double Price { get; set; }
        public Unit Unit { get; set; }
        public bool IsSnack { get; set; }
    }

    public enum Unit
    {
        Liter,
        Kilogram,
        Gram,
        Piece,
        Milliliter
    }
}
