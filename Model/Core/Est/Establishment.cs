using Model.Core.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Est
{
    public abstract partial class Establishment:ISeasonMenu
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string AdminPhone { get; set; }
        public IMenu RegularMenu { get; set; }
        public IMenu SeasonMenu { get; set; }
        public bool HasSeasonMenu=>SeasonMenu!=null&& SeasonMenu.Dishes.Any();

        protected Establishment(string name, string address, string adminPhone)
        {
            Name = name;
            Address = address;
            AdminPhone = adminPhone;
            RegularMenu = new ChangeMenu();
            SeasonMenu = new ChangeMenu();
        }
        public abstract string GetEstablishmentType();

        public void AddSeasonDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public void RemoveSeasonDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public void ClearSeasonMenu()
        {
            throw new NotImplementedException();
        }
    }
}
