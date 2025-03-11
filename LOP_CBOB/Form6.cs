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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lblKetQua.ForeColor = Color.Red;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            lblKetQua.ForeColor = Color.Black;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            lblKetQua.Font = new Font(lblKetQua.Font, lblKetQua.Font.Style ^ FontStyle.Italic);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lblKetQua.Text = txtTen.Text.Trim();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lblKetQua.ForeColor = Color.Green;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            lblKetQua.ForeColor = Color.Blue;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lblKetQua.Font = new Font(lblKetQua.Font, lblKetQua.Font.Style ^ FontStyle.Bold);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            lblKetQua.Font = new Font(lblKetQua.Font, lblKetQua.Font.Style^FontStyle.Underline);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lblKetQua.ForeColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                lblKetQua.Font = fontDialog1.Font;
            }   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    pictureBox1.Image.Save(saveFileDialog1.FileName);
            //}
            saveFileDialog1.DefaultExt = "jpg";
            openFileDialog1.ShowDialog();
            pictureBox1.Image.Save(openFileDialog1.FileName);

        }
    }
}
