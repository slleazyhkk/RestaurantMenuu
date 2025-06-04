using Model.Core.Dishes;
using Model.Core.Est;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model.Data;

namespace RestaurantMenu2.Cafe.Brioche
{
    public partial class FormBrioche2 : Form
    {
        //var establishments = DataInitializer.GetEstablishments();
        public FormBrioche2()
        {
            InitializeComponent();
            LoadGastronomicaDishes();
        }

        private void LoadGastronomicaDishes()
        {
            // Получаем все заведения
            var establishments = DataInitializer.GetEstablishments();

            // Находим "Гастрономику"
            var gastronomica = establishments.Find(e => e.Name == "Гастрономика");

            if (gastronomica == null)
            {
                MessageBox.Show("Ресторан 'Гастрономика' не найден!");
                return;
            }

            // Настраиваем DataGridView
            dataGridView1.AutoGenerateColumns = false;

            // Добавляем столбцы
            dataGridView1.Columns.Add("Name", "Блюдо");
            dataGridView1.Columns.Add("Price", "Цена (₽)");
            dataGridView1.Columns.Add("WeightGramm", "Вес (г)");
            dataGridView1.Columns.Add("Description", "Описание");
            dataGridView1.Columns.Add("MenuType", "Тип меню");

            // Загружаем блюда
            var dishesToShow = new List<DishDisplay>();

            // Основное меню
            foreach (var dish in gastronomica.RegularMenu.Dishes)
            {
                dishesToShow.Add(new DishDisplay(dish, "Основное"));
            }

            // Сезонное меню (если есть)
            if (gastronomica.HasSeasonMenu)
            {
                foreach (var dish in gastronomica.SeasonMenu.Dishes)
                {
                    dishesToShow.Add(new DishDisplay(dish, "Сезонное"));
                }
            }

            dataGridView1.DataSource = dishesToShow;
        }
        public class DishDisplay
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int WeightGramm { get; set; }
            public string Description { get; set; }
            public string MenuType { get; set; }

            public DishDisplay(Dish dish, string menuType)
            {
                Name = dish.Name;
                Price = dish.Price;
                WeightGramm = dish.Weight;
                Description = dish.Description;
                MenuType = menuType;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormBrioche2_Load(object sender, EventArgs e)
        {

        }
    }
}
