﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Dishes
{
    public class Drink:Dish
    {
        public bool IsAlcoholic { get;private set; }
        public int VolumeML {  get;private set; }
        public Drink(string name,decimal price,int volume,bool isAlcoholic=false,string desription="") : base(name, price, volume, desription)
        {
            VolumeML = volume;
            IsAlcoholic = isAlcoholic;
        }
        public override string GetDishInfo() => $"{base.GetDishInfo()}{VolumeML}мл {(IsAlcoholic ? "(Alcoholic)" : "")}";
    }
}
