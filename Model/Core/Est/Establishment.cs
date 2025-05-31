using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Est
{
    public abstract partial class Establishment
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string AdminPhone { get; set; }
        public ChangeMenu Menu { get; set; }

        protected Establishment(string name, string address, string adminPhone, ChangeMenu menu)
        {
            Name = name;
            Address = address;
            AdminPhone = adminPhone;
            Menu = new ChangeMenu("Меню");
        }
        public abstract string GetEstablishmentType();
    }
}
