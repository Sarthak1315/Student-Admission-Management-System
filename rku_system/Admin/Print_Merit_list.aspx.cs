using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing.Printing;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

namespace rku_system.Admin_portal
{
    public partial class Merit_list : System.Web.UI.Page
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
            Session["page_name"] = "Print Merit List";
            dgv_h_display();

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
        public void dgv_display(String c,int p)
        {
            try
            {
                dbconn();
                String sql = "SELECT * FROM Registration WHERE status = 'Verified' AND category = '" + c + "' AND Hsc_per >=" + p + ";";
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
            dgv_display(c,p);
        }
       
        protected void Excel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition","attachment; filename=merit_list.xls");
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            Html32TextWriter writer = new Html32TextWriter(sw);
            dgv_Merit_List.RenderControl(writer);
            Response.Output.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void print_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=merit_list.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            dgv_Merit_List.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}