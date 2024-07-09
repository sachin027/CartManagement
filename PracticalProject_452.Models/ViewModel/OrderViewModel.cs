using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalProject_452.Models.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public Nullable<int> TotalItems { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> Cgst { get; set; }
        public Nullable<decimal> Sgst { get; set; }
        public Nullable<decimal> PaybleAmount { get; set; }
        public Nullable<decimal> NetPaybleAmount { get; set; }
        public string PromoCode { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> UserId { get; set; }

        public string formattedDate => OrderDate?.ToString("dd-MM-yyyy");
    }

    public class ItemModel
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public int Price { get; set; }
        public int totalPrice { get; set; }

    }
    public class OrderModels
    {
        public List<ItemModel> orderTable { get; set; }

        public int TotalItems { get; set; }
        public int TotalPrice { get; set; }
        public int CSGST { get; set; }
        public int SGST { get; set; }
        public int Payable { get; set; }
        public int NetPaybleAmount { get; set; }
        public string PromoCode { get; set; }
        public int userId { get; set; }
    }
}
