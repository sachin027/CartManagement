using PracticalProject_452.Models.DBContext;
using PracticalProject_452.Models.ViewModel;
using PracticalProject_452.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalProject_452.Repository.Services
{
    public class LoginService : ILoginInterface
    {
        PracticalTask_452Entities _DBContext = new PracticalTask_452Entities();
        public UserModel LoginAccount(UserModel user)
        {
            try
            {
                UserModel userModel = new UserModel();

                Users isUserExist = _DBContext.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                if (isUserExist != null)
                {
                    userModel.Email = isUserExist.Email;
                    userModel.Password = isUserExist.Password;
                    userModel.UserName = isUserExist.UserName;
                    return userModel;
                }
                else
                {
                    return userModel;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
