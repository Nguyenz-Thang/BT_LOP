using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOP_CBOB
{
    public partial class docgia : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6VHQAFG;Initial Catalog=BT_Lop;Integrated Security=True");

        public docgia()
        {
            InitializeComponent();
        }
        public void loadDocGia()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT * FROM docgia";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Dispose();
            con.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }
        public bool checkTrungMaDocGia(String maDocGia)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from docgia where MaDocGia = '" + maDocGia + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar();
            if (kq > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maDocGia = txtMaDocGia.Text.Trim();
            String tenDocGia = txtTenDocGia.Text.Trim();
            if (maDocGia == "" || tenDocGia == "")
            {
                MessageBox.Show("Mã độc giả và tên độc giả không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String gioiTinh = cbbGioiTinh.SelectedItem.ToString();
            DateTime ngaySinh = dtPNgaysinh.Value;
            String ngaySinhSql = ngaySinh.ToString("yyyy-MM-dd");
            String diaChi = txtDiaChi.Text.Trim();
            String sdt = txtSdt.Text.Trim();
            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //b2: kết nối sql
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (checkTrungMaDocGia(maDocGia))
            {
                MessageBox.Show("Trùng mã độc giả !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDocGia.Focus();
                return;
            }
            String sql = "insert docgia values('" + maDocGia + "', N'" + tenDocGia + "', N'" + gioiTinh + "', '" + ngaySinhSql + "', '" + sdt + "', N'" + diaChi + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadDocGia();
        }

        private void docgia_Load(object sender, EventArgs e)
        {
            loadDocGia();
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String maDocGia = txtTKmaDocGia.Text.Trim();
            String tenDocGia = txtTKtenDocGia.Text.Trim();
            String dienThoai = txtTKsdt.Text.Trim();
            String gioiTinh = "";
            if (cbbTKgioiTinh.SelectedIndex != -1 && cbbTKgioiTinh.SelectedIndex != 0)
            {
                gioiTinh = cbbTKgioiTinh.SelectedItem.ToString();
            }
            else
            {
                gioiTinh = "";
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select * from docgia where MaDocGia like '%" + maDocGia + "%' and TenDocGia like N'%" + tenDocGia + "%' and GioiTinh like N'%" + gioiTinh + "%' and DienThoai like '%" + dienThoai + "%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtt = new DataTable();
            da.Fill(dtt);
            cmd.Dispose();
            con.Close();
            dataGridView1.DataSource = dtt;
            dataGridView1.Refresh();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maDocGia = txtMaDocGia.Text.Trim();
            String tenDocGia = txtTenDocGia.Text.Trim();
            if (maDocGia == "" || tenDocGia == "")
            {
                MessageBox.Show("Mã độc giả và tên độc giả không được để trống!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (cbbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String gioiTinh = cbbGioiTinh.SelectedItem.ToString();
            DateTime ngaySinh = dtPNgaysinh.Value;
            String ngaySinhSql = ngaySinh.ToString("yyyy-MM-dd");
            String diaChi = txtDiaChi.Text.Trim();
            String sdt = txtSdt.Text.Trim();

            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn sửa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //b2: kết nối sql
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            String sql = "update docgia set TenDocGia = N'" + tenDocGia + "', GioiTinh = N'" + gioiTinh + "', NgaySinh = '" + ngaySinhSql + "', DienThoai = '" + sdt + "', DiaChi = N'" + diaChi + "' where MaDocGia = '" + maDocGia + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadDocGia();
            txtMaDocGia.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)e.RowIndex;
            txtMaDocGia.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenDocGia.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbbGioiTinh.SelectedItem = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dtPNgaysinh.Value = DateTime.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            txtSdt.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String maDocGia = txtMaDocGia.Text.Trim();
                String sql = "delete from docgia where MaDocGia = '" + maDocGia + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                loadDocGia();
            }
        }
    }
}
