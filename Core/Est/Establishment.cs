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
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string AdminPhone { get; private set; }
        public string DayNHoursOfWork { get;private set; }
        public IMenu RegularMenu { get;private set; }
        public IMenu SeasonMenu { get;private set; }
        public bool HasSeasonMenu=>SeasonMenu!=null&& SeasonMenu.Dishes.Any();

        protected Establishment(string name, string address, string adminPhone, string work)
        {
            Name = name;
            Address = address;
            AdminPhone = adminPhone;
            DayNHoursOfWork = work;
            RegularMenu = new ChangeMenu();
            SeasonMenu = new ChangeMenu();
        }
        public abstract string GetEstablishmentType();
        public delegate void UpdateMenu(object sender, EventArgs e);
        public event UpdateMenu MenuIsUpdated;
        protected virtual void OnMenuUpdated()
        {
            MenuIsUpdated?.Invoke(this, EventArgs.Empty);
        }

        // 3. Использование в методах изменения меню
        public void AddSeasonDish(Dish dish)
        {
            SeasonMenu.AddDish(dish);
            OnMenuUpdated(); // Уведомление подписчиков
        }

        public void RemoveSeasonDish(Dish dish)
        {
            SeasonMenu.RemoveDish(dish);
            OnMenuUpdated(); // Уведомление подписчиков
        }

        public void ClearSeasonMenu()
        {
            SeasonMenu.ClearMenu();
            OnMenuUpdated(); // Уведомление подписчиков
        }
    }
}
