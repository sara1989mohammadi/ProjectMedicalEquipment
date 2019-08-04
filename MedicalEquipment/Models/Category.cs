using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalEquipment.Web.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        [Key]
        public int Category_Id { get; set; }

     
        [MaxLength(100)]
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CategoryTitle { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
