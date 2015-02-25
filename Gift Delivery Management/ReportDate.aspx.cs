using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gift_Delivery_Management
{
    public partial class ReportDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("Expired.aspx");
                }
            }
            RangeValidator1.MinimumValue = System.DateTime.Today.AddYears(-2).ToShortDateString();
            RangeValidator1.MaximumValue = System.DateTime.Today.AddDays(-1).ToShortDateString();
            RangeValidator2.MinimumValue = System.DateTime.Today.AddYears(-2).ToShortDateString();
            RangeValidator2.MaximumValue = System.DateTime.Today.ToShortDateString();
        }


        protected void Reset_Click(object sender, EventArgs e)
        {
            date1.Text = "";
            date2.Text = "";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Session["date1"] = date1.Text;
            Session["date2"] = date2.Text;
            Response.Redirect("ViewOptions.aspx");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Login_Page.aspx");
        }
    }
}