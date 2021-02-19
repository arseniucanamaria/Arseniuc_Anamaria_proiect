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
    public class DeleteModel : PageModel
    {
        private readonly Arseniuc_Anamaria_proiect.Data.Arseniuc_Anamaria_proiectContext _context;

        public DeleteModel(Arseniuc_Anamaria_proiect.Data.Arseniuc_Anamaria_proiectContext context)
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

            Clothes = await _context.Clothes.FirstOrDefaultAsync(m => m.ID == id);

            if (Clothes == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clothes = await _context.Clothes.FindAsync(id);

            if (Clothes != null)
            {
                _context.Clothes.Remove(Clothes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
