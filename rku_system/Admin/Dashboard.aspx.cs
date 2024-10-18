using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rku_system.Admin_portal
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;

        protected void dbconn()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page_name"] = "Dashboard";
            l1();
            l2();
            l3();
            l4();

        }

        protected void l1()
        {
            try
            {
                dbconn();
                String sql = "SELECT COUNT(Admin_id) FROM Admin_User";
                //Response.Write(sql);
                cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Label1.Text = rdr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void l2()
        {
            try
            {
                dbconn();
                String sql = "SELECT COUNT(R_id) FROM Registration";
                //Response.Write(sql);
                cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Label2.Text = rdr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void l3()
        {
            try
            {
                dbconn();
                String sql = "SELECT COUNT(F_id) FROM Faculty";
                //Response.Write(sql);
                cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Label3.Text = rdr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void l4()
        {
            try
            {
                dbconn();
                String sql = "SELECT COUNT(R_id) FROM Student";
                //Response.Write(sql);
                cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Label4.Text = rdr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }
}