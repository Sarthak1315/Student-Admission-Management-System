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
    public partial class student_confirmation2 : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        public static string R_Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page_name"] = "Final Verification";

            if (Session["r_id_sc"] != null)
            {
                R_Id = Session["r_id_sc"].ToString();

            }
            else
            {
                Response.Redirect("~/Admin/student_confirmation.aspx");

            }

            //R_Id = Request.QueryString["R_id"];
            fn_data();
        }
        protected void dbconn()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        protected void fn_data()
        {
            try
            {
                dbconn();
                string sql = "SELECT R_date,Email,First_name,Middle_name,Last_name,birth_date,category,Gender,mobile_number,Ssc_per,Hsc_per,stream,Address,Status,Ssc_res_file,Hsc_res_file,profile_img,sign FROM Registration WHERE R_id = " + R_Id;
                //Response.Write(sql);
                cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    //for (int i = 0; i < 13; i++)
                    //{
                    //    Response.Write(rdr[i].ToString());
                    //}


                    txt_adate.Text = rdr[0].ToString();
                    txt_email.Text = rdr[1].ToString();
                    txt_fname.Text = rdr[2].ToString();
                    txt_mname.Text = rdr[3].ToString();
                    txt_lname.Text = rdr[4].ToString();
                    txt_bdate.Text = rdr[5].ToString();
                    txt_category.Text = rdr[6].ToString();
                    txt_gen.Text = rdr[7].ToString();
                    txt_mobile.Text = rdr[8].ToString();
                    txt_sscper.Text = rdr[9].ToString();
                    txt_hscper.Text = rdr[10].ToString();
                    txt_stream.Text = rdr[11].ToString();
                    txt_add.Text = rdr[12].ToString();
                    txt_status.Text = rdr[13].ToString();
                    ssc_file.ImageUrl = rdr[14].ToString();
                    ssc_hl.NavigateUrl = rdr[14].ToString();
                    hsc_file.ImageUrl = rdr[15].ToString();
                    hsc_hl.NavigateUrl = rdr[15].ToString();
                    profile_file.ImageUrl = rdr[16].ToString();
                    pi_hl.NavigateUrl = rdr[16].ToString();
                    sign_file.ImageUrl = rdr[17].ToString();
                    sign_hl.NavigateUrl = rdr[17].ToString();

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btn_conform_Click(object sender, EventArgs e)
        {

            try
            {
                dbconn();
                String sql = "UPDATE Registration SET status='Confirm' WHERE R_id='" + R_Id + "'";
                //Response.Write(sql);
                cmd = new SqlCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Session["r_id_sc"] = null;
                    fn_data();
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('Student Confirm');", true);
                }
                //else
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Customer not found.');", true);
                //}


            }
            catch (Exception ex)
            {

            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Session["r_id_sc"] = null;
            Response.Redirect("~/Admin/student_confirmation.aspx");
        }
    }
}