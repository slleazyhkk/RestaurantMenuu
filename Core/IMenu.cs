﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Core.Dishes;

namespace Model.Core
{
    public interface IMenu
    {
        string MenuType();
        List<Dish> Dishes { get; }

        void AddDish(Dish dish);
        void RemoveDish(Dish dish);
        void ClearMenu();
    }
}
