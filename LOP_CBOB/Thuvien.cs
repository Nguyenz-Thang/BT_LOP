using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOP_CBOB
{
    internal class Thuvien
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6VHQAFG;Initial Catalog=BT_Lop;Integrated Security=True");
        public static void insert(string sql)
        {
            // ket noi db
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            // tao doi tuong command de thuc hien cau lenh chen
            //String s="insert "+tenbang+ " values(" + sql + ")";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public static void Hienthi(DataGridView dgv, String sql) {
            // ket noi db
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Refresh();
            con.Close();

        }
        public static void ComboboxHT(ComboBox cbo, String sql,string cotHT, string cotLayGT)
        {
            // ket noi db
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow r = dt.NewRow();
            r[cotLayGT] = "";
            r[cotHT] = "--- Chọn ---";
            dt.Rows.InsertAt(r, 0);
            cbo.DataSource = dt;
            cbo.DisplayMember = cotHT;
            cbo.ValueMember = cotLayGT;
            con.Close();

        }
    }
}
