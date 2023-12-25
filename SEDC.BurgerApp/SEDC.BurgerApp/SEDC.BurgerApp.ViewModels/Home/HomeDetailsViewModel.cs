using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.ViewModels.Home
{
    public class HomeDetailsViewModel
    {
        public List<string> MostPopularBurger { get; set; }
        public int NumberOfOrdersInTheApp { get; set; }

        public int AveragePrice { get; set; }

        public List<string> Locations { get; set; }

    }
}
