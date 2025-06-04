using RestaurantMenu2.Cafe.Green_Cat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMenu2
{
    public partial class FormGreenCat1 : Form
    {
        private Form _previousForm;
        public FormGreenCat1(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormGreenCat2 formGreenCat2 = new FormGreenCat2();
            formGreenCat2.Show();
            this.Hide();
        }

        private void FormGreenCat1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _previousForm.Show();
            this.Hide();
        }
    }
}
