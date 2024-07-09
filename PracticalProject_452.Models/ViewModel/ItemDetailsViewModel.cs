using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalProject_452.Models.ViewModel
{
    public class ItemDetailsViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> ItemQty { get; set; }
        public Nullable<decimal> ItemAmount { get; set; }
        public Nullable<int> OrderId { get; set; }
    }
}
