using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMenu2
{
    public partial class Form1 : Form
    {
        private FormRestaurant _formRestaurant;
        private FormCafe _formCafe;
        private FormCoffeeShop _formCoffeeShop;
        private FormAll _formAll;
        public Form1()
        {
            InitializeComponent();
            //comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new string[] { "Ресторан", "Кафе", "Кофейня", "Все типы заведений" });
            comboBox2.SelectedIndex = -1; // Сброс выбора
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1) return;

            switch (comboBox2.SelectedItem.ToString())
            {
                case "Ресторан":
                    ShowForm(ref _formRestaurant, () => new FormRestaurant());
                    break;
                case "Кафе":
                    ShowForm(ref _formCafe, () => new FormCafe());
                    break;
                case "Кофейня":
                    ShowForm(ref _formCoffeeShop, () => new FormCoffeeShop());
                    break;
                case "Все типы заведений":
                    ShowForm(ref _formAll, () => new FormAll());
                    break;
            }
        }
        private void ShowForm<T>(ref T formField, Func<T> formCreator) where T : Form
        {
            if (NeedNewForm(formField))
            {
                formField = formCreator();
                ConfigureForm(formField);
            }

            formField.Show();
            formField.BringToFront();
            this.Hide();
        }

        private bool NeedNewForm<T>(T form) where T : Form
        {
            return form == null || form.IsDisposed;
        }

        private void ConfigureForm<T>(T form) where T : Form
        {
            form.FormClosed += (sender, e) =>
            {
                if (form == _formRestaurant) _formRestaurant = null;
                else if (form == _formCafe) _formCafe = null;
                else if (form == _formCoffeeShop) _formCoffeeShop = null;
                else if (form == _formAll) _formAll = null;
            };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
