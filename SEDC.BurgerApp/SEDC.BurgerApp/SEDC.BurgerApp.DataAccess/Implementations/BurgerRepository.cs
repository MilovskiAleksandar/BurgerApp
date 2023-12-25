using SEDC.BurgerApp.DataAccess.Interfaces;
using SEDC.BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.DataAccess.Implementations
{
    public class BurgerRepository : IRepository<Burger>
    {
        public void DeleteById(int id)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(b => b.Id == id);
            if (burger == null)
            {
                throw new Exception("Burger with ID not found");
            }
            StaticDb.Burgers.Remove(burger);
        }

        public List<Burger> GetAll()
        {
            return StaticDb.Burgers;
        }

        public Burger GetById(int id)
        {
            return StaticDb.Burgers.FirstOrDefault(b => b.Id == id);
        }

        public void Insert(Burger entity)
        {
            entity.Id = ++StaticDb.BurgerId;
            StaticDb.Burgers.Add(entity);
        }

        public void Update(Burger entity)
        {
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Id == entity.Id);
            int index = StaticDb.Burgers.IndexOf(burgerDb);
            StaticDb.Burgers[index] = entity;
        }
    }
}
