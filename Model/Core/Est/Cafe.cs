using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Est
{
    public class Cafe : Establishment
    {
        public Cafe(string name, string address, string phone) : base(name, address, phone) { }
        public override string GetEstablishmentType()
        {
            return "Кафе";
        }
    }
}
