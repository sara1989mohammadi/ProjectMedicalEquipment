using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalEquipment.Web.Models.ViewModels
{
    public class MedicalEquipmentIndexViewModels
    {
        public MedicalEquipmentIndexViewModels(IEnumerable<Product> Viewproducts,  IEnumerable<About> ViewAbouts, Contact ViewContacts,
            IEnumerable<ServicesType> ViewServicesType, Service ViewService, IEnumerable<Product> products)
        {
            Products = Viewproducts;
          //  Categories = ViewCategorie;
            Abouts = ViewAbouts;
            Contacts = ViewContacts;
            Service = ViewService;
            ServicesTypes = ViewServicesType;
            SpProduct = products;
        }
        public IEnumerable<Product> Products { get; set; }
       // public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<About> Abouts { get; set; }
        public Contact Contacts { get; set; }

        public Service Service { get; set; }

        public IEnumerable<ServicesType> ServicesTypes { get; set; }

        public IEnumerable<Product> SpProduct { get; set; }

    }
}
