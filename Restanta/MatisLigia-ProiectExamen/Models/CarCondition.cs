using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatisLigia_ProiectExamen.Models
{
    public class CarCondition
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int ConditionID { get; set; }
        public Condition Condition { get; set; }
    }
}
