using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gift_Delivery_Management
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                    Response.Redirect("Expired.aspx");
            }
        }

        protected void gift_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add Gift.aspx");
        }

        protected void update_Click(object sender, EventArgs e)
        {
            Response.Redirect("Booking_ID.aspx");
        }

        protected void generate_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportDate.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Login_page.aspx");
        }
    }
}