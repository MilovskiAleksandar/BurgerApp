using SEDC.BurgerApp.DataAccess;
using SEDC.BurgerApp.DataAccess.Implementations;
using SEDC.BurgerApp.DataAccess.Interfaces;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.Mappers.Burgers;
using SEDC.BurgerApp.Services.Interfaces;
using SEDC.BurgerApp.ViewModels.Burgers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.Services.Implementations
{
    public class BurgerService : IBurgerService
    {
        private IRepository<Burger> _burgerRepository;
        public BurgerService()
        {
            _burgerRepository = new BurgerRepository();
        }
        public List<BurgerListViewModel> GetAllBurgers()
        {
            List<Burger> burgerDb = _burgerRepository.GetAll();
            List<BurgerListViewModel> burgerListViewModels = burgerDb.Select(x => x.ToBurgerListViewModel()).ToList();
            return burgerListViewModels;
        }

        public List<BurgerDropDownViewModel> BurgersForDropDown()
        {
            List<Burger> burgerDb = _burgerRepository.GetAll();
            List<BurgerDropDownViewModel> burgerListViewModels = burgerDb.Select(x => x.ToBurgerDropDown()).ToList();
            return burgerListViewModels;
        }

        public BurgerDetailsViewModel GetBurgerDetails(int id)
        {
            Burger burgerDb = _burgerRepository.GetById(id);
            if(burgerDb == null)
            {
                throw new Exception("Burger with the id not found");
            }

            BurgerDetailsViewModel burgerDetailsViewModel = BurgerMapper.ToBurgerDetails(burgerDb);
            return burgerDetailsViewModel;
        }

        public void CreateBurger(CreateBurgerViewModel model)
        {
            Burger newBurger = new Burger
            {
                Name = model.BurgerName,
                Price = model.BurgerPrice,
                IsVegetarian = model.BurgerIsVegetarian,
                IsVegan = model.BurgerIsVegan,
                HasFries = model.BurgerHasFries
            };
            _burgerRepository.Insert(newBurger);
        }

        public void DeleteBurger(int id)
        {
            _burgerRepository.DeleteById(id);
        }

        public List<string> ShowMostPopularBurger()
        {
            var burgerOrders = StaticDb.Orders
            .SelectMany(order => order.BurgerOrders)
            .GroupBy(burgerOrder => burgerOrder.BurgerId)
            .OrderByDescending(group => group.Count())
            .FirstOrDefault();

            if (burgerOrders == null)
            {
                return new List<string>();
            }

            var mostPopularBurgerNames = burgerOrders
                .Select(burgerOrder => burgerOrder.Burger.Name)
                .ToList();

            return mostPopularBurgerNames;
        }
    }
}
