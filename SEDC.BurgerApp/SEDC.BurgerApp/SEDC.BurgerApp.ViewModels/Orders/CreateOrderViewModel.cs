using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.ViewModels.Orders
{
    public class CreateOrderViewModel
    {
        [Display(Name = "Burgers")]
        public int BurgerId { get; set; }

        [Display(Name = "Is order delivered")]
        public bool IsDelivered { get; set; }

        [Display(Name = "Enter order name")]
        public string OrderName { get; set; }

        [Display(Name = "Address")]
        public string OrderAddress { get; set; }

        [Display(Name = "Location")]
        public string OrderLocation { get; set; }

        public int OrderId { get; set; }
    }
}
