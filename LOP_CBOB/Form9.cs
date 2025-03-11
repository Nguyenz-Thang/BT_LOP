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
    public partial class Form9 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6VHQAFG;Initial Catalog=SinhvienOK;Integrated Security=True");
        
        public Form9()
        {
            InitializeComponent();
        }
        public void loadTacGia()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT * FROM tacgia";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Dispose();  
            con.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }

        public bool checkTrungMatg(String matg)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select count(*) from tacgia where Matg = '"+matg+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar();
            if(kq > 0 ) {
                return true;
            }
            else {
                return false;
            }
            con.Close();
        }
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            //b1:: lấy dữ liệu từ các control đưa vào biến
            String maTg = txtMaTg.Text.Trim();
            String tenTg = txtHovaTen.Text.Trim();
            if (maTg == "" || tenTg == "")
            {
                MessageBox.Show("Mã tác giả và tên tác giả không được để trống!");
                return;
            }
            if (cbbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn giới tính!");
                return;
            }
            
            String gioiTinh = cbbGioiTinh.SelectedItem.ToString();
            DateTime ngaySinh = dtPNgaysinh.Value;
            String ngaySinhSql = ngaySinh.ToString("yyyy-MM-dd");
            String diaChi = txtDiaChi.Text.Trim();
            String sdt = txtSdt.Text.Trim();
            String email = txtEmail.Text.Trim();
            if (sdt.Length != 10 || !sdt.All(char.IsDigit)) 
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!");
                return;
            }

            if (!email.Contains("@")) 
            {
                MessageBox.Show("Email không hợp lệ ! Phải chứa '@'.");
                return;
            }
            //b2: kết nối sql
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (checkTrungMatg(maTg))
            {
                MessageBox.Show("Trùng mã tác giả !");
                txtMaTg.Focus();
                return;
            }
            String sql = "insert tacgia values('" + maTg + "', N'" + tenTg + "', N'" + gioiTinh + "', '" + ngaySinhSql + "', '" + sdt + "', '" + email + "', N'" + diaChi + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            //String sql = "insert tacgia values(@matg,@ht,@gt,@ngs,@dt,@email,@dc)";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("matg", maTg);
            //cmd.Parameters.AddWithValue("ht", tenTg);
            //cmd.Parameters.AddWithValue("gt", gioiTinh);
            //cmd.Parameters.AddWithValue("ngs", ngaySinhSql);
            //cmd.Parameters.AddWithValue("dt", sdt);
            //cmd.Parameters.AddWithValue("email", email);
            //cmd.Parameters.AddWithValue("dc", diaChi);

            //cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Thêm thành công");
            con.Close();
            loadTacGia();
            //b3:Tạo câu lệnh truy vấn lấy
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            loadTacGia();


        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String maTg = txtTKmaTg.Text.Trim();
            String tenTg = txtTKhoTen.Text.Trim();
            String dt = txtTKsdt.Text.Trim();
            String gt = "";
            if (cbbTKgioiTinh.SelectedIndex != -1 && cbbTKgioiTinh.SelectedIndex != 0)
            {
                gt = cbbTKgioiTinh.SelectedItem.ToString();
            }
            else
            {
                gt = "";
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "select * from tacgia where MaTg like '%"+maTg+"%' and TenTg like N'%"+tenTg+"%' and GioiTinh like N'%"+gt+"%' and DienThoai like '%"+dt+"%'";
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
            String maTg = txtMaTg.Text.Trim();
            String tenTg = txtHovaTen.Text.Trim();
            if (maTg == "" || tenTg == "")
            {
                MessageBox.Show("Mã tác giả và tên tác giả không được để trống!");
                return;
            }
            if (cbbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn giới tính!");
                return;
            }

            String gioiTinh = cbbGioiTinh.SelectedItem.ToString();
            DateTime ngaySinh = dtPNgaysinh.Value;
            String ngaySinhSql = ngaySinh.ToString("yyyy-MM-dd");
            String diaChi = txtDiaChi.Text.Trim();
            String sdt = txtSdt.Text.Trim();
            String email = txtEmail.Text.Trim();
            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!");
                return;
            }

            if (!email.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ ! Phải chứa '@'.");
                return;
            }
            //b2: kết nối sql
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String sql = "update tacgia set TenTg = N'" + tenTg + "', GioiTinh = N'" + gioiTinh + "', NgaySinh = '" + ngaySinhSql + "', DienThoai = '" + sdt + "', Email = '" + email + "', DiaChi = N'" + diaChi + "' where MaTg = '" + maTg + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Sửa thành công");
            con.Close();
            loadTacGia();
            txtMaTg.Enabled = true;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)e.RowIndex;
            txtMaTg.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtHovaTen.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbbGioiTinh.SelectedItem = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dtPNgaysinh.Value = DateTime.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            txtSdt.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String maTg = txtMaTg.Text.Trim();
                String sql = "delete from tacgia where MaTg = '" + maTg + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Xóa thành công");
                loadTacGia();
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
