using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Rationality.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int Weight { get; set; }
        public Goal Goal { get; set; }
        public PhysicalActivity Activity { get; set; }
        public int MoneyPerMonth { get; set; }
        public int Height { get; set; }
        public ICollection<Day> Days { get; set; }
    }
}

public enum Gender
{
    Male,
    Female
}

public enum Goal
{
    LoseWeight,
    KeepWeight,
    GainWeight
}

public enum PhysicalActivity
{
    Minimal,
    Poor,
    Moderate,
    Heavy,
    Extreme
}