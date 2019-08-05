using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace MedicalEquipment.Web.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }      


        [MaxLength(300)]
        [Display(Name = "نام کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ProductName { get; set; }
        
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [MaxLength(50)]
        [Display(Name = " عنوان عکس")]       
        public string ImageName { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }

        [Display(Name = "وضعیت")]

        public bool Status { get; set; }

        [Display(Name = "محصول ویژه")]

        public bool SpecialProduct { get; set; }
        [Display(Name = "محصول قابل نمایش در صفحه اصلی")]

        public bool ProductForDisplay { get; set; }

        public int Lang_Id { get; set; }

        [ForeignKey("Lang_Id")]
        public virtual  Language Language { get; set; }

        public int Category_Id { get; set; }

        [ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }
    }
}
