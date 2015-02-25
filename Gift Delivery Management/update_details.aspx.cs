using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gift.Business;

namespace Gift_Delivery_Management
{
    public partial class update_details : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["username"] == null)
                {
                    Response.Redirect("Expired.aspx");
                }
            }
            Label7.Text = Session["book_up"].ToString();
            c.user_details(Label6, Label5, Label10, Label7);
            RangeValidator1.MinimumValue = Convert.ToDateTime(Label10.Text).ToShortDateString();
            RangeValidator1.MaximumValue = DateTime.Today.AddYears(100).ToShortDateString();
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            c.update_details(DropDownList1, TextBox1, Label7);
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Login_Page.aspx");
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            DropDownList1.SelectedValue = "Pending";
        }
    }
}