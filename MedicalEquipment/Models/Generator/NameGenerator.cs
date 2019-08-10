using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalEquipment.Web.Models.Generator
{
    public class NameGenerator
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
