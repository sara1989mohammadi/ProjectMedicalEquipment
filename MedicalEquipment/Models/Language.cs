using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalEquipment.Web.Models
{
    public class Language
    {
        public Language()
        {
            Products = new List<Product>();
            Abouts = new List<About>();
            Contacts = new List<Contact>();
            SliderImages = new List<SliderImage>();
            ServicesType = new List<ServicesType>();
            Service = new List<Service>();       

        }

        [Key]
        public int Lang_Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string LanguageTitle { get; set; }
        public ICollection<Product> Products { get; set; }     
        public ICollection<About> Abouts { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<SliderImage> SliderImages { get; set; }
        public ICollection<ServicesType> ServicesType { get; set; }
        public ICollection<Service> Service { get; set; }        
    }
}
