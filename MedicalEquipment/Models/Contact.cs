using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalEquipment.Web.Models
{
    public class Contact
    {
        [Key]
        public int Contact_Id { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Phone { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Mobil { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "آیدی تلگرام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string TelegramId { get; set; }

        [Display(Name = "آیدی اینستاگرام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string InstagrmId { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Address { get; set; }

        public int LangID { get; set; }

        [ForeignKey("LangID")]
        public virtual Language Language { get; set; }
    }
}

