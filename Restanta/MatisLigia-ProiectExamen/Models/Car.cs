using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace MatisLigia_ProiectExamen.Models
{

    public class Car
    {
        public int ID { get; set; }

        [Required, StringLength(50, MinimumLength = 3), RegularExpression(@".*(diesel)?(petrol)?.*", ErrorMessage = "Fuel must be Specified: diesel/petrol")]
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }
        [Required, RegularExpression(@".*\d+.*", ErrorMessage = "Capacity must contain a number")]
        public string Capacity { get; set; }

        [Range(1000, 300000)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Car Publishing Date")]
        public DateTime LunchDate { get; set; }

        public int BrandID { get; set; }

        public Brand Brand { get; set; }

        public ICollection<CarCondition> CarConditions { get; set; }
    }
}
