using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Dishes
{
    public class HotDish : Dish
    {
        
        public HotDish(string name,decimal price,int weight,string cuisineType,string description="") : base(name, price,weight, description) { }
      
        public override string GetDishInfo() => $"{base.GetDishInfo()}";
    }
}
