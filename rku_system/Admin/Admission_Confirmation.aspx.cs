using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rku_system.Admin
{
    public partial class Admission_Confirmation : System.Web.UI.Page
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

        }
        public void dgv_h_display()
        {
            try
            {
                dbconn();
                String sql = "SELECT * FROM Merit_history";
                //Response.Write(sql);
                cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dgv_h.DataSource = ds;
                dgv_h.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        public void dgv_display(String c, int p)
        {
            try
            {
                dbconn();
                String sql = "SELECT * FROM Registration WHERE status = 'verified' AND category = '" + c + "' AND Hsc_per >=" + p + ";";
                //Response.Write(sql);
                cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dgv_Merit_List.DataSource = ds;
                dgv_Merit_List.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void dgv_h_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rw = dgv_h.SelectedRow;
            String c = rw.Cells[2].Text;
            int p = Convert.ToInt32(rw.Cells[3].Text);
            dgv_display(c, p);
        }
    }
}