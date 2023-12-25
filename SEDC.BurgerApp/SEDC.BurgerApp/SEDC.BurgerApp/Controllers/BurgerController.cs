using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.Services.Implementations;
using SEDC.BurgerApp.Services.Interfaces;
using SEDC.BurgerApp.ViewModels.Burgers;
using SEDC.BurgerApp.ViewModels.Orders;

namespace SEDC.BurgerApp.Controllers
{
    public class BurgerController : Controller
    {
        private IBurgerService _burgerService;
        public BurgerController()
        {
            _burgerService = new BurgerService();
        }
        public IActionResult Index()
        {
            List<BurgerListViewModel> burgers = _burgerService.GetAllBurgers();
            return View(burgers);
        }

        public IActionResult Details(int id)
        {
            BurgerDetailsViewModel burgerDetailsViewModel = _burgerService.GetBurgerDetails(id);
            return View(burgerDetailsViewModel);
        }

        public IActionResult CreateBurger()
        {
            CreateBurgerViewModel createBurgerViewModel = new CreateBurgerViewModel();
            ViewBag.Burgers = _burgerService.BurgersForDropDown();
            return View(createBurgerViewModel);
        }

        [HttpPost]
        public IActionResult CreateBurgerPost(CreateBurgerViewModel burgerViewModel)
        {
            _burgerService.CreateBurger(burgerViewModel);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteBurger(int id)
        {
            if (id == null)
            {
                throw new Exception("Invalid ID");
            }
            try
            {
                BurgerDetailsViewModel burgerDetailsViewModel = _burgerService.GetBurgerDetails(id);
                return View(burgerDetailsViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid ID VALUE");
            }
        }

        public IActionResult DeleteBurgerConfirm(int id)
        {
            if (id == null)
            {
                throw new Exception("Invalid ID");
            }
            _burgerService.DeleteBurger(id);
            return RedirectToAction("Index");
        }
    }
}
