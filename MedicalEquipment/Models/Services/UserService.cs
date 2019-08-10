using MedicalEquipment.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalEquipment.Web.Models.Services.Interfaces;
using MedicalEquipment.Web.Models.ViewModels;
using MedicalEquipment.Web.Models.Security;
using MedicalEquipment.Web.Models.Convertors;
using MedicalEquipment.Web.Models.Generator;

namespace MedicalEquipment.Web.Models.Services
{
    public class UserService:IUserService
    {
        private MedicalEquipmentContext  _context;

        public UserService(MedicalEquipmentContext context)
        {
            _context = context;
        }


        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public User LoginUser(LoginViewModel login)
        {
            string hashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
            string email = FixedText.FixEmail(login.Email);
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == hashPassword);
        }

        public bool ActiveAccount(string activeCode)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
            if(user==null||user.IsActive)
                return false;
            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            _context.SaveChanges();
            return true;

        }

        public User getUserByEmail(string Email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == Email);
        }

        public User getUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
