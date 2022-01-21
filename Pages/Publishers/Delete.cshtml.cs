using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Matis_Ligia_Estera_ProiectExamen.Data;
using Matis_Ligia_Estera_ProiectExamen.Models;

namespace Matis_Ligia_Estera_ProiectExamen.Pages.Publishers
{
    public class DeleteModel : PageModel
    {
        private readonly Matis_Ligia_Estera_ProiectExamen.Data.Matis_Ligia_Estera_ProiectExamenContext _context;

        public DeleteModel(Matis_Ligia_Estera_ProiectExamen.Data.Matis_Ligia_Estera_ProiectExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Publisher Publisher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);

            if (Publisher == null)
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

            Publisher = await _context.Publisher.FindAsync(id);

            if (Publisher != null)
            {
                _context.Publisher.Remove(Publisher);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
