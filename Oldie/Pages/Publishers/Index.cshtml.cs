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
    public class IndexModel : PageModel
    {
        private readonly Matis_Ligia_Estera_ProiectExamen.Data.Matis_Ligia_Estera_ProiectExamenContext _context;

        public IndexModel(Matis_Ligia_Estera_ProiectExamen.Data.Matis_Ligia_Estera_ProiectExamenContext context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; }

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
