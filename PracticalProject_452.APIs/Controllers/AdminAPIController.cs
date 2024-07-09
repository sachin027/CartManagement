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
    }
}