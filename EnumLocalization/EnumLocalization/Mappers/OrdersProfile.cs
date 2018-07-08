using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EnumLocalization.Models;
using EnumLocalization.ViewModels.Orders;

namespace EnumLocalization.Mappers
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}