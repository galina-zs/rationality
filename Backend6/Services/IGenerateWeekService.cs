using Rationality.Models;
using Rationality.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Services
{
    public interface IGenerateWeekService
    {
        List<Day> GenerateWeek(ApplicationUser user, Nutrition userNutrition);
        Day GenerateDay(ApplicationUser user, Nutrition userNutrition);
    }
}
