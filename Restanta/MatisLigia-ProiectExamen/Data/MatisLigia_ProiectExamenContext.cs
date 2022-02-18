using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MatisLigia_ProiectExamen.Models;

namespace MatisLigia_ProiectExamen.Data
{
    public class MatisLigia_ProiectExamenContext : DbContext
    {
        public MatisLigia_ProiectExamenContext (DbContextOptions<MatisLigia_ProiectExamenContext> options)
            : base(options)
        {
        }

        public DbSet<MatisLigia_ProiectExamen.Models.Car> Car { get; set; }

        public DbSet<MatisLigia_ProiectExamen.Models.Brand> Brand { get; set; }

        public DbSet<MatisLigia_ProiectExamen.Models.Condition> Condition { get; set; }
    }
}
