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
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6VHQAFG;Initial Catalog=BT_Lop;Integrated Security=True");

        public Form10()
        {
            InitializeComponent();
        }
        public void loadSinhVien()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT Sinhvien.MaSinhVien ,Sinhvien.HoTen, Sinhvien.NgaySinh, Sinhvien.GioiTinh, Sinhvien.DienThoai, Sinhvien.DiaChi, Lophoc.TenLop FROM Sinhvien JOIN Lophoc ON Sinhvien.MaLop = Lophoc.MaLop";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Dispose();
            con.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }
        public void load_lophoc()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "SELECT * FROM Lophoc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Dispose();
            con.Close();

            DataRow r = dt.NewRow();
            r["MaLop"] = "";
            r["TenLop"] = "--- Chọn lớp ---";
            dt.Rows.InsertAt(r, 0);

            cbbTenLop.DataSource = dt;
            cbbTenLop.DisplayMember = "TenLop";
            cbbTenLop.ValueMember = "MaLop";

            cbbTenLop_tk.DataSource = dt;
            cbbTenLop_tk.DisplayMember = "TenLop";
            cbbTenLop_tk.ValueMember = "MaLop";

        }
        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            
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
            cbbTenLop.SelectedItem = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtSdt.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

        }
    }
}
