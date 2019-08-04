using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalEquipment.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEquipment.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private MedicalEquipmentContext _context;
        public ContactFormController(MedicalEquipmentContext context)
        {
           
            _context = context;
        }

        [HttpPost]
        public void Create(FormContactModel formContact)
        {
            _context.FormContactModel.Add(formContact);
            _context.SaveChanges();
        }
    }
}