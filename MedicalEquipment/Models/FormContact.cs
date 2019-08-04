using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalEquipment.Web.Models
{
    public class FormContact
    {
        public FormContact()
        {
            Active = false;          
        }
        [Key]
        public int FormContact_Id { get; set; }

        [Display(Name = "نام")]
      
        public string Name { get; set; }
       

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }


        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }

        public bool Active { get; set; }
       
    }
}
