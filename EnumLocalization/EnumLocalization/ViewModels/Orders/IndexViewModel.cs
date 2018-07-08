using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnumLocalization.ViewModels.Orders
{
    public class IndexViewModel
    {
        public IEnumerable<OrderViewModel> Items { get; set; }
    }
}