﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Arseniuc_Anamaria_proiect.Data;
using Arseniuc_Anamaria_proiect.Models;

namespace Arseniuc_Anamaria_proiect.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly Arseniuc_Anamaria_proiect.Data.Arseniuc_Anamaria_proiectContext _context;

        public IndexModel(Arseniuc_Anamaria_proiect.Data.Arseniuc_Anamaria_proiectContext context)
        {
            _context = context;
        }

        public IList<Brand> Brand { get;set; }

        public async Task OnGetAsync()
        {
            Brand = await _context.Brand.ToListAsync();
        }
    }
}
