using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.Models;
using SEDC.BurgerApp.Services.Implementations;
using SEDC.BurgerApp.Services.Interfaces;
using SEDC.BurgerApp.ViewModels.Home;
using SEDC.BurgerApp.ViewModels.Orders;
using System.Diagnostics;

namespace SEDC.BurgerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;
        private readonly IBurgerService _burgerService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _orderService = new OrderService();
            _burgerService = new BurgerService();
        }

        public IActionResult Index()
        {
            List<OrderListViewModel> orders = _orderService.GetAllOrders();
            if (orders.Count == 0)
            {
                return new EmptyResult();
            }
            //AVERAGE PRICE
            int totalSum = orders.Sum(o => o.TotalPrice);
            int averageSum = totalSum / orders.Count;

            //TOTAL ORDERS
            int totalOrders = _orderService.GetAllOrders().Count;

            //LOCATIONS
            List<string> locationDisplay = orders
                .Select(o => o.Location)
                .Distinct()
                .ToList();

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel
            {
                NumberOfOrdersInTheApp = totalOrders,
                MostPopularBurger = _burgerService.ShowMostPopularBurger(),
                AveragePrice = averageSum,
                Locations = locationDisplay

            };
            return View(homeDetailsViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}