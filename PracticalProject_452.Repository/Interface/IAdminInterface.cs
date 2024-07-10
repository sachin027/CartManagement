using PracticalProject_452.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalProject_452.Repository.Interface
{
    public interface IAdminInterface
    {
        List<ItemViewModel> GetOrderDetails(int id);

        void createOrder(OrderModels orderModels);

        List<OrderViewModel> GetOrderList(OrderViewModel order);

        CoupenCodeModel ApplyCoupen(string code);

        ItemMasterModel GetItemDetails(int id);

        List<OrderViewModel> FindOrderSearchList(FilterDataOrderModel filterDataOrderModel);
    }
}
