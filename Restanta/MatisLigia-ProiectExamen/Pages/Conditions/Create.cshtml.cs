using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MatisLigia_ProiectExamen.Data;
using MatisLigia_ProiectExamen.Models;

namespace MatisLigia_ProiectExamen.Pages.Conditions
{
    public class CreateModel : PageModel
    {
        private readonly MatisLigia_ProiectExamen.Data.MatisLigia_ProiectExamenContext _context;

        public CreateModel(MatisLigia_ProiectExamen.Data.MatisLigia_ProiectExamenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Condition Condition { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Condition.Add(Condition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
