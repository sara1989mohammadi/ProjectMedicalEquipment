using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MedicalEquipment.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MedicalEquipment.Web.Models.ViewModels;


namespace MedicalEquipment.Web.Controllers
{
    public class HomeController : Controller
    {
        private MedicalEquipmentContext _context;
        private IStringLocalizer<HomeController> _localizer;

        public HomeController(MedicalEquipmentContext context, IStringLocalizer<HomeController> localizer)
        {
            _context = context;
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            string lang = CultureInfo.CurrentCulture.Name;
           // ViewData["LanguageTitle"] = _context.Products.Where(n => n.Language.LanguageTitle == lang);
           IEnumerable<Product> Products = _context.Products.Where(n => n.Language.LanguageTitle == lang);
         //   IEnumerable<Category> Categories = _context.Categories.ToList();
            IEnumerable<About> About = _context.AboutUs.Where(n => n.Language.LanguageTitle == lang);
            IEnumerable<Contact> Contact = _context.Contacts.Where(n => n.Language.LanguageTitle == lang);
            IEnumerable<Service> Service = _context.Service.Where(n => n.Language.LanguageTitle == lang);
            IEnumerable<ServicesType> servicesTypes = _context.ServicesType.ToList();

            var pro = from p in Products
                      where p.SpecialProduct == true
                      select p;

            Service service = new Service();
            foreach (var item in Service)
            {
                service = item;
            }

            Contact contact = new Contact();
            foreach (var item in Contact)
            {
                contact = item;
            }
            MedicalEquipmentIndexViewModels ViewModels = new MedicalEquipmentIndexViewModels(Products, About, contact, servicesTypes, service, pro );
            return View(ViewModels);

            //return View(_context.Products.Where(n=> n.Language.LanguageTitle==lang));
        }
        public PartialViewResult Languages()
        {
            return PartialView(_context.Languages);
        }
        public IActionResult ChangeLanguage(string Id)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(Id))
                , new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}