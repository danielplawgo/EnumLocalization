using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnumLocalization.Models
{
    public class Order
    {
        public string Number { get; set; }

        public OrderStatus Status { get; set; }
    }
}