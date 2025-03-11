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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Sua.Enabled = false;
            Xoa.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtHoVaTen.Text == "")
            {
                MessageBox.Show("Chưa nhập họ và tên !!!!!!", "TB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn giới tính !!!!!!", "TB", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            dgvSinhVien.Rows.Add(txtHoVaTen.Text, cbGioiTinh.SelectedItem.ToString(), dtNgaySinh.Value.ToString());
            cbGioiTinh.SelectedIndex = -1;
            txtHoVaTen.Text = "";
            dtNgaySinh.Value = DateTime.Now;


        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtHoVaTen.Text = dgvSinhVien.Rows[i].Cells[0].Value.ToString();
            cbGioiTinh.SelectedItem = dgvSinhVien.Rows[i].Cells[1].Value.ToString();
            dtNgaySinh.Value = DateTime.Parse(dgvSinhVien.Rows[i].Cells[2].Value.ToString());
            Luu.Enabled = false;
            Sua.Enabled = true;
            Xoa.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn sửa không ?", "TB", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            int i = dgvSinhVien.CurrentCell.RowIndex;
            dgvSinhVien.Rows[i].Cells[0].Value = txtHoVaTen.Text;
            dgvSinhVien.Rows[i].Cells[1].Value = cbGioiTinh.SelectedItem.ToString();
            dgvSinhVien.Rows[i].Cells[2].Value = dtNgaySinh.Value.ToString();
            txtHoVaTen.Text = "";
            dtNgaySinh.Value = DateTime.Now;

            Luu.Enabled = true;
            Sua.Enabled = false;
            Xoa.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "TB", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            dgvSinhVien.Rows.RemoveAt(dgvSinhVien.CurrentCell.RowIndex);
            Luu.Enabled = true;
            Sua.Enabled = false;
            Xoa.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "TB", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            Close();
        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
