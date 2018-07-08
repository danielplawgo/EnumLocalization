using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Bogus;
using EnumLocalization.Models;
using EnumLocalization.ViewModels.Orders;

namespace EnumLocalization.Controllers
{
    public class OrdersController : Controller
    {
        private static IEnumerable<Order> _orders;

        static OrdersController()
        {
            int orderNumber = 0;

            _orders = new Faker<Order>()
                .StrictMode(true)
                .RuleFor(u => u.Status, (f, u) => f.PickRandom<OrderStatus>())
                .RuleFor(u => u.Number, (f, u) => (++orderNumber).ToString())
                .Generate(10);
        }

        private Lazy<IMapper> _mapper;

        protected IMapper Mapper
        {
            get { return _mapper.Value; }
        }

        public OrdersController(Lazy<IMapper> mapper)
        {
            _mapper = mapper;
        }

        // GET: Orders
        public ActionResult Index()
        {
            var viewModel = new IndexViewModel();

            viewModel.Items = Mapper.Map<IEnumerable<OrderViewModel>>(_orders);

            return View(viewModel);
        }
    }
}