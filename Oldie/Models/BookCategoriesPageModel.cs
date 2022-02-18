using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Matis_Ligia_Estera_ProiectExamen.Data;

namespace Matis_Ligia_Estera_ProiectExamen.Models
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Matis_Ligia_Estera_ProiectExamenContext context,
        Book book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(
            book.BookCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(Matis_Ligia_Estera_ProiectExamenContext context,
string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.BookCategories = new List<BookCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (bookToUpdate.BookCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.BookCategories.Add(
                        new BookCategory
                        {
                            BookID = bookToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        BookCategory courseToRemove
                        = bookToUpdate
                        .BookCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
