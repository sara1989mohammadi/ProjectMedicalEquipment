using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalEquipment.Web.Models
{
    public class Service
    {
        public Service()
        {
            ServicesType = new List<ServicesType>();
        }
        [Key]
        public int Service_Id { get; set; }
        [MaxLength(300)]
        [Display(Name = "نام سرویس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Tittle { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [MaxLength(50)]
        [Display(Name = " عنوان عکس")]
        public string ImageName { get; set; }
      
        public ICollection<ServicesType> ServicesType { get; set; }

        public int Lang_Id { get; set; }

        [ForeignKey("Lang_Id")]
        public virtual Language Language { get; set; }
    }
}
