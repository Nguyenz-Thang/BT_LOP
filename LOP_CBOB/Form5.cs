using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOP_CBOB
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSo1_TextChanged(object sender, EventArgs e)
        {

        }
        public bool kiemtra()
        {
            double so1, so2;
            so1 = double.Parse(txtSo1.Text);
            so2 = double.Parse(txtSo2.Text);
            if (so1 == 0)
            {
                MessageBox.Show("Số thứ nhất phải khác 0");
                txtSo1.Focus();
                return true;
            }
            if (so2 == 0)
            {
                MessageBox.Show("Số thứ hai phải khác 0");
                txtSo2.Focus();
                return true;
            }
            return false;
        }
        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            txtketQua.Text = (double.Parse(txtSo1.Text) + double.Parse(txtSo2.Text)).ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            txtketQua.Text = (double.Parse(txtSo1.Text) - double.Parse(txtSo2.Text)).ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtketQua.Text = (double.Parse(txtSo1.Text) * double.Parse(txtSo2.Text)).ToString();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            double so1, so2;
            if (!double.TryParse(txtSo1.Text, out so1))
            {
                MessageBox.Show("Số thứ nhất phải là số");
                txtSo1.Focus();
                return;
            }
            if (!double.TryParse(txtSo2.Text, out so2))
            {
                MessageBox.Show("Số thứ hai phải là số");
                txtSo2.Focus();
                return;
            }
            so1 = double.Parse(txtSo1.Text);
            so2 = double.Parse(txtSo2.Text);
            if (so1 == 0)
            {
                MessageBox.Show("Số thứ nhất phải khác 0");
                txtSo1.Focus();
                return;
            }
            if (so2 == 0)
            {
                MessageBox.Show("Số thứ hai phải khác 0");
                txtSo2.Focus();
                return;
            }
            
            txtketQua.Text = (double.Parse(txtSo1.Text) / double.Parse(txtSo2.Text)).ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
