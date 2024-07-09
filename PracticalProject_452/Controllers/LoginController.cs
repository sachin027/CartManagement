using Newtonsoft.Json;
using PracticalProject_452.Models.DBContext;
using PracticalProject_452.Models.ViewModel;
using PracticalProject_452.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PracticalProject_452.Controllers
{
    public class LoginController : Controller
    {
        PracticalTask_452Entities _DBContext = new PracticalTask_452Entities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string content = JsonConvert.SerializeObject(login);
                    string response = await WebHelpers.HttpRequestResponce("api/LoginAPI/LoginAccount", content);

                    UserModel loginModel = JsonConvert.DeserializeObject<UserModel>(response);
                    var cookie = new HttpCookie("jwt", loginModel.Token)
                    {
                        HttpOnly = true,
                        // Secure = true, // Uncomment this line if your application is running over HTTPS
                    };
                    Response.Cookies.Add(cookie);

                    var usr = _DBContext.Users.Where(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefault();
                    if (usr != null)
                    {
                        SessionHelper.SessionHelper.EmailID = usr.Email;
                        SessionHelper.SessionHelper.UserName = usr.UserName;
                        SessionHelper.SessionHelper.UserID = usr.UserId;
                        Session["username"] = usr.UserName;
                        TempData["success"] = "Login Successfully";
                        return RedirectToAction("AdminHomepage", "Admin");
                    }
                    else
                    {
                        TempData["error"] = "something went wrong!";
                        return RedirectToAction("Login", "Login");
                    }
                }
                else
                {
                    TempData["error"] = "something went wrong!";
                    return View(login);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }

    }
}