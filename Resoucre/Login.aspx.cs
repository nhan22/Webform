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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSingin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT * FROM MyData WHERE username=@username AND password=@password", sqlConnection);
            myCommand.Parameters.AddWithValue("@username", txtUsername.Text);
            myCommand.Parameters.AddWithValue("@password", txtPassword.Text);
            SqlDataReader myDataReader = myCommand.ExecuteReader();
            if (myDataReader.Read())
            {
                if (cbNhoToi.Checked)
                {
                    HttpCookie userCookie = new HttpCookie("UserCookie");
                    userCookie.Values.Add("UserName", txtUsername.Text);
                    userCookie.Values.Add("Password", txtPassword.Text);
                    userCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(userCookie);
                }
                else
                {
                    HttpCookie userCookie = new HttpCookie("UserCookie");
                    userCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(userCookie);
                }
                Response.Write("<script> alert('Xin Chao : " + txtUsername.Text + "'); </script>");
                Server.Transfer("Homepage.aspx");
            }
            else
            {
                Response.Write("<script> alert('Tai khoan mat khau khong chinh xac'); </script>");
            }
            sqlConnection.Close();
        }
    }
}