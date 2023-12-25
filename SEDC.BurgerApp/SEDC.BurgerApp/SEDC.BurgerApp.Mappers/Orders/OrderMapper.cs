using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.Mappers.Orders
{
    public static class OrderMapper
    {
        public static OrderListViewModel ToOrderListViewModel(this Order order)
        {
            var price = CalculateOrderPrice(order);
            return new OrderListViewModel
            {
                OrderId = order.Id,
                OrderName = order.FullName,
                IsDelivered = order.IsDelivered,
                Address = order.Address,
                Location = order.Location,
                TotalPrice = price,
                burgerOrders = order.BurgerOrders.ToList(),                
            };
        }

        public static OrderDetailsViewModel ToOrderDetailsViewModel(Order order)
        {
            var price = CalculateOrderPrice(order);
            return new OrderDetailsViewModel
            {
                OrderName = order.FullName,
                TotalPrice = price,
                Location = order.Location,
                Address = order.Address,
                IsDelivered = order.IsDelivered,
                burgerOrders = order.BurgerOrders,
                OrderId = order.Id
                
            };
        }

        public static int CalculateOrderPrice(Order order)
        {
            var price = 0;
            foreach(BurgerOrder burgerOrder in order.BurgerOrders)
            {
                price += burgerOrder.Burger.Price;
            }
            return price;
        }

        public static Order NewOrder(this CreateOrderViewModel model)
        {
            return new Order
            {
                IsDelivered = model.IsDelivered,
                BurgerId = model.BurgerId,
                FullName = model.OrderName,
                Location = model.OrderLocation,
                Address = model.OrderAddress,
                Id = model.OrderId
            };
        }
    }
}
