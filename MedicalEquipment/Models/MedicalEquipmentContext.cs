using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace MedicalEquipment.Web.Models
{
    public class MedicalEquipmentContext : DbContext
    {
        public MedicalEquipmentContext(DbContextOptions<MedicalEquipmentContext> options) : base(options)
        {

        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<About> AboutUs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ServicesType> ServicesType { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<FormContact> FormContact { get; set; }
        public DbSet<FormContactModel> FormContactModel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
           // modelBuilder.Entity<Product>().HasQueryFilter(n => n.Language.LanguageTitle == lang);
            base.OnModelCreating(modelBuilder);
        }
    }
}
