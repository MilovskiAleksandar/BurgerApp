using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.Services.Implementations;
using SEDC.BurgerApp.Services.Interfaces;
using SEDC.BurgerApp.ViewModels.Orders;

namespace SEDC.BurgerApp.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IBurgerService _burgerService;
        public OrderController()
        {
            _orderService = new OrderService();
            _burgerService = new BurgerService();
        }
        public IActionResult Index()
        {
            List<OrderListViewModel> orders = _orderService.GetAllOrders();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id);
            return View(orderDetailsViewModel);
        }

        public IActionResult CreateOrder()
        {
            CreateOrderViewModel createOrderViewModel = new CreateOrderViewModel();
            ViewBag.Burgers = _burgerService.BurgersForDropDown();
            return View(createOrderViewModel);
        }

        [HttpPost]
        public IActionResult CreateOrderPost(CreateOrderViewModel model)
        {
            _orderService.CreateOrder(model);
            return RedirectToAction("Index");
        }

        public IActionResult AddBurger(int id)
        {
            AddBurgerViewModel addBurgerViewModel = new AddBurgerViewModel();
            addBurgerViewModel.OrderId = id;

            ViewBag.Burgers = _burgerService.BurgersForDropDown();
            return View(addBurgerViewModel);
        }

        [HttpPost]
        public IActionResult AddBurgerPost(AddBurgerViewModel model)
        {
            
            
                _orderService.AddBurgerToOrder(model);
                return RedirectToAction("Index", new { id = model.OrderId });
            

        }

        public IActionResult DeleteOrder(int id)
        {
            if(id == null)
            {
                throw new Exception("Invalid ID");
            }

            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id);
                return View(orderDetailsViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid ID VALUE");
            }
        }

        public IActionResult ConfirmDelete(int id)
        {
            if (id == null)
            {
                throw new Exception("Invalid ID");
            }
            _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}
