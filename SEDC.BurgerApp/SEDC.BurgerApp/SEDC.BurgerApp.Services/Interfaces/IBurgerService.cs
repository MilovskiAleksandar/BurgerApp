using SEDC.BurgerApp.ViewModels.Burgers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.Services.Interfaces
{
    public interface IBurgerService
    {
        List<BurgerListViewModel> GetAllBurgers();
        List<BurgerDropDownViewModel> BurgersForDropDown();
        BurgerDetailsViewModel GetBurgerDetails(int id);
        void CreateBurger(CreateBurgerViewModel model);
        void DeleteBurger(int id);
        List<string> ShowMostPopularBurger();
    }
}
