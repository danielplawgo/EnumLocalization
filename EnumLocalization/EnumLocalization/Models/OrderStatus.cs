using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnumLocalization.Resources;

namespace EnumLocalization.Models
{
    [EnumDescription(typeof(OrderStatusResources))]
    public enum OrderStatus
    {
        Created,
        Completed,
        Canceled
    }
}