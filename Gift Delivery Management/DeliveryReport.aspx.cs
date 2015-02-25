using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gift.Business;

namespace Gift_Delivery_Management
{
    public partial class DeliveryReport : System.Web.UI.Page
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
                    c.gifttype(typelist, Session["date1"].ToString(), Session["date2"].ToString());
                    c.subid(idlist, typelist.SelectedValue);
                    c.bookingid(bookingidlist, idlist.SelectedValue, Session["date1"].ToString(), Session["date2"].ToString());
                    c.status(Statlabel, edlabel, adlabel, bookingidlist.SelectedValue);
                    c.tamt(typelist, TAlabel, Session["date1"].ToString(), Session["date2"].ToString());
                    c.amt(idlist, Amtlabel, Session["date1"].ToString(), Session["date2"].ToString());
                    c.quantity(idlist, quantlabel, Session["date1"].ToString(), Session["date2"].ToString());
                }

            }

        }

        protected void typelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //idlist.Visible = true;
            c.subid(idlist, typelist.SelectedValue);
            c.bookingid(bookingidlist, idlist.SelectedValue, Session["date1"].ToString(), Session["date2"].ToString());
            c.status(Statlabel, edlabel, adlabel, bookingidlist.SelectedValue);
            c.tamt(typelist, TAlabel, Session["date1"].ToString(), Session["date2"].ToString());
        }

        protected void idlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bookingidlist.Visible = true;
            c.bookingid(bookingidlist, idlist.SelectedValue, Session["date1"].ToString(), Session["date2"].ToString());
            c.status(Statlabel, edlabel, adlabel, bookingidlist.SelectedValue);
            c.amt(idlist, Amtlabel, Session["date1"].ToString(), Session["date2"].ToString());
            c.quantity(idlist, quantlabel, Session["date1"].ToString(), Session["date2"].ToString());

        }

        protected void bookingidlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //status.Visible = true;
            //Statlabel.Visible = true;
            //edate.Visible = true;
            //adlabel.Visible = true;
            //adate.Visible = true;
            //adlabel.Visible = true;
            c.status(Statlabel, edlabel, adlabel, bookingidlist.SelectedValue);
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