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
        void GenerateWeek(ApplicationUser user, Nutrition userNutrition);
    }
}
