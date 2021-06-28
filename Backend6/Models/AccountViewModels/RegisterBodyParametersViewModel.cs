using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Models.AccountViewModels
{
    public class RegisterBodyParametersViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Range(1, 350)]
        [Display(Name = "Weight")]
        public int Weight { get; set; }

        [Required]
        public Goal Goal { get; set; }

        [Required]
        public PhysicalActivity Activity { get; set; }

        [Required]
        [Range(1, 250)]
        [Display(Name = "Weight")]
        public int Height { get; set; }
    }
}
