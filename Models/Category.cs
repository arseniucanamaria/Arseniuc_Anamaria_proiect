using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arseniuc_Anamaria_proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ClothesCategory> ClothesCategories { get; set; }
    }
}
