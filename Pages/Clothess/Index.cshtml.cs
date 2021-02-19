using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Arseniuc_Anamaria_proiect.Data;
using Arseniuc_Anamaria_proiect.Models;

namespace Arseniuc_Anamaria_proiect.Pages.Clothess
{
    public class IndexModel : PageModel
    {
        private readonly Arseniuc_Anamaria_proiect.Data.Arseniuc_Anamaria_proiectContext _context;

        public IndexModel(Arseniuc_Anamaria_proiect.Data.Arseniuc_Anamaria_proiectContext context)
        {
            _context = context;
        }

        public IList<Clothes> Clothes { get;set; }

        public ClothesData ClothesD { get; set; }
        public int ClothesID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ClothesD = new ClothesData();

            ClothesD.Clothes = await _context.Clothes
            .Include(b => b.Brand)
            .Include(b => b.ClothesCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                ClothesID = id.Value;
                Clothes book = ClothesD.Clothes
                .Where(i => i.ID == id.Value).Single();
                ClothesD.Categories = book.ClothesCategories.Select(s => s.Category);
            }
        }

        /*public async Task OnGetAsync()
        {
            Clothes = await _context.Clothes.Include(b=>b.Brand).ToListAsync();
        }*/
    }
}
