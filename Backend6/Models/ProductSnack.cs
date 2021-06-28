using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Models
{
    public class ProductSnack
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Amount { get; set; }
        public string Picture { get; set; }
    }
}
