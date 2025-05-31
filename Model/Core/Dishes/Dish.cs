using System.Text;

namespace Model.Core.Dishes
{
    public abstract class Dish
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public int WeightGramm {  get; private set; }
        protected Dish(string name, decimal price,int weight, string description = "")
        {
            Name = name;
            Price = price;
            WeightGramm = weight;
            Description = description;
        }
        public virtual string GetDishInfo() => $"{Name}-{Price}руб ({WeightGramm}г)";
        public override string ToString()
        {
            string inf = GetDishInfo();
            return string.IsNullOrEmpty(Description) ? inf : $"{inf}{Environment.NewLine} {Description}";
        }
    }

}
