using RestaurantMenu2.Cafe.Brioche;
using RestaurantMenu2.CoffeeShop.Hammer;
using RestaurantMenu2.CoffeeShop.Sugar;
using RestaurantMenu2.Restaurant.Gastronomy;
using RestaurantMenu2.Restaurant.Samurai;
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
    public partial class FormAll : Form
    {
        public FormAll()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormAll_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            FormGastronomy1 formGastronomy1 = new FormGastronomy1(this);
            formGastronomy1.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormSamurai1 formSamurai1 = new FormSamurai1(this);
            formSamurai1.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FormBrioche1 formBrioche1 = new FormBrioche1(this);
            formBrioche1.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormGreenCat1 formGreenCat1 = new FormGreenCat1(this);
            formGreenCat1.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            FormHammer1 formHammer1 = new FormHammer1(this);
            formHammer1.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            FormSugar1 formSugar1 = new FormSugar1(this);
            formSugar1.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
