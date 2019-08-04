using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalEquipment.Web.Models
{
    public class SliderImage
    {
        [Key]
        public int SliderImage_Id { get; set; }
        public string Title { get; set; }
        [MaxLength(50)]
        [Display(Name = " عنوان عکس")]
        public string ImageName { get; set; }
        public int Lang_Id { get; set; }

        [ForeignKey("Lang_Id")]
        public virtual Language Language { get; set; }
    }
}
