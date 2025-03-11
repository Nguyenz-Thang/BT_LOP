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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t = comboBox1.SelectedItem.ToString();
            txt.Text = t;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(txt.Text);
            txt.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Remove(txt.Text);
        }
    }
}
