using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMenu2.Restaurant.Samurai
{
    public partial class FormSamurai1 : Form
    {
        private Form _previousForm;
        public FormSamurai1(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSamurai2 formSamurai2 = new FormSamurai2();
            formSamurai2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _previousForm.Show();
            this.Hide();
        }

        private void FormSamurai1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
