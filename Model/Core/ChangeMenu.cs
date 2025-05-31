using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Core.Dishes;

namespace Model.Core
{
    public partial class ChangeMenu : IMenu
    {
        public string Name { get; set; }
        public List<Dish> Dishes { get; set; }
        public ChangeMenu(string name)
        {
            Name = name;
            Dishes = new List<Dish>();
        }
        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
        }

        public void ClearMenu()
        {
            Dishes.Clear();
        }

        public void RemoveDish(Dish dish)
        {
            Dishes.Remove(dish);
        }
    }
}
