using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arseniuc_Anamaria_proiect.Models
{
    public class ClothesCategory
    {
        public int ID { get; set; }
        public int ClothesID { get; set; }
        public Clothes Clothes { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
