using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Matis_Ligia_Estera_ProiectExamen.Models;

namespace Matis_Ligia_Estera_ProiectExamen.Data
{
    public class Matis_Ligia_Estera_ProiectExamenContext : DbContext
    {
        public Matis_Ligia_Estera_ProiectExamenContext (DbContextOptions<Matis_Ligia_Estera_ProiectExamenContext> options)
            : base(options)
        {
        }

        public DbSet<Matis_Ligia_Estera_ProiectExamen.Models.Book> Book { get; set; }

        public DbSet<Matis_Ligia_Estera_ProiectExamen.Models.Publisher> Publisher { get; set; }

        public DbSet<Matis_Ligia_Estera_ProiectExamen.Models.Category> Category { get; set; }
    }
}
