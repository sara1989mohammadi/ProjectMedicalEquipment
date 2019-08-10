using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalEquipment.Web.Models.Convertors
{
    public class FixedText
    {
        public static string FixEmail(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
