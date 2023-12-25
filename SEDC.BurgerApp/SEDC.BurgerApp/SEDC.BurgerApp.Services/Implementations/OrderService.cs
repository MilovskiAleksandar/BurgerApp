using SEDC.BurgerApp.DataAccess.Implementations;
using SEDC.BurgerApp.DataAccess.Interfaces;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.Mappers.Orders;
using SEDC.BurgerApp.Services.Interfaces;
using SEDC.BurgerApp.ViewModels.Orders;

namespace SEDC.BurgerApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<Burger> _burgerRepository;
        public OrderService()
        {
            _orderRepository = new OrderRepository();
            _burgerRepository = new BurgerRepository();
        }

        public void AddBurgerToOrder(AddBurgerViewModel model)
        {
            Burger burgerDb = _burgerRepository.GetById(model.BurgerId);
            if(model.BurgerId == null)
            {
                throw new Exception("Burger doest exists");
            }
            Order orderDb = _orderRepository.GetById(model.OrderId);
            if(orderDb == null)
            {
                throw new Exception("Order not found");
            }
            orderDb.BurgerOrders.Add(new BurgerOrder
            {
                OrderId = model.OrderId,
                Burger = burgerDb,
                Order = orderDb,
                BurgerId = model.BurgerId,
            });

            _orderRepository.Update(orderDb);
        }

        public void CreateOrder(CreateOrderViewModel model)
        {

            Order newOrder = model.NewOrder();
            _orderRepository.Insert(newOrder);

        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteById(id);
        }

        public List<OrderListViewModel> GetAllOrders()
        {
            List<Order> ordersDb = _orderRepository.GetAll();
            List<OrderListViewModel> orderListViewModels = ordersDb.Select(x => x.ToOrderListViewModel()).ToList();
            return orderListViewModels;
        }

        //to change to burger button
        public OrderDetailsViewModel GetOrderDetails(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if(orderDb == null)
            {
                throw new Exception($"Order with id {id} was not found");
            }
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);
            return orderDetailsViewModel;
        }
    }
}
