using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using System.Xml.Linq;

namespace Webtestcode.Resoucre
{
    class SinhVien
    {
        public string MaSV { get; set; }
        public string HoSV { get; set; }
        public string TenSV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string MaKhoa { get; set; }
    }

    class SqlQuery
    {
        public static string MyConnection = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=SinhVienData;Integrated Security=True";

        public static DataTable SelectAll()
        {
            using (SqlConnection myConnection = new SqlConnection(MyConnection))
            {
                myConnection.Open();
                DataTable dataTable = new DataTable();
                using (SqlCommand myCommand = new SqlCommand("SELECT * FROM [SinhVienData].[dbo].[DataSV];", myConnection))
                {
                    using (SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand))
                    {
                        myDataAdapter.Fill(dataTable);
                    }
                }
                return dataTable;
            }
        }
        public static DataTable selectedToKey(string key)
        {
            using(SqlConnection myConnection = new SqlConnection(MyConnection))
            {
                myConnection.Open();
                DataTable dataTable = new DataTable();
                using(SqlCommand myCommand = new SqlCommand($"SELECT * FROM [SinhVienData].[dbo].[DataSV] WHERE [Masv]='{key}';",myConnection))
                {
                    using (SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand))
                    {
                        myDataAdapter.Fill(dataTable);
                    }
                }
                return dataTable;
            }   
        }
        public static string Get_Count()
        {
            using (SqlConnection myConnection = new SqlConnection(MyConnection))
            {
                myConnection.Open();
                string count;
                using (SqlCommand myCommand = new SqlCommand($"SELECT COUNT(*) FROM DataSV ",myConnection))
                {
                    int rowCount = (int)myCommand.ExecuteScalar();
                    count = rowCount.ToString();
                }
                return count;
            }    
        }
        public static bool ReadSql(string sql)
        {
            using (SqlConnection myConnection = new SqlConnection(MyConnection))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(sql, myConnection))
                {
                    using (SqlDataReader reader = myCommand.ExecuteReader())
                    {
                        return !reader.Read();
                    }
                }
            }
        }
    }
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
            
        }
        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            string masv = txtMasv.Text;
            string hosv = txtHosv.Text;
            string tensv = txtTensv.Text;
            string ngaysinh = txtNgaySinh.Value;
            string makhoa = txtMaKhoa.Text;
            string tenkhoa = txtTenKhoa.Text;
            if (masv.Equals("") || hosv.Equals("") || tensv.Equals("") || ngaysinh.Equals("") || makhoa.Equals("") || tenkhoa.Equals(""))
            {
                MessageNotify("Vui lòng nhập đủ dữ liệu");
                return;
            }
            string myCommand = $"INSERT INTO [SinhVienData].[dbo].[DataSV] ([Masv] ,[Hosv] ,[Tensv],[Ngaysinh],[MaKhoa],[Tenkhoa]) VALUES  ('{masv}','{hosv}','{tensv}','{ngaysinh}','{makhoa}','{tenkhoa}')";
            if (SqlQuery.ReadSql(myCommand))
            {
                MessageNotify("Bạn đã thêm người dùng thành công");
            }
            else
            {
                MessageNotify("Bạn đã thêm người dùng không thành công");
            }
            Select();
        }

        protected void buttonRemove_Click(object sender, EventArgs e)
        {
            string masv = txtMasv.Text;
            if(masv.Equals(""))
            {
                MessageNotify("Vui Lòng Nhập Mã sinh viên để thực hiện xóa");
                return;
            }
            string myCommand = $"DELETE [SinhVienData].[dbo].[DataSV] WHERE [Masv] = '{masv}';";
            if(SqlQuery.ReadSql(myCommand))
            {
                MessageNotify("Bạn đã Xóa người dùng thành công");
            }
            else
            {
                MessageNotify("Bạn đã Xóa người dùng không thành công");
            }
            Select();
        }

        protected void buttonChange_Click(object sender, EventArgs e)
        {
            string masv = txtMasv.Text;
            string hosv = txtHosv.Text;
            string tensv = txtTensv.Text;
            string ngaysinh = txtNgaySinh.Value;
            string makhoa = txtMaKhoa.Text;
            string tenkhoa = txtTenKhoa.Text;
            if (masv.Equals(""))
            {
                MessageNotify("Vui Lòng Nhập Mã sinh viên để thực hiện Lấy dữ liệu");
                return;
            }
            if (masv.Equals("") || hosv.Equals("") || tensv.Equals("") || ngaysinh.Equals("") || makhoa.Equals("") || tenkhoa.Equals(""))
            {
                MessageNotify("Vui lòng nhập đủ dữ liệu");
                return;
            }
            string cmd = $"UPDATE [QuanLySinhVien].[dbo].[SinhVien] SET [Hosv] = '{hosv}',[Tensv] = '{tensv}',[Ngaysinh] = '{ngaysinh}',[Makhoa] = '{makhoa}',[Tenkhoa] = '{tenkhoa}' WHERE [MaSV] = '{masv}';";
            if (SqlQuery.ReadSql(cmd))
            {
                MessageNotify("Bạn đã sửa người dùng thành công");
            }
            else
            {
                MessageNotify("Bạn đã sửa người dùng không thành công");
            }
            Select();
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            txtHosv.Text = "";
            txtTensv.Text = "";
            txtMasv.Text = "";
            txtMaKhoa.Text = "";
            txtNgaySinh.Value = DateTime.Now.ToString();
            txtTenKhoa.Text = "";
        }

        protected void buttonExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void buttonTakeData_Click(object sender, EventArgs e)
        {
            string masv = txtMasv.Text;
            if (masv.Equals(""))
            {
                MessageNotify("Vui Lòng Nhập Mã sinh viên để thực hiện Lấy dữ liệu");
                return;
            }
            string myCommand = $"SELECT * FROM [SinhVienData].[dbo].[DataSV] WHERE [Masv]='{masv}';";
            if (!SqlQuery.ReadSql(myCommand))
            {
                MessageNotify("Bạn đã Lấy người dùng thành công");
                DataTable dt = SqlQuery.selectedToKey(masv);
                GridViewDataSV.DataSource = dt;
                GridViewDataSV.DataBind();
            }
            else
            {
                MessageNotify("Bạn đã Lấy người dùng không thành công");
            }
        }
        private void Select()
        {
            DataTable sv = SqlQuery.SelectAll();
            GridViewDataSV.DataSource = sv;
            GridViewDataSV.DataBind();
            Number.Text = SqlQuery.Get_Count();
        }
        private void MessageNotify(string message)
        {
            string script = $"<script type='text/javascript'>alert('{message}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
        }

        protected void GridViewDataSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}