using PracticalProject_452.APIs.JWTAuthentication;
using PracticalProject_452.Models.ViewModel;
using PracticalProject_452.Repository.Interface;
using PracticalProject_452.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PracticalProject_452.APIs.Controllers
{
    public class LoginAPIController : ApiController
    {
        ILoginInterface _loginInterface = new LoginService();
        // GET: LoginAPI

        [HttpPost]
        [Route("api/LoginAPI/LoginAccount")]
        public UserModel LoginAccount(UserModel user)
        {
            try
            {
                UserModel loginModel = _loginInterface.LoginAccount(user);
                loginModel.Token = Authentication.GenerateJWTAuthetication(loginModel.UserName);
                return loginModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}