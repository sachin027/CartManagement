using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalProject_452.Models.ViewModel
{
    public class PaginationModel
    {
        public int count { get; set; }
        public int current { get; set; }
        public List<OrderViewModel> _orderList { get; set; }
    }
}
