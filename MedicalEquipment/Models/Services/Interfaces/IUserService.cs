using MedicalEquipment.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalEquipment.Web.Models.Services.Interfaces
{
    public interface IUserService
    {
        #region Check
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        #endregion

        #region AddUser
        int AddUser(User user);

        #endregion
      
        User LoginUser(LoginViewModel login);
       
        bool ActiveAccount(string activeCode);
       
        User getUserByEmail(string Email);

        User getUserByActiveCode(string activeCode);
        void UpdateUser(User user);
    }
}
