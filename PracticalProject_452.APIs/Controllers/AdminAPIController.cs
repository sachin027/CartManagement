using PracticalProject_452.Models.ViewModel;
using PracticalProject_452.Repository.Interface;
using PracticalProject_452.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PracticalProject_452.APIs.Controllers
{
    public class AdminAPIController : ApiController
    {
        IAdminInterface _adminInterface = new AdminService();

        [Route("api/AdminAPI/GetOrderDetail")]
        public List<ItemViewModel> GetOrderDetail(int id)
        {
            try
            {
                List<ItemViewModel> itemViewModels = _adminInterface.GetOrderDetails(id);
                return itemViewModels;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("api/AdminAPI/CreateOrder")]

        public void CreateOrder(OrderModels orderView)
        {
            try
            {
                _adminInterface.createOrder(orderView);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("api/AdminAPI/GetAllOrderList")]
        public List<OrderViewModel> GetAllOrderList(OrderViewModel order)
        {
            try
            {
                List<OrderViewModel> orders = _adminInterface.GetOrderList(order);
                return orders;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("api/AdminAPI/ApplyCoupenOnItem")]
        public CoupenCodeModel ApplyCoupenOnItem(string Coupencode)
        {
            try
            {
                string coupenCode = Coupencode == null ? "0" : Coupencode;
              
                CoupenCodeModel itemAmount = _adminInterface.ApplyCoupen(coupenCode);
                return itemAmount;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        

        [Route("api/AdminAPI/GetAllItemDetails")]
        public ItemMasterModel GetAllItemDetails(int id)
        {
            try
            {
                ItemMasterModel itemAmount = _adminInterface.GetItemDetails(id);
                return itemAmount;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("api/AdminAPI/OrderSearchList")]
        public List<OrderViewModel> OrderSearchList(FilterDataOrderModel filterDataOrderModel)
        {
            try
            {
                List<OrderViewModel> _orderTable = _adminInterface.FindOrderSearchList(filterDataOrderModel);
                return _orderTable;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}