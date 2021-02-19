using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arseniuc_Anamaria_proiect.Models
{
    public class ClothesData
    {
        public IEnumerable<Clothes> Clothes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ClothesCategory> ClothesCategories { get; set; }
    }
}
