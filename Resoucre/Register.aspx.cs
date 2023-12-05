using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Webtestcode.Resoucre
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Xử lý đăng ký ở đây
            string userName = txtUsername.Text;
            var userPassword = txtPassword.Text;
            var userRePassword = txtConfirmPassword.Text;
            SqlConnection sqlConnection = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand myCommand = new SqlCommand($"INSERT INTO [MyDB].[dbo].[MyData] ([username],[password]) VALUES ('{userName}' ,'{userPassword}')", sqlConnection);
            if (userName != "" && userPassword != null && userRePassword != null)
            {
                if (userPassword.Equals(userRePassword))
                {
                    Session["SaveUser"] = userName;
                    Session["Password"] = userPassword;
                    myCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                    myCommand.Parameters.AddWithValue("@password", txtPassword.Text);
                    SqlDataReader myDataReader = myCommand.ExecuteReader();
                    Server.Transfer("Login.aspx");
                }
                else
                {
                    Response.Write("<script> alert('Đăng kí không thành công'); </script>");
                }
            }
            else
            {
                Response.Write("<script> alert('Vui Lòng Nhập đủ thông tin !'); </script>");
            }
            sqlConnection.Close();
        }
    }
}