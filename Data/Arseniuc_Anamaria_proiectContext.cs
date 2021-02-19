using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Arseniuc_Anamaria_proiect.Models;

namespace Arseniuc_Anamaria_proiect.Data
{
    public class Arseniuc_Anamaria_proiectContext : DbContext
    {
        public Arseniuc_Anamaria_proiectContext (DbContextOptions<Arseniuc_Anamaria_proiectContext> options)
            : base(options)
        {
        }

        public DbSet<Arseniuc_Anamaria_proiect.Models.Clothes> Clothes { get; set; }

        public DbSet<Arseniuc_Anamaria_proiect.Models.Brand> Brand { get; set; }

        public DbSet<Arseniuc_Anamaria_proiect.Models.Category> Category { get; set; }
    }
}
