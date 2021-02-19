using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Arseniuc_Anamaria_proiect.Data;
using Arseniuc_Anamaria_proiect.Models;

namespace Arseniuc_Anamaria_proiect.Pages.Clothess
{
    public class EditModel : ClothesCategoriesPageModel
    {
        private readonly Arseniuc_Anamaria_proiect.Data.Arseniuc_Anamaria_proiectContext _context;

        public EditModel(Arseniuc_Anamaria_proiect.Data.Arseniuc_Anamaria_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clothes Clothes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clothes = await _context.Clothes
                .Include(b => b.Brand)
                .Include(b => b.ClothesCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
               .FirstOrDefaultAsync(m => m.ID == id);

            if (Clothes == null)
            {
                return NotFound();
            }

            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData
            PopulateAssignedCategoryData(_context, Clothes);

            ViewData["BrandID"] = new SelectList(_context.Brand, "ID", "BrandName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
     

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clothesToUpdate = await _context.Clothes
            .Include(i => i.Brand)
            .Include(i => i.ClothesCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (clothesToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Clothes>(
            clothesToUpdate,
            "Clothes",
            i => i.Name, i => i.Description,
            i => i.Price, i => i.ReleaseDate, i => i.Brand))
            {
                UpdateClothesCategories(_context, selectedCategories, clothesToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateClothesCategories pentru a aplica informatiile din checkboxuri la entitatea Clothess care
            //este editata
            UpdateClothesCategories(_context, selectedCategories, clothesToUpdate);
            PopulateAssignedCategoryData(_context, clothesToUpdate);
            return Page();
        }
    }

    /*private bool ClothesExists(int id)
        {
            return _context.Clothes.Any(e => e.ID == id);
        }*/
}


