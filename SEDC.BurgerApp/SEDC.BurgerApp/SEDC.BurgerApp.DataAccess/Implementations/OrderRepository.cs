using SEDC.BurgerApp.DataAccess.Interfaces;
using SEDC.BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.DataAccess.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        public void DeleteById(int id)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(o => o.Id == id);
            if(orderDb == null)
            {
                throw new Exception("Invalid order id");
            }
            StaticDb.Orders.Remove(orderDb);
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public Order GetById(int id)
        {
            return StaticDb.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void Insert(Order entity)
        {
            entity.Id = ++StaticDb.OrderId;
            StaticDb.Orders.Add(entity);
        }

        public void Update(Order entity)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == entity.Id);
            int index = StaticDb.Orders.IndexOf(orderDb);
            StaticDb.Orders[index] = entity;
        }
    }
}
