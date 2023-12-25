

namespace SEDC.BurgerApp.Domain.Models
{
    public class Order : BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public int BurgerId { get; set; }
        public Burger Burger { get; set; }
        public string Location { get; set; }

        public List<BurgerOrder> BurgerOrders { get; set; }
        public Order()
        {
            BurgerOrders = new List<BurgerOrder>();
        }
    }
}
