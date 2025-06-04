using Model.Core;
using Model.Core.Dishes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMenu2.Restaurant.Gastronomy
{
    public partial class AddDishGastronomy : Form
    {
        public AddDishGastronomy()
        {
            InitializeComponent();
            Text = "Добавить блюдо";
        }
        public Dish dish {  get; private set; }
        private void AddDishGastronomy_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Введите название блюда", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // ... остальные проверки ...

            if (dish == null) // Если создаем новое блюдо
            {
                dish = new Dish(
                    textBox1.Text,
                    numericUpDown1.Value,
                    (int)numericUpDown2.Value,
                    comboBox1.Text,
                    textBox2.Text);
            }
            else // Если редактируем существующее
            {
                // Изменяем существующее блюдо через методы
                dish.NewName(textBox1.Text);
                dish.NewPrice(numericUpDown1.Value);
                dish.NewWeight((int)numericUpDown2.Value);
                dish.NewDishType(comboBox1.Text);
                dish.NewDescription(textBox2.Text);

                // Не создаем новый объект Dish!
            }

            DialogResult = DialogResult.OK;
            Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
