using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Gift.Business;

namespace Gift_Delivery_Management
{
    public partial class Login_Page : System.Web.UI.Page
    {
        Class1 c = new Class1();

        string log = @"D:\log.txt";

        protected void Page_Load(object sender, EventArgs e)
        {
            username.Focus();
        }

        protected void logon_Click(object sender, EventArgs e)
        {
            int f = 0;
            f = c.login(username, password);
            if (f == 1)
            {
                Session["username"] = username.Text;
                Response.Redirect("Admin.aspx");
            }
            else if (f == 2)
            {
                Session["username"] = username.Text;
                Response.Redirect("Booking.aspx");
            }
            else
            {
                username.Text = "";
                password.Text = "";

                HttpContext.Current.Response.Write("<script language='javascript'>alert('" + "Invalid Username/Password" + "');</script>");

                using (StreamWriter w = File.AppendText(log))
                {
                    c.Log("Error " + "Invalid Username/Password", w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    c.DumpLog(r);
                }

            }
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            username.Text = "";
            password.Text = "";
        }

        protected void new_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

    }
}