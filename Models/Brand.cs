using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arseniuc_Anamaria_proiect.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
        public ICollection<Clothes> Clothess { get; set; } //navigation property
    }
}
