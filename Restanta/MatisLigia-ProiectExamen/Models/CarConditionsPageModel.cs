using MatisLigia_ProiectExamen.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatisLigia_ProiectExamen.Models
{
    public class CarConditionsPageModel : PageModel
    {
        public List<AssignedConditionData> AssignedConditionDataList;
        public void PopulateAssignedConditionData(MatisLigia_ProiectExamenContext context,
        Car car)
        {
            var allConditions = context.Condition;
            var carConditions = new HashSet<int>(
            car.CarConditions.Select(c => c.ConditionID)); //
            AssignedConditionDataList = new List<AssignedConditionData>();
            foreach (var cond in allConditions)
            {
                AssignedConditionDataList.Add(new AssignedConditionData
                {
                    ConditionID = cond.ID,
                    Name = cond.ConditionName,
                    Assigned = carConditions.Contains(cond.ID)
                });
            }
        }
        public void UpdateCarConditions(MatisLigia_ProiectExamenContext context,
        string[] selectedConditions, Car carToUpdate)
        {
            if (selectedConditions == null)
            {
                carToUpdate.CarConditions = new List<CarCondition>();
                return;
            }
            var selectedConditionsHS = new HashSet<string>(selectedConditions);
            var carConditions = new HashSet<int>
            (carToUpdate.CarConditions.Select(c => c.Condition.ID));
            foreach (var cond in context.Condition)
            {
                if (selectedConditionsHS.Contains(cond.ID.ToString()))
                {
                    if (!carConditions.Contains(cond.ID))
                    {
                        carToUpdate.CarConditions.Add(
                        new CarCondition
                        {
                            CarID = carToUpdate.ID,
                            ConditionID = cond.ID
                        });
                    }
                }
                else
                {
                    if (carConditions.Contains(cond.ID))
                    {
                        CarCondition carToRemove
                        = carToUpdate
                        .CarConditions
                        .SingleOrDefault(i => i.ConditionID == cond.ID);
                        context.Remove(carToRemove);
                    }
                }
            }

        }
    }
}
