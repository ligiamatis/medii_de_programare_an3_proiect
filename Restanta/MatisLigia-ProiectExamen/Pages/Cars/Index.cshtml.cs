using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MatisLigia_ProiectExamen.Data;
using MatisLigia_ProiectExamen.Models;

namespace MatisLigia_ProiectExamen.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly MatisLigia_ProiectExamen.Data.MatisLigia_ProiectExamenContext _context;

        public IndexModel(MatisLigia_ProiectExamen.Data.MatisLigia_ProiectExamenContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }
        public CarData CarD { get; set; }
        public int CarID { get; set; }
        public int ConditionID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            CarD = new CarData();

            CarD.Cars = await _context.Car
            .Include(b => b.Brand)
            .Include(b => b.CarConditions)
            .ThenInclude(b => b.Condition)
            .AsNoTracking()
            .OrderBy(b => b.CarModel)
            .ToListAsync();

            if (id != null)
            {
                CarID = id.Value;
                Car car = CarD.Cars
                .Where(i => i.ID == id.Value).Single();
                CarD.Conditions = car.CarConditions.Select(s => s.Condition);
            }
        }
    }
}
