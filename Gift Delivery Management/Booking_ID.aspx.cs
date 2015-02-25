using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gift.Business;

namespace Gift_Delivery_Management
{
    public partial class Booking_ID : System.Web.UI.Page
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
                else
                {
                    book.Text = "";
                }
            }
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            book.Text = "";
        }

        protected void get_details_Click(object sender, EventArgs e)
        {
            int f = c.get_details(book);
            if (f == 2 || f == 0)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('" + "Invalid Booking ID" + "');</script>");
            }
            else if (f == 1)
            {
                Session["book_up"] = book.Text;
                Response.Redirect("update_details.aspx");
            }
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