//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Security.Cryptography;

//namespace rku_system.Faculty
//{
//    public partial class Std_verification : System.Web.UI.Page
//    {
//        SqlConnection conn;
//        SqlCommand cmd;
//        SqlDataAdapter sda;
//        public static int std_id;
//        protected void dbconn()
//        {
//            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
//            if (conn.State != ConnectionState.Open)
//            {
//                conn.Open();
//            }
//        }
//        protected void dgv_data()
//        {
//            try
//            {
//                dbconn();
//                cmd = new SqlCommand("select * from Registration;", conn);
//                sda = new SqlDataAdapter(cmd);
//                DataSet ds = new DataSet();
//                sda.Fill(ds);
//                GV_std.DataSource = ds;
//                GV_std.DataBind();
//                sda.Dispose();
//                ds.Dispose();
//                conn.Close();

//            }
//            catch (Exception ex)
//            {
//                Response.Write(ex.Message);
//            }
//        }
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            dgv_data();
//            Session["page_name"] = "Student Verification";
//        }

//        protected void select(object sender, EventArgs e)
//        {
//            GridViewRow rw = GV_std.SelectedRow;
//            std_id = Convert.ToInt32(rw.Cells[1].Text);
//            Response.Redirect("~/Faculty/Final_verification.aspx?R_id="+std_id);
//        }

//        protected void btn_sub_Click(object sender, EventArgs e)
//        {
//            String name = txt_name.Text;
//            String id = txt_id.Text;  
//            try
//            {
//                dbconn();
//                cmd = new SqlCommand("select * from Registration where R_id = '"+id+"';", conn);
//                sda = new SqlDataAdapter(cmd);
//                DataSet ds = new DataSet();
//                sda.Fill(ds);
//                GV_std.DataSource = ds;
//                GV_std.DataBind();
//                conn.Close();

//            }
//            catch (Exception ex)
//            {
//                Response.Write(ex.Message);
//            }
//        }
//    }
//}

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rku_system.Faculty
{
    public partial class Std_verification : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
        public static int std_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgv_data();
                Session["page_name"] = "Student Verification";
                Session["r_id"] = null;
            }
        }

        private void dbconn(Action<SqlConnection> action)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                action(conn);
            }
        }

        protected void dgv_data()
        {
            try
            {
                dbconn(conn =>
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Registration;", conn))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            GV_std.DataSource = ds;
                            GV_std.DataBind();
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                // Log the exception here instead of Response.Write
                // Example: Logger.Error(ex.Message, ex);
                Response.Write("An error occurred while fetching data.");
            }
        }

        protected void select(object sender, EventArgs e)
        {
            try
            {
                GridViewRow rw = GV_std.SelectedRow;
                if (rw != null)
                {
                    std_id = Convert.ToInt32(rw.Cells[1].Text);
                    Session["r_id"] = std_id;
                    Response.Redirect("~/Faculty/Final_verification.aspx?R_id=" + std_id);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Response.Write("An error occurred during selection.");
            }
        }

        protected void btn_sub_Click(object sender, EventArgs e)
        {
            string input = txt_id.Text.Trim();
            if(txt_id.Text == "" || txt_id.Text == null || txt_id.Text == " ")
            {
                dgv_data();
            }else if (int.TryParse(input, out int id))
                {
                try
                {
                    dbconn(conn =>
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Registration WHERE R_id = @R_id;", conn))
                        {
                            cmd.Parameters.AddWithValue("@R_id", id);
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataSet ds = new DataSet();
                                sda.Fill(ds);
                                GV_std.DataSource = ds;
                                GV_std.DataBind();
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    // Log the exception here
                    Response.Write("An error occurred while searching for the student.");
                }
            }
            else
            {
                try
                {
                    dbconn(conn =>
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Registration WHERE First_name = @First_name;", conn))
                        {
                            cmd.Parameters.AddWithValue("@First_name", input);
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataSet ds = new DataSet();
                                sda.Fill(ds);
                                GV_std.DataSource = ds;
                                GV_std.DataBind();
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    // Log the exception here
                    Response.Write("An error occurred while searching for the student.");
                }
            }

        }
    }
}
