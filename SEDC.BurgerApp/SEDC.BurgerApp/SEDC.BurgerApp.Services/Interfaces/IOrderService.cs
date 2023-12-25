using SEDC.BurgerApp.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAllOrders();
        OrderDetailsViewModel GetOrderDetails(int id);
        void CreateOrder(CreateOrderViewModel model);
        void AddBurgerToOrder(AddBurgerViewModel model);
        void DeleteOrder(int id);
    }
}
