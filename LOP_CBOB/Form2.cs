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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1 = new ListBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            for (int i = listBox2.SelectedItems.Count - 1; i >= 0; i--)
            {
                var item = listBox2.SelectedItems[i];
                listBox1.Items.Add(item);
                listBox2.Items.Remove(item);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                var item = listBox2.Items[i];
                listBox1.Items.Add(item);
                listBox2.Items.Remove(item);
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
            {
                var item = listBox1.SelectedItems[i];
                listBox2.Items.Add(item);
                listBox1.Items.Remove(item);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                var item = listBox1.Items[i];
                listBox2.Items.Add(item);
                listBox1.Items.Remove(item);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(textBox2.Text);
            textBox2.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = listBox2.SelectedItems.Count - 1; i >= 0; i--)
            {
                var item = listBox2.SelectedItems[i];
                listBox2.Items.Remove(item);
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox2.Items.Add(textBox2.Text);
                textBox2.Clear();
            }
        }
    }
}
