using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace rku_system.Admin_portal
{
    public partial class create_merit_list : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        String c_ddl;
        int p;
        List<int> m_list = new List<int>();
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
            //if (!Page.IsPostBack)
            //{
            //    ddl_bind();
            //}
            Session["page_name"] = "Create Merit List";
        }
        
        public void dgv_display()
        {
            try
            {
                dbconn();
                String sql = "SELECT * FROM Registration WHERE status = 'Verified' AND category = '"+c_ddl+ "' AND Hsc_per >="+p+";";
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

        protected void btn_display(object sender, EventArgs e)
        {
            c_ddl = category_ddl.SelectedValue;
            p = Convert.ToInt32(pr.Text);
            dgv_display();
        }

        protected void btn_create(object sender, EventArgs e)
        {
            //foreach (GridViewRow row in dgv_Merit_List.Rows)
            //{
            //    if (row.Cells.Count > 0 && !string.IsNullOrEmpty(row.Cells[0].Text))
            //    {
            //        int id = Convert.ToInt32(row.Cells[0].Text);
            //        m_list.Add(id);
            //        //Response.Write(id);
            //    }
            //}

            //foreach (Object obj in m_list)
            //{
            //    Response.Write("   " + obj.ToString());
            //    Response.Write("<br>");
            //}

            try
            {
                dbconn();
                String inst = "INSERT INTO Merit_history(category,pr) Values('" + category_ddl.SelectedValue + "'," + Convert.ToInt32(pr.Text) + ");";
                //Response.Write(inst);
                cmd = new SqlCommand(inst, conn);
                int isint = cmd.ExecuteNonQuery();
                if (isint > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('Merit List Generated Go to Print Marit List Page to Print'); ", true);
                    //Response.Write("<script>success_msg('Inserted')</script>");
                    //Response.Write("<script LANGUAGE='JavaScript' >alert('Inserted Successfully.')</script>");


                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('Merit List Not Generated'); ", true);
                    //Response.Write("<script LANGUAGE='JavaScript' >alert('Insert Failed.')</script>");
                }
                

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
    }
}