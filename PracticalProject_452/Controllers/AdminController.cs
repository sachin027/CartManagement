using PracticalProject_452.Models.DBContext;
using PracticalProject_452.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalProject_452.Controllers
{
    public class AdminController : Controller
    {

        PracticalTask_452Entities _DBContext = new PracticalTask_452Entities();
        // GET: Admin
        public ActionResult AdminHomepage()
        {
            List<ItemMaster> _ItemList = _DBContext.Database.SqlQuery<ItemMaster>("SP_GetItems").ToList();
            ViewBag.ItemList = _ItemList;
            return View();
        }
        public JsonResult GetItemDetails(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@itemId" , id)
                };
                ItemMasterModel itemAmount = _DBContext.Database.SqlQuery<ItemMasterModel>("exec SP_GetItemDetailsById @itemId", sqlParameters).FirstOrDefault();
                return Json(itemAmount, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public ActionResult ApplyCoupen(string code)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@code" , code)
                };
                CoupenCodeModel itemAmount = _DBContext.Database.SqlQuery<CoupenCodeModel>("exec SP_GetAmountByCoupenApplied  @code", sqlParameters).FirstOrDefault();
                return Json(itemAmount, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}