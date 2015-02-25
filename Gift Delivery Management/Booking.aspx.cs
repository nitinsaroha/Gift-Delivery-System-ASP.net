using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gift.Business;
using System.Data;
using System.Data.SqlClient;

namespace Gift_Delivery_Management
{
    
    public partial class Booking : System.Web.UI.Page
    {
        Class1 c = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            RangeValidator1.MinimumValue = DateTime.Today.AddDays(1).ToShortDateString();
            RangeValidator1.MaximumValue = DateTime.Today.AddYears(50).ToShortDateString();
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("Expired.aspx");
                }
                else
                {
                    c.formLoadDataB(giftTypeList, occassion);
                    c.giftTypeList_changedB(giftTypeList, occassion);
                }
            }
        }

        protected void giftTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
                c.giftTypeList_changedB(giftTypeList, occassion);
                Label5.Text = "";
                Label9.Text = "";
                Label7.Text = "";
                giftsubtypelist.Items.Clear();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            c.button1ClickB(Button4,TextBox1, TextBox2, TextBox3, giftTypeList, occassion, giftsubtypelist, Label5, Label7, Label9);
        }

        protected void giftsubtypelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader dr;
            dr = c.giftsubtypelist_changedB(giftsubtypelist);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label5.Text = dr[1].ToString();         //shows cost
                    if ((Int32)dr[0] <= 0)
                    {
                        Label7.Text = "0";
                        Label9.Text = "OUT OF STOCK";
                        TextBox1.Visible = false;
                        TextBox2.Visible = false;
                        TextBox3.Visible = false;
                        Button4.Enabled = false;
                        //Label10.Hide();
                        //Label11.Hide();
                        //Label12.Hide();
                    }
                    else
                    {
                        Label7.Text = dr[0].ToString();         //shows quantity
                        Label9.Text = "IN STOCK";
                        TextBox1.Visible = true;
                        TextBox2.Visible = true;
                        TextBox3.Visible = true;
                        Button4.Enabled = true;
                    }
                }
            }
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {

            DateTime d1 = DateTime.Today;
            string s1 = c.writeB(TextBox1,Session["username"].ToString(), TextBox2, TextBox3, giftsubtypelist, d1);
            HttpContext.Current.Response.Write("<script language='javascript'>alert('Your User ID is " + s1 + "')</script>");
            //MessageBox.Show(s1);
            reset();
            c.quantity_updateB(s1);

            //else
            //{
            //MessageBox.Show("Enter valid Data Please");
            //}
        }

        protected void occassion_SelectedIndexChanged(object sender, EventArgs e)
        {
            giftsubtypelist.Items.Clear();
            Label5.Text = "";
            Label7.Text = "";
            Label9.Text = "";
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            Button4.Enabled = false;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        public void reset()
        {
            giftTypeList.SelectedIndex = -1;
            //occassion.Items.Clear();
            giftsubtypelist.Items.Clear();
            TextBox1.Text = "";
            TextBox2.Text = "";
            Label5.Text = "";
            Label7.Text = "";
            Label9.Text = "";
            TextBox3.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Login_Page.aspx");
        }


    }
}