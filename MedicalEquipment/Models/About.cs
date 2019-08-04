using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalEquipment.Web.Models
{
    public class About
    {
        [Key]
        public int About_Id { get; set; }
        [Display(Name = "خلاصه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Summary { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Describtion { get; set; }

        [MaxLength(50)]
        [Display(Name = " عنوان عکس")]
        public string ImageName { get; set; }
        public int LangId { get; set; }

        [ForeignKey("LangId")]
        public virtual Language Language { get; set; }
    }
}
