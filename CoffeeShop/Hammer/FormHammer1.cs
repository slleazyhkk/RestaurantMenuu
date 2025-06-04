using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMenu2.CoffeeShop.Hammer
{
    public partial class FormHammer1 : Form
    {
        private Form _previousForm;
        public FormHammer1(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHammer2 formHammer2 = new FormHammer2();
            formHammer2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _previousForm.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormHammer1_Load(object sender, EventArgs e)
        {

        }
    }
}
