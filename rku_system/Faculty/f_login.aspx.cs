using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rku_system.Faculty
{
    public partial class f_login : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        protected void dbconn()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        protected void sub_Click(object sender, EventArgs e)
        {
            try
            {

                String em = f_tb_email.Text;
                String pass = f_Password.Text;
                /*Response.Write("select * from login where user_name='" + user_name + "' AND Password = '" + pass + "';");*/
                dbconn();
                cmd = new SqlCommand("select count(*) from Faculty where F_username ='" + em + "' AND F_pass = '" + pass + "';", conn);
                //Response.Write("select count(*) from Registration where F_username ='" + em + "' AND F_pass = '" + pass + "';");
                int dr = (int)cmd.ExecuteScalar();
                if (dr > 0)
                {
                    Session["std_em"] = em;
                    Session["student"] = true;
                    conn.Close();
                    Response.Redirect("~/Faculty/Std_verification.aspx");

                }
                else
                {
                    conn.Close();
                    Response.Write("<script LANGUAGE='JavaScript' > alert('Invalid User Name & Password.')</script>");
                    //Response.Redirect(Request.RawUrl);

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}