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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n = int.Parse(comboBox1.SelectedItem.ToString());
            int t = 0;
            String snt = "";
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    if (i>1)
                    {
                        int kt = 0;
                        for (int j = 2; j < i; j++)
                        {
                            if (i % j == 0)
                            {
                                kt++;
                            }

                        }
                        if (kt == 0)
                        {
                            snt = snt + i + " - ";
                        }
                    }
                    
                }
                
            }
            MessageBox.Show("Các ước số nguyên tố: " + snt, "TB", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int n = int.Parse(comboBox1.SelectedItem.ToString());
            int t = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    if (i % 2 == 0)
                    {
                        t++;
                    }
                }
            }
            MessageBox.Show("Số lượng các ước số chẵn = " + t,"TB", MessageBoxButtons.OK);
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(txtCapNhat.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int n = int.Parse(comboBox1.SelectedItem.ToString());
            for (int i = 1; i < n; i++) { 
                if(n % i == 0)
                {
                    listBox1.Items.Add(i);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int n = int.Parse(comboBox1.SelectedItem.ToString());
            int t = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                        t += i ;
                }
            }
            MessageBox.Show("Tổng các ước số = " + t,"TB", MessageBoxButtons.OK);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
