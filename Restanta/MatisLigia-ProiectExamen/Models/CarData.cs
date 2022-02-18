using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatisLigia_ProiectExamen.Models
{
    public class CarData
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Condition> Conditions { get; set; }
        public IEnumerable<CarCondition> CarConditions { get; set; }
    }
}
