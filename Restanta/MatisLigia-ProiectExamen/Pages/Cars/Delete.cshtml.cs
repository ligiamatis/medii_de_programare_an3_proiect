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
    public class DeleteModel : PageModel
    {
        private readonly MatisLigia_ProiectExamen.Data.MatisLigia_ProiectExamenContext _context;

        public DeleteModel(MatisLigia_ProiectExamen.Data.MatisLigia_ProiectExamenContext context)
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

            Car = await _context.Car.FirstOrDefaultAsync(m => m.ID == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FindAsync(id);

            if (Car != null)
            {
                _context.Car.Remove(Car);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
