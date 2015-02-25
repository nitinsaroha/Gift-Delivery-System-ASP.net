using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Gift.Business;

namespace Gift_Delivery_Management
{
    public partial class Registration : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            valdob.MaximumValue = DateTime.Today.AddDays(-1).ToShortDateString();
            valdob.MinimumValue = DateTime.Today.AddYears(-100).ToShortDateString();
        }

        protected void reqvalgender_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.ToString().Equals("Select Gender") == true)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void btnhome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_Page.aspx");
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            txtaddress.Text = "";
            txtcontact.Text = "";
            txtdob.Text = "";
            txtemail.Text = "";
            txtname.Text = "";
            txtpassword.Text = "";
            txtretype.Text = "";
            ddlgender.SelectedValue = "Select Gender";
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            c.write(txtname, txtcontact, txtpassword, txtemail, ddlgender, txtdob, txtaddress);
            txtaddress.Text = "";
            txtcontact.Text = "";
            txtdob.Text = "";
            txtemail.Text = "";
            txtname.Text = "";
            txtpassword.Text = "";
            txtretype.Text = "";
            ddlgender.SelectedValue = "Select Gender";
           
        }

        protected void exvalemail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (c.email(args.Value.ToString()) == false)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_Page.aspx");
        }
    }
}