using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Arseniuc_Anamaria_proiect.Data;

namespace Arseniuc_Anamaria_proiect.Models
{
    public class ClothesCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Arseniuc_Anamaria_proiectContext context,
        Clothes clothes)
        {
            var allCategories = context.Category;
            var clothesCategories = new HashSet<int>(
            clothes.ClothesCategories.Select(c => c.ClothesID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = clothesCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateClothesCategories(Arseniuc_Anamaria_proiectContext context,
        string[] selectedCategories, Clothes clothesToUpdate)
        {
            if (selectedCategories == null)
            {
                clothesToUpdate.ClothesCategories = new List<ClothesCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var clothesCategories = new HashSet<int>
            (clothesToUpdate.ClothesCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!clothesCategories.Contains(cat.ID))
                    {
                        clothesToUpdate.ClothesCategories.Add(
                        new ClothesCategory
                        {
                            ClothesID = clothesToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (clothesCategories.Contains(cat.ID))
                    {
                        ClothesCategory courseToRemove
                        = clothesToUpdate
                        .ClothesCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

