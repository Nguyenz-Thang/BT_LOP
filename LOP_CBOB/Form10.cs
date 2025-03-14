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
    public partial class Form10 : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6VHQAFG;Initial Catalog=BT_Lop;Integrated Security=True");
        SqlConnection con = Thuvien.con;
        public Form10()
        {
            InitializeComponent();
        }
        public void loadSinhVien()
        {
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            string sql = "SELECT Sinhvien.MaSinhVien ,Sinhvien.HoTen, Sinhvien.NgaySinh, Sinhvien.GioiTinh, Sinhvien.DienThoai, Sinhvien.DiaChi, Lophoc.TenLop, Lophoc.MaLop FROM Sinhvien JOIN Lophoc ON Sinhvien.MaLop = Lophoc.MaLop";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //cmd.Dispose();
            //con.Close();
            //dataGridView1.DataSource = dt;
            //dataGridView1.Refresh();

            Thuvien.Hienthi(dataGridView1, sql);

        }
        public void load_lophoc()
        {
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            string sql = "SELECT * FROM Lophoc";
            Thuvien.ComboboxHT(cbbTenLop, sql, "TenLop", "MaLop");
            Thuvien.ComboboxHT(cbbTenLop_tk, sql, "TenLop", "MaLop");

            //SqlCommand cmd = new SqlCommand(sql, con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //cmd.Dispose();
            //con.Close();

            //DataRow r = dt.NewRow();
            //r["MaLop"] = "";
            //r["TenLop"] = "--- Chọn lớp ---";
            //dt.Rows.InsertAt(r, 0);

            //cbbTenLop.DataSource = dt;
            //cbbTenLop.DisplayMember = "TenLop";
            //cbbTenLop.ValueMember = "MaLop";

            //cbbTenLop_tk.DataSource = dt;
            //cbbTenLop_tk.DisplayMember = "TenLop";
            //cbbTenLop_tk.ValueMember = "MaLop";

        }
        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String maSv = txtMaSinhVien_tk.Text.Trim();
            String tenSv = txtTenSv_tk.Text.Trim();
            String dienThoai = txtSdt_tk.Text.Trim();
            String gioiTinh = "";
            if (cbbTKgioiTinh.SelectedIndex != -1 && cbbTKgioiTinh.SelectedIndex != 0)
            {
                gioiTinh = cbbTKgioiTinh.SelectedItem.ToString();
            }
            else
            {
                gioiTinh = "";
            }
            String tenLop = cbbTenLop_tk.Text;
            if(tenLop == "--- Chọn ---")
            {
                tenLop = "";
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select Sinhvien.MaSinhVien ,Sinhvien.HoTen, Sinhvien.NgaySinh, Sinhvien.GioiTinh, Sinhvien.DienThoai, Sinhvien.DiaChi, Lophoc.TenLop,Lophoc.MaLop from Sinhvien JOIN Lophoc ON Sinhvien.MaLop = Lophoc.MaLop where MaSinhVien like '%" + maSv + "%' and HoTen like N'%" + tenSv + "%' and GioiTinh like N'%" + gioiTinh + "%' and DienThoai like '%" + dienThoai + "%' and TenLop like '%" + tenLop + "%'";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dtt = new DataTable();
            //da.Fill(dtt);
            //cmd.Dispose();
            //con.Close();
            //dataGridView1.DataSource = dtt;
            //dataGridView1.Refresh();
            Thuvien.Hienthi(dataGridView1, sql);
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            loadSinhVien();
            load_lophoc();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)e.RowIndex;
            txtMaSinhVien.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenSinhVien.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dtPNgaysinh.Value = DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            cbbGioiTinh.SelectedItem = dataGridView1.Rows[i].Cells[3].Value.ToString();
            string tenLop = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
            int index = cbbTenLop.FindStringExact(tenLop);
            cbbTenLop.SelectedIndex = index;
            txtSdt.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

        }
        public bool checkTrungMaSinhVien(String maSv)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from Sinhvien where MaSinhVien = '" + maSv + "'";
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
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maSinhVien = txtMaSinhVien.Text.Trim();
            String tenSv = txtTenSinhVien.Text.Trim();
            if (maSinhVien == "" || tenSv == "")
            {
                MessageBox.Show("Mã sinh viên và tên sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String gioiTinh = cbbGioiTinh.SelectedItem.ToString();
            String maLop = cbbTenLop.SelectedValue.ToString();
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
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            if (checkTrungMaSinhVien(maSinhVien))
            {
                MessageBox.Show("Trùng mã sinh viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSinhVien.Focus();
                return;
            }
            if(cbbTenLop.Text == "--- Chọn ---")
            {
                MessageBox.Show("Chưa chọn lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String sql = "insert Sinhvien values('" + maSinhVien + "', N'" + tenSv + "',  '" + ngaySinhSql + "', N'" + gioiTinh + "','" + maLop + "','" + sdt + "', N'" + diaChi + "')";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.ExecuteNonQuery();
            //cmd.Dispose();
            //con.Close();
            Thuvien.insert(sql);
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            loadSinhVien();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maSinhVien = txtMaSinhVien.Text.Trim();
            String tenSv = txtTenSinhVien.Text.Trim();
            if (maSinhVien == "" || tenSv == "")
            {
                MessageBox.Show("Mã sinh viên và tên sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String gioiTinh = cbbGioiTinh.SelectedItem.ToString();
            String maLop = cbbTenLop.SelectedValue.ToString();
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
            String sql = "update Sinhvien set HoTen = N'" + tenSv + "', NgaySinh = '" + ngaySinhSql + "', GioiTinh = N'" + gioiTinh + "', MaLop = '" + maLop + "', DienThoai = '" + sdt + "', DiaChi = N'" + diaChi + "' where MaSinhVien = '" + maSinhVien + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
            con.Close();
            loadSinhVien();
            txtMaSinhVien.Enabled = true;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String maSv = txtMaSinhVien.Text.Trim();
                String sql = "delete from Sinhvien where MaSinhVien = '" + maSv + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                loadSinhVien();
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
