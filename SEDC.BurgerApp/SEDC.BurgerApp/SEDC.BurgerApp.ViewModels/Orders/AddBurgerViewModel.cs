using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.ViewModels.Orders
{
    public class AddBurgerViewModel
    {
        [Display(Name ="Burger")]
        public int BurgerId { get; set; }
        public int OrderId { get; set; }
    }
}
