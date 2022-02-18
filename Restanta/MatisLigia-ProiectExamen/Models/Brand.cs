using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatisLigia_ProiectExamen.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}
