using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Dishes
{
    public class ColdDish:Dish
    {
        public string CuisineType { get; set; }
        public ColdDish(string name, decimal price, int weight, string cuisineType, string description = "") : base(name, price, weight, description)
        {
            CuisineType = cuisineType;
        }
        public override string GetDishInfo() => $"{base.GetDishInfo()} ({CuisineType})";
    }
}
