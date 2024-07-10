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

        public CoupenCodeModel ApplyCoupen(string code)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@code" , code)
                };
                CoupenCodeModel itemAmount = _DBContext.Database.SqlQuery<CoupenCodeModel>("exec SP_GetAmountByCoupenApplied  @code", sqlParameters).FirstOrDefault();

                return itemAmount;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void createOrder(OrderModels orderView)
        {
            try
            {
                if (orderView.PromoCode == null)
                {
                    orderView.PromoCode = "0";
                }

                SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@totalItem" , orderView.TotalItems),
                    new SqlParameter("@totalAmount" , orderView.TotalPrice),
                    new SqlParameter("@cgst" , orderView.CSGST),
                    new SqlParameter("@sgst" , orderView.SGST),
                    new SqlParameter("@paybleAmount" , orderView.Payable),
                    new SqlParameter("@netpaybleAmount" , orderView.NetPaybleAmount),
                    new SqlParameter("@promo" , orderView.PromoCode),
                     new SqlParameter("@userId", orderView.userId),
                };

                int orderId = _DBContext.Database.SqlQuery<int>("exec SP_CreateNewOrder @totalItem  , @totalAmount  , @cgst  ,@sgst  , @paybleAmount  , @netpaybleAmount  , @promo , @userId", sqlParameter).FirstOrDefault();

                orderView.orderTable.ForEach(x =>
                {
                    SqlParameter[] sqlParameters = new SqlParameter[]
                    {
                        new SqlParameter("@itemName" , x.ItemName),
                        new SqlParameter("@itemQty" ,  x.ItemQuantity),
                        new SqlParameter("@itemAmt" , x.Price),
                        new SqlParameter("@orderId" ,  orderId),
                    };
                    _DBContext.Database.ExecuteSqlCommand("exec SP_AddItemDetails @itemName	,@itemQty,	@itemAmt	,@orderId ", sqlParameters);
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<OrderViewModel> FindOrderSearchList(FilterDataOrderModel filterDataOrderModel)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                        new SqlParameter("@startdate",filterDataOrderModel.StartDateFormatted),
                        new SqlParameter("@endDate",filterDataOrderModel.EndDateFormatted)
                };

                List<OrderViewModel> _OrderTable = _DBContext.Database.SqlQuery<OrderViewModel>("exec SearchOrders @startdate,@endDate", sqlParameters).ToList();
                return _OrderTable;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ItemMasterModel GetItemDetails(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@itemId" , id)
                };
                ItemMasterModel itemAmount = _DBContext.Database.SqlQuery<ItemMasterModel>("exec SP_GetItemDetailsById @itemId", sqlParameters).FirstOrDefault();
                return itemAmount;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

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

        public List<OrderViewModel> GetOrderList(OrderViewModel order)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@userId" , order.UserId)
                };
                List<OrderViewModel> _orderList = _DBContext.Database.SqlQuery<OrderViewModel>("exec SP_GetOrderList @userId = 1").ToList();
                return _orderList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
