using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatisLigia_ProiectExamen.Models
{
    public class Condition
    {
        public int ID { get; set; }
        public string ConditionName { get; set; }
        public ICollection<CarCondition> CarConditions { get; set; }
    }
}
