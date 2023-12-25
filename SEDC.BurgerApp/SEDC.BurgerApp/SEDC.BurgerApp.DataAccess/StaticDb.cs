

using SEDC.BurgerApp.Domain.Models;

namespace SEDC.BurgerApp.DataAccess
{
    public static class StaticDb
    {
        public static int BurgerId { get; set; }
        public static int OrderId { get; set; }
        public static List<Burger> Burgers { get; set; }
        public static List<Order> Orders { get; set; }

        static StaticDb()
        {
            BurgerId = 4;
            OrderId = 3;
            Burgers = new List<Burger>()
            {
                new Burger
                {
                    Id = 1,
                    Name = "Hamburger",
                    Price = 200,
                    IsVegan = true,
                    IsVegetarian = true,
                    HasFries = false,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                },
                new Burger
                {
                    Id = 2,
                    Name = "Crispy",
                    Price = 230,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                },
                new Burger
                {
                    Id = 3,
                    Name = "Cheeseburger",
                    Price = 270,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                },
                new Burger
                {
                    Id = 4,
                    Name = "Napkin Burger",
                    Price = 300,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = false,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                }
            };
            Orders = new List<Order>()
            {
                new Order
                {
                    Id= 1,
                    FullName = "Ordering Burger",
                    Address = "Skopje",
                    IsDelivered = true,
                    Location = "Centar",
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 1,
                            Burger = Burgers[0],
                            OrderId = 1,
                            BurgerId = Burgers[0].Id
                        },

                        new BurgerOrder
                        {
                            Id = 2,
                            Burger = Burgers[1],
                            OrderId = 2,
                            BurgerId = Burgers[1].Id
                        }
                    },
                    Burger = Burgers[0]
                    

                },
                 new Order
                 {
                     Id=2,
                     FullName = "Ordering Second Burger",
                     Address = "Kicevo",
                     IsDelivered = false,
                     Location = "BulevarBB",
                     BurgerOrders = new List<BurgerOrder>
                     {
                         new BurgerOrder
                         {
                             Id = 3,
                             Burger = Burgers[1],
                             OrderId = 3,
                             BurgerId = Burgers[1].Id
                         }
                     },
                     Burger = Burgers[1]
                 },
                 new Order
                 {
                     Id=3,
                     FullName = "Ordering Third Burger",
                     Address = "Ohrid",
                     IsDelivered = true,
                     Location = "Uzicka",
                     BurgerOrders = new List<BurgerOrder>
                     {
                         new BurgerOrder
                         {
                             Id = 4,
                             Burger = Burgers[3],
                             OrderId = 4,
                             BurgerId = Burgers[3].Id
                         },
                         new BurgerOrder
                         {
                             Id = 5,
                             Burger = Burgers[2],
                             OrderId = 5,
                             BurgerId = Burgers[2].Id
                         }
                     },
                     Burger = Burgers[3]
                 },


            };
        }
    }
}
