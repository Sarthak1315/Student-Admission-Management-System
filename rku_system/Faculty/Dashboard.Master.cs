using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rku_system.Faculty
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["student"])
            {

                String page_name = Session["page_name"].ToString();
                pn1.Text = pn2.Text = page_name;

                switch (page_name)
                {
                    case "Student Verification":
                        f_d.Attributes["class"] = fv.Attributes["class"] = "nav-link text-white";
                        std_v.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                    case "Final Verification":
                        f_d.Attributes["class"] = std_v.Attributes["class"] = "nav-link text-white";
                        fv.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                    default:
                        std_v.Attributes["class"]  = fv.Attributes["class"] = "nav-link text-white";
                        f_d.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                }


            }
            else
            {
                Response.Redirect("~/Faculty/f_login.aspx");
            }
        }
    }
}