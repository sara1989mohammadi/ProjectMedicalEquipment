using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalEquipment.Web.Models
{
    public class FormContactModel
    {
        [Key]
        public int FormContactModel_Id { get; set; }

        [Display(Name = "نام")]

        public string Name { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }


        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }

    }
}
