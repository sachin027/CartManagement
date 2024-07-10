using Newtonsoft.Json;
using PracticalProject_452.CustomFilter;
using PracticalProject_452.Models.DBContext;
using PracticalProject_452.Models.ViewModel;
using PracticalProject_452.WebHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PracticalProject_452.Controllers
{
    [CustomAuthorization]
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
        public async Task<JsonResult> GetItemDetails(int id)
        {
            try
            {
                string url = $"api/AdminAPI/GetAllItemDetails?id={id}";
                string response = await WebHelpers.HttpRequestResponce(url);
                ItemMasterModel itemViews = JsonConvert.DeserializeObject<ItemMasterModel>(response);
                return Json(itemViews, JsonRequestBehavior.AllowGet);

                //SqlParameter[] sqlParameters = new SqlParameter[]
                //{
                //    new SqlParameter("@itemId" , id)
                //};
                //ItemMasterModel itemAmount = _DBContext.Database.SqlQuery<ItemMasterModel>("exec SP_GetItemDetailsById @itemId", sqlParameters).FirstOrDefault();
                //return Json(itemAmount, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<ActionResult> ApplyCoupen(string code)
        {
            try
            {
                string url = $"api/AdminAPI/ApplyCoupenOnItem?Coupencode={code}";
                string content = JsonConvert.SerializeObject(code);
                string response = await WebHelpers.HttpRequestResponce(url,content);
                CoupenCodeModel itemAmount = JsonConvert.DeserializeObject<CoupenCodeModel>(response);


                //SqlParameter[] sqlParameters = new SqlParameter[]
                //{
                //    new SqlParameter("@code" , code)
                //};
                //CoupenCodeModel itemAmount = _DBContext.Database.SqlQuery<CoupenCodeModel>("exec SP_GetAmountByCoupenApplied  @code", sqlParameters).FirstOrDefault();

                return Json(itemAmount, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        //public ActionResult CreateOrder(OrderModels orderView )
        //{
        //    try
        //    {
        //        if(orderView.PromoCode == null)
        //        {
        //            orderView.PromoCode = "0";
        //        }

        //        SqlParameter[] sqlParameter = new SqlParameter[]
        //        {
        //            new SqlParameter("@totalItem" , orderView.TotalItems),
        //            new SqlParameter("@totalAmount" , orderView.TotalPrice),
        //            new SqlParameter("@cgst" , orderView.CSGST),
        //            new SqlParameter("@sgst" , orderView.SGST),
        //            new SqlParameter("@paybleAmount" , orderView.Payable),
        //            new SqlParameter("@netpaybleAmount" , orderView.NetPaybleAmount),
        //            new SqlParameter("@promo" , orderView.PromoCode),
        //             new SqlParameter("@userId", orderView.userId),
        //        };

        //        int orderId = _DBContext.Database.SqlQuery<int>("exec SP_CreateNewOrder @totalItem  , @totalAmount  , @cgst  ,@sgst  , @paybleAmount  , @netpaybleAmount  , @promo , @userId" , sqlParameter).FirstOrDefault();

        //        orderView.orderTable.ForEach(x =>
        //        {
        //            SqlParameter[] sqlParameters = new SqlParameter[]
        //            {
        //                new SqlParameter("@itemName" , x.ItemName),
        //                new SqlParameter("@itemQty" ,  x.ItemQuantity),
        //                new SqlParameter("@itemAmt" , x.Price),
        //                new SqlParameter("@orderId" ,  orderId),
        //            };
        //            _DBContext.Database.ExecuteSqlCommand("exec SP_AddItemDetails @itemName	,@itemQty,	@itemAmt	,@orderId ", sqlParameters);
        //        });
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        public async Task<ActionResult> CreateOrder(OrderModels orderView)
        {
            try
            {
                string url = "api/AdminAPI/CreateOrder";
                string content = JsonConvert.SerializeObject(orderView);
                string response = await WebHelpers.HttpRequestResponce(url, content);

                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public async Task<ActionResult> OrderList(OrderViewModel order)
        //{
        //    try
        //    {
        //        string url = "api/AdminAPI/GetAllOrderList";
        //        string content = JsonConvert.SerializeObject(order);
        //        string response = await WebHelpers.HttpRequestResponce(url, content);

        //        List<OrderViewModel> _orderList = JsonConvert.DeserializeObject<List<OrderViewModel>>(response);


        //        //SqlParameter[] sqlParameters = new SqlParameter[]
        //        //{
        //        //    new SqlParameter("@userId" , order.UserId)
        //        //};
        //        //List<OrderViewModel> _orderList = _DBContext.Database.SqlQuery<OrderViewModel>("exec SP_GetOrderList @userId = 1").ToList();
        //        return View(_orderList);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //pagination try
        public async Task<ActionResult> OrderList(OrderViewModel order)
        {
            try
            {
                string url = "api/AdminAPI/GetAllOrderList";
                string content = JsonConvert.SerializeObject(order);
                string response = await WebHelpers.HttpRequestResponce(url, content);

                List<OrderViewModel> _orderList = JsonConvert.DeserializeObject<List<OrderViewModel>>(response);

                //int count = 5;
                //int? index
                //int current = index ?? 1;
                //List<OrderViewModel> _orderPageList = _orderList.Skip((current - 1) * count).Take(count).ToList();
                //PaginationModel paginationModel = new PaginationModel();
                //paginationModel._orderList = _orderPageList;
                //paginationModel.count = _orderList.Count();
                //paginationModel.current = current;
                return View(_orderList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        public async Task<ActionResult> OrderList(FilterDataOrderModel _FilterDataOrderModel)
        {
            try
            {

                string url = "api/AdminAPI/OrderSearchList";
                string content = JsonConvert.SerializeObject(_FilterDataOrderModel);
                string response = await WebHelpers.HttpRequestResponce(url, content);

                List<OrderViewModel> _OrderTable = JsonConvert.DeserializeObject<List<OrderViewModel>>(response);


                ViewBag.Email = SessionHelper.SessionHelper.EmailID;
                //List<OrderViewModel> _OrderTable = new List<OrderViewModel>();
                //SqlParameter[] sqlParameters = new SqlParameter[]
                //    {
                //        new SqlParameter("@startdate",_FilterDataOrderModel.StartDateFormatted),
                //        new SqlParameter("@endDate",_FilterDataOrderModel.EndDateFormatted)
                //    };
                ViewBag.startDate = _FilterDataOrderModel.StartDateFormatted;
                ViewBag.endDate = _FilterDataOrderModel.EndDateFormatted;
                //_OrderTable = _DBContext.Database.SqlQuery<OrderViewModel>("exec SearchOrders @startdate,@endDate", sqlParameters).ToList();
                ViewBag.totalcount = _OrderTable.Count();
                return View(_OrderTable);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public async Task<ActionResult> GetOrderDetails(int orderId)
        {
            try
            {
                string url = $"api/AdminAPI/GetOrderDetail?id={orderId}";
                string response = await WebHelpers.HttpRequestResponce(url);
                List<ItemViewModel> itemViews = JsonConvert.DeserializeObject<List<ItemViewModel>>(response);
                return Json(itemViews, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            // Assuming _DBContext is your DbContext or data access layer
            //    SqlParameter[] sqlParameters = new SqlParameter[]
            //    {
            //new SqlParameter("@orderId", orderId)
            //    };

            //    List<ItemViewModel> orderDetails = _DBContext.Database.SqlQuery<ItemViewModel>("exec SP_GetOrderDetails @orderId", sqlParameters).ToList();

            //    // Ensure you are returning JsonResult explicitly
            //    return Json(orderDetails, JsonRequestBehavior.AllowGet);
        }


        [AllowAnonymous]
        public ActionResult OrdersRecordListPdf(DateTime startDate, DateTime endDate)
        {
            List<Orders> orderRecords = _DBContext.Orders
              .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
              .ToList();

            ViewBag.startDate = startDate;
            ViewBag.endDate = endDate;
            ViewBag.totalcount = orderRecords.Count;

            return new Rotativa.ViewAsPdf("OrdersRecordListPdf", orderRecords)
            {
                FileName = "OrdersRecordListPdf.pdf",
                PageSize = Rotativa.Options.Size.A4
            };
        }
    }
}