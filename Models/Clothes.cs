using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arseniuc_Anamaria_proiect.Models
{
    public class Clothes
    {
        public int ID { get; set; }


        [Display(Name = "Clothes name")]
        public string Name { get; set; }


        [Required, StringLength(150, MinimumLength = 3)]
        public string Description { get; set; }

        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int BrandID { get; set; }
        public Brand Brand { get; set; }

        public ICollection<ClothesCategory> ClothesCategories { get; set; }

    }
}
