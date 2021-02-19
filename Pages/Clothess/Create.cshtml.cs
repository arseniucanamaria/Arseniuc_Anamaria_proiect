using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Arseniuc_Anamaria_proiect.Data;
using Arseniuc_Anamaria_proiect.Models;

namespace Arseniuc_Anamaria_proiect.Pages.Clothess
{
    public class CreateModel : ClothesCategoriesPageModel
    {
        private readonly Arseniuc_Anamaria_proiect.Data.Arseniuc_Anamaria_proiectContext _context;

        public CreateModel(Arseniuc_Anamaria_proiect.Data.Arseniuc_Anamaria_proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandID"] = new SelectList(_context.Brand, "ID", "BrandName");

            var clothes = new Clothes();
            clothes.ClothesCategories = new List<ClothesCategory>();
            PopulateAssignedCategoryData(_context, clothes);

            return Page();
        }

        [BindProperty]
        public Clothes Clothes { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newClothes = new Clothes();
            if (selectedCategories != null)
            {
                newClothes.ClothesCategories = new List<ClothesCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ClothesCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newClothes.ClothesCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Clothes>(
            newClothes,
            "Clothes",
            i => i.Name, i => i.Description,
            i => i.Price, i => i.ReleaseDate, i => i.BrandID))
            {
                _context.Clothes.Add(newClothes);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newClothes);
            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
       /* public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clothes.Add(Clothes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }*/
    }
}
