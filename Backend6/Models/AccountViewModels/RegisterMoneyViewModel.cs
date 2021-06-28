using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Models.AccountViewModels
{
    public class RegisterMoneyViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int Weight { get; set; }
        public Goal Goal { get; set; }
        public PhysicalActivity Activity { get; set; }
        public int Height { get; set; }

        [Required]
        public int MoneyPerMonth { get; set; }
    }
}
