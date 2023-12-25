using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.ViewModels.Burgers
{
    public class CreateBurgerViewModel
    {
        public int BurgerId { get; set; }
        [Display(Name ="Burger name")]
        public string BurgerName { get; set; }
        [Display(Name = "Burger price")]
        public int BurgerPrice { get; set; }
        [Display(Name = "Burger is vegetarian")]
        public bool BurgerIsVegetarian { get; set; }
        [Display(Name = "Burger is vegan")]
        public bool BurgerIsVegan { get; set; }
        [Display(Name = "Burger has fries")]
        public bool BurgerHasFries { get; set; }
    }
}
