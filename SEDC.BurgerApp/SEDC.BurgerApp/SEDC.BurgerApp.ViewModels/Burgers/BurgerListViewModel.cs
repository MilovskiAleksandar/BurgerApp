using SEDC.BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.ViewModels.Burgers
{
    public class BurgerListViewModel
    { 
        public int Id { get; set; }
        public string BurgerName { get; set; }
        public int BurgerPrice { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool HasFries { get; set; }
    }
}
