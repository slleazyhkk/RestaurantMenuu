using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Dishes
{
    public class Dessert:Dish
    {
        public bool ContainsSugar { get; set; }

        public Dessert(string name, decimal price, int weight, bool containsSugar = true,
                      string description = "")
            : base(name, price, weight, description)
        {
            ContainsSugar = containsSugar;
        }

        public override string GetDishInfo() =>
            $"{base.GetDishInfo()} {(ContainsSugar ? "" : "(Без сахара)")}";
    }
}
