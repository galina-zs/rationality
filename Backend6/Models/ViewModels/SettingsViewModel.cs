using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Models.ViewModels
{
    public class SettingsViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public Goal Goal { get; set; }
        public PhysicalActivity PhysicalActivity { get; set; }
        public int MoneyPerWeek { get; set; }
    }
}
