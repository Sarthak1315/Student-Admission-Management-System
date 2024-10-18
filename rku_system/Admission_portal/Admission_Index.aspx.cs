using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Reflection.Emit;

namespace rku_system.Admission_portal
{
    public partial class Admission_Index : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        Boolean Already_Registered = false;
        public static Boolean ath = false;
        Sender s = new Sender();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                div1.Visible = true;
                div2.Visible = false;
                SetFieldVisibility();
                
            }
            else
            {
               
                // Retrieve 'nr' from ViewState if the page is a postback
                Already_Registered = Session["Already_Registered"] != null ? (bool)Session["Already_Registered"] : false;
            }

        }


        private void SetFieldVisibility()
        {
         
            lb_eml.Visible = true;
            txt_eml.Visible = true;
            btn_v.Visible = true;
            lbl_message.Visible = true;
            lbl_otp.Visible = false;
            txt_otp.Visible = false;
            btn_otp.Visible = false;
        }

        protected void rb_res_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFieldVisibility();
        }

        private void dbconn()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        private Boolean IsEmailRegistered(string email)
        {
            dbconn();
            try
            {
                string query = "SELECT COUNT(*) FROM Registration WHERE Email = @Email";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    return true;
                }
                else { 
                    return false;

                }

            }
            finally
            {
                conn.Close();
            }
        }

        protected void fn_verify(object sender, EventArgs e)
        {
            dbconn();
            string email = txt_eml.Text.Trim();
            Already_Registered = IsEmailRegistered(email);
            Session["Already_Registered"] = Already_Registered;
            if (string.IsNullOrEmpty(email))
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('Please enter an email address'); ", true);
                //lbl_message.Text = "Please enter an email address.";
                return;
            }
            else
            {
                lbl_otp.Visible = true;
                txt_otp.Visible = true;
                btn_otp.Visible = true;
                s.sendotp(txt_eml.Text);
            }
                //ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('Already Registered Add New Email'); ", true);
                    //Already_Registered = true;
                    
 
            }
           

        protected void btn_otp_Click(object sender, EventArgs e)
        {
            if (txt_otp.Text.Equals(s.get_otp()))
            {
                string em = txt_eml.Text;
                ath = true;
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('OTP verified'); ", true);
                Session["std_em"] = em;

                if (Already_Registered)
                {
                    Response.Redirect("~/Admission_portal/registration_form.aspx"); 
                }
                else
                {
                    div2.Visible = true;
                    div1.Visible = false;
                    fnStreamBind();
                    
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('OTP is incorrect'); ", true);
            }
        }
        protected void fnDepartmentBind()
        {
            try
            {
                dbconn();
                String sql = "SELECT d_id,d_name FROM Department WHERE Stream='" + ddl_stream.SelectedValue + "'";
                cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ddl_dept.DataSource = ds;
                ddl_dept.DataTextField = "d_name";
                ddl_dept.DataValueField = "d_id";
                ddl_dept.DataBind();
                ddl_dept.Items.Insert(0, "-- Select Department --");
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void fnStreamBind()
        {
            try
            {
                dbconn();
                String sql = "SELECT Stream FROM Department GROUP BY Stream";
                cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ddl_stream.DataSource = ds;
                ddl_stream.DataValueField = "Stream";
                ddl_stream.DataBind();
                ddl_stream.Items.Insert(0, "-- Select Stream --");
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                dbconn();
                string path = "~/Uploades/" + Session["std_em"].ToString();
                System.IO.Directory.CreateDirectory(MapPath(path));
                String ssc_path = path + "/" + ssc_file.FileName;
                String hsc_path = path + "/" + hsc_file.FileName;
                String profile_path = path + "/" + profile_file.FileName;
                String sign_path = path +"/"+ sign_file.FileName;

                //ssc
                if (ssc_file.HasFile)
                {

                    ssc_file.SaveAs(Server.MapPath(ssc_path));
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('File Uploaded'); ", true);

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('No File Uploaded'); ", true);
                    
                } 
                //hsc
                if (hsc_file.HasFile)
                {

                    hsc_file.SaveAs(Server.MapPath(hsc_path));
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('File Uploaded'); ", true);

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('No File Uploaded'); ", true);
                    
                } 
                //profile
                if (profile_file.HasFile)
                {

                    profile_file.SaveAs(Server.MapPath(profile_path));
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('File Uploaded'); ", true);

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('No File Uploaded'); ", true);
                    
                } 
                //sign 
                if (sign_file.HasFile)
                {

                    sign_file.SaveAs(Server.MapPath(sign_path));
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('File Uploaded'); ", true);

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('No File Uploaded'); ", true);
                    
                }
                String inst = "INSERT INTO Registration(R_date,stream,d_id,First_name,Middle_name,Last_name,birth_date,Category,Gender,mobile_number,Email,Ssc_per,Hsc_per,Address,Ssc_res_file,Hsc_res_file,profile_img,sign) Values(GETDATE(),'" + ddl_stream.SelectedValue + "'," + ddl_dept.SelectedValue + ",'" + txt_fname.Text + "','" + txt_mname.Text + "','" + txt_lname.Text + "','" + txt_birth.Text + "','" + ddl_category.SelectedValue + "','" + rdl_gender.SelectedValue + "'," + txt_mobile.Text + ",'" + Session["std_em"] + "'," + txt_ssc.Text + "," + txt_hsc.Text + ",'" + txt_add.Text + "','"+ssc_path+"','"+hsc_path+"','"+profile_path+"','"+sign_path+ "');";
                Response.Write(inst);
                cmd = new SqlCommand(inst, conn);
                int isint = cmd.ExecuteNonQuery();

                if (isint > 0)
                {
                    
                    Response.Redirect("~/Admission_portal/registration_form.aspx");
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('Inserted'); ", true);

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('Insert'); ", true);
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void ddl_stream_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnDepartmentBind();
        }

    }
}

//        protected void fn_res(object sender, EventArgs e)
//        protected void fnDepartmentBind()


//        }
//        //private void SetFieldVisibility()
//        //{
//        //    string selectedValue = rb_res.SelectedValue;

//        //    if (selectedValue == "New Registration")
//        //    {
//        //        nr = true;
//        //        lb_eml.Visible = true;
//        //        txt_eml.Visible = true;
//        //        btn_v.Visible = true;
//        //        lbl_message.Visible = true;
//        //    }
//        //    else
//        //    {
//        //        nr = false;
//        //        lb_eml.Visible = true;
//        //        txt_eml.Visible = true;
//        //        btn_v.Visible = true;
//        //        lbl_message.Visible = true;
//        //    }
//        //}
//        private void SetFieldVisibility()
//        {
//            string selectedValue = rb_res.SelectedValue;

//            if (selectedValue == "New Registration")
//            {
//                this.nr = true;
//            }
//            else
//            {
//                nr = false;
//            }

//            lb_eml.Visible = true;
//            txt_eml.Visible = true;
//            btn_v.Visible = true;
//            lbl_message.Visible = true;
//        }
//        private bool IsEmailRegistered(string email)
//        {
//            dbconn();
//            try
//            {
//                string query = "SELECT COUNT(*) FROM Registration WHERE Email = @Email";
//                cmd = new SqlCommand(query, conn);
//                cmd.Parameters.AddWithValue("@Email", email);
//                int count = (int)cmd.ExecuteScalar();
//                return count > 0;
//            }
//            finally
//            {
//                conn.Close();
//            }
//        }
//        protected void fn_verify(object sender, EventArgs e)
//        {
//            if (nr)
//            {
//                dbconn();
//                string email = txt_eml.Text.Trim();
//                if (string.IsNullOrEmpty(email))
//                {
//                    lbl_message.Text = "Please enter an email address.";
//                    return;
//                }

//                string query = "SELECT COUNT(*) FROM Registration WHERE Email ='" + txt_eml.Text + "'";
//                cmd = new SqlCommand(query, conn);
//                int count = (int)cmd.ExecuteScalar();
//                if (count > 0)
//                {
//                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('Already Registered Add New Email'); ", true);
//                    txt_eml.Text = "";
//                }
//                else
//                {

//                    lbl_otp.Visible = true;
//                    txt_otp.Visible = true;
//                    btn_otp.Visible = true;
//                    s.sendotp(txt_eml.Text);
//                    //ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('Success'); ", true);
//                }
//            }
//            else
//            {
//                dbconn();
//                string query = "SELECT COUNT(*) FROM Registration WHERE Email ='" + txt_eml.Text + "'";
//                cmd = new SqlCommand(query, conn);
//                //cmd.Parameters.AddWithValue("@Email", email);
//                int count = (int)cmd.ExecuteScalar();
//                if (count > 0)
//                {
//                    lbl_otp.Visible = true;
//                    txt_otp.Visible = true;
//                    btn_otp.Visible = true;
//                    s.sendotp(txt_eml.Text);

//                    //Response.Redirect("~/Admission_portal/res_form.aspx");
//                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('Email Registered'); ", true);
//                    //ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('Already Registered'); ", true);

//                }
//                else
//                {
//                    //lbl_otp.Visible = true;
//                    //txt_otp.Visible = true;
//                    //btn_otp.Visible = true;
//                    //s.sendotp(txt_eml.Text);
//                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('Email is not Register'); ", true);
//                }
//            }
//        }

//        protected void rb_res_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            SetFieldVisibility();
//        }
//        protected void btn_otp_Click(object sender, EventArgs e)
//        {
//            if (nr == false)
//            {
//                if (txt_otp.Text.Equals(s.get_otp()))
//                {
//                    String em = txt_eml.Text;
//                    ath = true;
//                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('otp verify'); ", true);
//                    Session["std_em"] = em;
//                    Response.Redirect("~/Admission_portal/res_form.aspx");
//                }
//                else
//                {
//                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('otp is incorrect'); ", true);
//                }
//            }
//            else
//            {
//                if (txt_otp.Text.Equals(s.get_otp()))
//                {
//                    String em = txt_eml.Text;
//                    ath = true;
//                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('otp verify'); ", true);
//                    Session["std_em"] = em;
//                    Response.Redirect("~/Admission_portal/res_detail.aspx");
//                }
//                else
//                {
//                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('otp is incorrect'); ", true);

//                }
//            }

//        }
//        //protected void fn_verify(object sender, EventArgs e)
//        //{
//        //    string email = txt_eml.Text.Trim();
//        //    if (string.IsNullOrEmpty(email))
//        //    {
//        //        lbl_message.Text = "Please enter an email address.";
//        //        return;
//        //    }

//        //    if (IsEmailRegistered(email))
//        //    {
//        //        lbl_otp.Visible = true;
//        //        txt_otp.Visible = true;
//        //        btn_otp.Visible = true;
//        //        s.sendotp(email);

//        //        if (nr)
//        //        {
//        //            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('Already Registered Add New Email'); ", true);
//        //            txt_eml.Text = "";
//        //        }
//        //    }
//        //    else
//        //    {
//        //        if (nr)
//        //        {
//        //            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('Email is not Registered'); ", true);
//        //        }
//        //        else
//        //        {
//        //            lbl_otp.Visible = true;
//        //            txt_otp.Visible = true;
//        //            btn_otp.Visible = true;
//        //            s.sendotp(email);
//        //        }
//        //    }
//        //}


//        //    }
//        //    //private bool CheckEmailInDatabase(string email)
//        //    //{
//        //    //dbconn();
//        //    //string query = "SELECT COUNT(*) FROM Registration WHERE Email = @Email";

//        //    //            cmd.Parameters.AddWithValue("@Email", email);
//        //    //            int count = (int)cmd.ExecuteScalar();
//        //    //            return count > 0;
//        //    //}
//        //}
//    }
//}