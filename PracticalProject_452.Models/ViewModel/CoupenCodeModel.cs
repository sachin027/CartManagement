using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalProject_452.Models.ViewModel
{
    public class CoupenCodeModel
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public Nullable<int> FlatAmount { get; set; }
        public Nullable<int> Percentage { get; set; }
        public Nullable<System.DateTime> Expirydate { get; set; }
        public Nullable<int> UsageLimit { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public int success { get; set; }
    }
}
