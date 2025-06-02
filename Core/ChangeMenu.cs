using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Core.Dishes;

namespace Model.Core
{
    public partial class ChangeMenu:IMenu
    {
        public virtual string MenuType() => "Постоянное меню";
        public List<Dish> Dishes { get; set; }
        
        public void AddDish(Dish dish)
        {
            if (dish != null && !Dishes.Contains(dish))  Dishes.Add(dish);
        }

        public void ClearMenu()
        {
            Dishes.Clear();
        }

        public void RemoveDish(Dish dish)
        {
            if (dish != null && Dishes.Contains(dish)) Dishes.Remove(dish);
        }
    }
}
