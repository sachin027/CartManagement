using PracticalProject_452.Models.DBContext;
using PracticalProject_452.Models.ViewModel;
using PracticalProject_452.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalProject_452.Repository.Services
{
    public class AdminService : IAdminInterface
    {
        PracticalTask_452Entities _DBContext = new PracticalTask_452Entities();
        public List<ItemViewModel> GetOrderDetails(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                        new SqlParameter("@orderId", id)
                };

                List<ItemViewModel> orderDetails = _DBContext.Database.SqlQuery<ItemViewModel>("exec SP_GetOrderDetails @orderId", sqlParameters).ToList();
                return orderDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
