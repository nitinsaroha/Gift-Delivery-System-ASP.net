using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using Gift.Business;
using PdfSharp.Pdf;
using PdfSharp;

namespace Gift_Delivery_Management
{
    public partial class ViewOptions : System.Web.UI.Page
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
        }

        protected void Generatereport_Click(object sender, EventArgs e)
        {

            Response.Redirect("DeliveryReport.aspx");
        }

        protected void PdfButton_Click(object sender, EventArgs e)
        {

            PdfDocument pdf = c.report(Session["date1"].ToString(), Session["date2"].ToString());
            MemoryStream stream = new MemoryStream();
            pdf.Save(stream, false);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", stream.Length.ToString());
            Response.BinaryWrite(stream.ToArray());
            Response.Flush();
            stream.Close();
            Response.End();
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
    }
}