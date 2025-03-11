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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            btCapNhat.Enabled = false;
            btXoa.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            int i = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows[i].Cells[0].Value = txtMaSV.Text;
            dataGridView1.Rows[i].Cells[1].Value = txtHoTen.Text;
            dataGridView1.Rows[i].Cells[2].Value = txtDiaChi.Text;
            dataGridView1.Rows[i].Cells[3].Value = dtNgaySinh.Value.ToString();
            dataGridView1.Rows[i].Cells[4].Value = cbBLop.SelectedItem.ToString();

            btThem.Enabled = true;
            btCapNhat.Enabled = false;
            btXoa.Enabled = false;
            txtMaSV.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            dtNgaySinh.Value = DateTime.Now;
            cbBLop.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            btThem.Enabled = true;
            btCapNhat.Enabled = false;
            btXoa.Enabled = false;

            txtMaSV.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            dtNgaySinh.Value = DateTime.Now;
            cbBLop.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtMaSV.Text == "")
            {
                MessageBox.Show("Chưa nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(txtHoTen.Text == "")
            {
                MessageBox.Show("Chưa nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(cbBLop.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridView1.Rows.Add(txtMaSV.Text, txtHoTen.Text, txtDiaChi.Text, dtNgaySinh.Value.ToString(), cbBLop.SelectedItem.ToString());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaSV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtHoTen.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dtNgaySinh.Value = DateTime.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            cbBLop.SelectedItem = dataGridView1.Rows[i].Cells[4].Value.ToString();
            btThem.Enabled = false;
            btCapNhat.Enabled = true;
            btXoa.Enabled = true;
        }
    }
}
