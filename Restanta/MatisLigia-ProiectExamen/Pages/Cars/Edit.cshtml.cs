using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatisLigia_ProiectExamen.Data;
using MatisLigia_ProiectExamen.Models;

namespace MatisLigia_ProiectExamen.Pages.Cars
{
    public class EditModel : CarConditionsPageModel

    {
        private readonly MatisLigia_ProiectExamen.Data.MatisLigia_ProiectExamenContext _context;

        public EditModel(MatisLigia_ProiectExamen.Data.MatisLigia_ProiectExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.Include(p => p.Brand).Include(p => p.CarConditions).ThenInclude(p => p.Condition).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Car == null)
            {
                return NotFound();
            }
            PopulateAssignedConditionData(_context, Car);
            ViewData["BrandID"] = new SelectList(_context.Set<Models.Brand>(), "ID", "BrandName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedConditions)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carToUpdate = await _context.Car
                .Include(i => i.Brand)
                .Include(i => i.CarConditions)
                .ThenInclude(i => i.Condition)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (carToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Car>(carToUpdate,"Car",i => i.CarModel, i => i.Capacity,i => i.Price, i => i.LunchDate, i => i.Brand))
            {
                UpdateCarConditions(_context, selectedConditions, carToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateCarConditions(_context, selectedConditions, carToUpdate);
            PopulateAssignedConditionData(_context, carToUpdate);
            return Page();
        }
    }
}

