using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalEquipment.Web.Models
{
    public class ServicesType
    {
      
      
        [Key]
        public int ServicesType_Id { get; set; }
        public string Tittle { get; set; }    
       
        public int Service_Id { get; set; }

        [ForeignKey("Service_Id")]
        public virtual Service Service { get; set; }
    }
}
