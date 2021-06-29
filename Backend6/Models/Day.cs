using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rationality.Models
{
    public class Day
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int SnackId { get; set; }
        public Snack Snack { get; set; }
        public int BreakfastId { get; set; }
        public Recipe Breakfast { get; set; }
        public int LunchId { get; set; }
        public Recipe Lunch { get; set; }
        public int DinnerId { get; set; }
        public Recipe Dinner { get; set; }
    }
}
