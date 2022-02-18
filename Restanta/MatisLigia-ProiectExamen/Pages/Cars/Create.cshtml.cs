using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MatisLigia_ProiectExamen.Data;
using MatisLigia_ProiectExamen.Models;

namespace MatisLigia_ProiectExamen.Pages.Cars
{
    public class CreateModel : CarConditionsPageModel
    {
        private readonly MatisLigia_ProiectExamen.Data.MatisLigia_ProiectExamenContext _context;

        public CreateModel(MatisLigia_ProiectExamen.Data.MatisLigia_ProiectExamenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandID"] = new SelectList(_context.Set<Models.Brand>(), "ID", "BrandName");

            var car = new Car();
            car.CarConditions = new List<CarCondition> ();

            PopulateAssignedConditionData(_context, car);
            return Page();

        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedConditions)
        {
            var newCar = new Car();
            if (selectedConditions != null)
            {
                newCar.CarConditions = new List<CarCondition>();
                foreach (var cat in selectedConditions)
                {
                    var catToAdd = new CarCondition
                    {
                        ConditionID = int.Parse(cat)
                    };
                    newCar.CarConditions.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Car>(
            newCar,
            "Car",
            i => i.CarModel, i => i.Capacity,
            i => i.Price, i => i.LunchDate, i => i.BrandID))
            {
                _context.Car.Add(newCar);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedConditionData(_context, newCar);
            return Page();
        }


        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Car.Add(Car);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
