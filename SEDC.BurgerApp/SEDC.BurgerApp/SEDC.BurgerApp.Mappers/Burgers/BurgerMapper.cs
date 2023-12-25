using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.ViewModels.Burgers;
using SEDC.BurgerApp.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.Mappers.Burgers
{
    public static class BurgerMapper
    {
        public static BurgerListViewModel ToBurgerListViewModel(this Burger burger)
        {
            return new BurgerListViewModel
            {
                BurgerName = burger.Name,
                BurgerPrice = burger.Price,
                HasFries = burger.HasFries,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                Id = burger.Id,
                
            };
        }

        public static BurgerDropDownViewModel ToBurgerDropDown(this Burger burger)
        {
            return new BurgerDropDownViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
            };
        }

        public static BurgerDetailsViewModel ToBurgerDetails(Burger burger)
        {
            return new BurgerDetailsViewModel
            {
                BurgerId = burger.Id,
                BurgerName = burger.Name,
                BurgerPrice = burger.Price,
                HasFries = burger.HasFries,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian
            };
        }

        public static Burger NewBurger(this CreateBurgerViewModel model, Burger burger)
        {
            return new Burger
            {
                Id = model.BurgerId,
                Name = burger.Name,
                HasFries = model.BurgerHasFries,
                IsVegan = model.BurgerIsVegan,
                IsVegetarian = model.BurgerIsVegetarian,
                Price = burger.Price
            };
        }
    }
}
