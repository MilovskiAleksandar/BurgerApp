using SEDC.BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.ViewModels.Orders
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int TotalPrice { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public bool IsDelivered { get; set; }

        public List<BurgerOrder> burgerOrders { get; set; }
    }
}
