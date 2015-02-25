using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gift.Business;


namespace Gift_Delivery_Management
{
    public partial class Add_Gift : System.Web.UI.Page
    {
        Gift.Business.Class1 c = new Gift.Business.Class1();
        int f1 = 0, f2 = 0, f3 = 0, f4 = 0, f5 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                    Response.Redirect("Expired.aspx");
                else
                {
                    GiftType_DropDownList1.Items.Clear();
                    c.fillgift(GiftType_DropDownList1);
                    OccasionType_DropDownList2.Items.Clear();
                    c.filloccassion(OccasionType_DropDownList2);
                    Gift_Label.Visible = false;
                    Occasion_Label.Visible = false;
                }
            }

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cost_TextBox.Text = "";
            Quantity_TextBox.Text = "";

            if (GiftType_DropDownList1.Text.Equals("Others", StringComparison.OrdinalIgnoreCase) == true)
            {
                GiftType_TextBox.Visible = true;
                Cost_TextBox.Enabled = true;
                Quantity_TextBox.Enabled = true;
                Cost.Enabled = true;
                Quantity.Enabled = true;
                Add_Button.Enabled = true;
                Reset_Button.Enabled = true;

            }
            else
            {
                GiftType_TextBox.Visible = false;
                Cost_TextBox.Enabled = true;
                Quantity_TextBox.Enabled = true;
                Cost.Enabled = true;
                Quantity.Enabled = true;
                Add_Button.Enabled = true;
                Reset_Button.Enabled = true;
            }

        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cost_TextBox.Text = "";
            Quantity_TextBox.Text = "";

            if (OccasionType_DropDownList2.Text.Equals("Others", StringComparison.OrdinalIgnoreCase) == true)
            {
                Occasion_TextBox.Visible = true;
                Cost_TextBox.Enabled = true;
                Quantity_TextBox.Enabled = true;
                Cost.Enabled = true;
                Quantity.Enabled = true;
                Add_Button.Enabled = true;
                Reset_Button.Enabled = true;

            }
            else
            {
                Occasion_TextBox.Visible = false;
                Cost_TextBox.Enabled = true;
                Quantity_TextBox.Enabled = true;
                Cost.Enabled = true;
                Quantity.Enabled = true;
                Add_Button.Enabled = true;
                Reset_Button.Enabled = true;
            }


        }
        protected void GiftType_TextBox_TextChanged(object sender, EventArgs e)
        {
            f2 = 0;
            if (GiftType_DropDownList1.Text.Equals("Others", StringComparison.OrdinalIgnoreCase) == true)
            {
                f2 = c.gifttype(GiftType_TextBox);
                if (f2 == 1)
                {
                    Gift_Label.Text = "*Already Exists";
                    Gift_Label.Enabled = true;
                    Gift_Label.Visible = true;
                    GiftType_TextBox.Text = " ";
                    GiftType_TextBox.Focus();
                }
                else if (f2 != 1)
                {
                    f2 = 0;
                    Gift_Label.Visible = false;
                    Gift_Label.Enabled = false;
                }
                else
                {
                    Gift_Label.Visible = false;

                }

            }

        }

        protected void Occasion_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (OccasionType_DropDownList2.Text.Equals("others", StringComparison.OrdinalIgnoreCase))
            {
                f4 = c.occasion(Occasion_TextBox);
                if (f4 == 1)
                {
                    Occasion_Label.Text = "*Already Exists";
                    Occasion_Label.Visible = true;
                    Occasion_Label.Enabled = true;
                    Occasion_TextBox.Text = " ";
                    Occasion_TextBox.Focus();
                }
                else
                {
                    f4 = 0;
                    Occasion_Label.Enabled = false;
                    Occasion_Label.Visible = false;
                }
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String s1 = "", s2 = "";
            if (GiftType_DropDownList1.Text.Equals("Others", StringComparison.OrdinalIgnoreCase) == true)
            {
                f2 = c.gifttype(GiftType_TextBox);
                if (f2 == 1)
                {
                    Gift_Label.Text = "*Already Exists";
                    Gift_Label.Enabled = true;
                    Gift_Label.Visible = true;
                    GiftType_TextBox.Text = " ";
                    GiftType_TextBox.Focus();
                }
                else
                {
                    f2 = 0;
                    Gift_Label.Visible = false;
                    Gift_Label.Enabled = false;
                }

            }

            if (OccasionType_DropDownList2.Text.Equals("others", StringComparison.OrdinalIgnoreCase))
            {
                f4 = c.occasion(Occasion_TextBox);
                if (f4 == 1)
                {
                    Occasion_Label.Text = "*Already Exists";
                    Occasion_Label.Visible = true;
                    Occasion_Label.Enabled = true;
                    Occasion_TextBox.Text = " ";
                    Occasion_TextBox.Focus();
                }
                else
                {
                    f4 = 0;
                    Occasion_Label.Enabled = false;
                    Occasion_Label.Visible = false;
                }
            }

            if (GiftType_DropDownList1.Text.Equals("Others", StringComparison.OrdinalIgnoreCase) == true
                && OccasionType_DropDownList2.Text.Equals("Others", StringComparison.OrdinalIgnoreCase) == true &&
               GiftType_DropDownList1.Text != null && OccasionType_DropDownList2.Text != null)
            {
                f2 = c.gifttype(GiftType_TextBox);
                f4 = c.occasion(Occasion_TextBox);
                if (f2 == 0 && f4 == 0 && Giftrx_Validator.IsValid && Occasionrx_Validator.IsValid)
                {
                    Gift_Label.Visible = false;
                    Occasion_Label.Visible = false;
                    c.giftwrite(GiftType_TextBox);
                    c.occassionwrite(Occasion_TextBox);
                    s1 = GiftType_TextBox.Text;
                    s2 = Occasion_TextBox.Text;
                    f5 = c.finalwrite(Cost_TextBox, Quantity_TextBox, s1, s2);


                }
                else
                {
                    f5 = 0;
                }
            }

            if (GiftType_DropDownList1.Text.Equals("Others", StringComparison.OrdinalIgnoreCase) == true
                  && OccasionType_DropDownList2.Text.Equals("Others", StringComparison.OrdinalIgnoreCase) == false
                   && (OccasionType_DropDownList2.Text != null))
            {
                if (f2 == 0 && f4 == 0)
                {
                    Gift_Label.Visible = false;
                    c.giftwrite(GiftType_TextBox);
                    s1 = GiftType_TextBox.Text;
                    s2 = GiftType_DropDownList1.Text;
                    f5 = c.finalwrite(Cost_TextBox, Quantity_TextBox, s1, s2);
                }
                else
                {
                    f5 = 0;
                }
            }
            else if (GiftType_DropDownList1.Text.Equals("Others", StringComparison.OrdinalIgnoreCase) == false &&
                (GiftType_DropDownList1.Text != null)
                && OccasionType_DropDownList2.Text.Equals("Others", StringComparison.OrdinalIgnoreCase) == true)
            {

                if (f4 == 0 && f2 == 0)
                {
                    Occasion_Label.Visible = false;
                    c.occassionwrite(Occasion_TextBox);
                    s1 = GiftType_DropDownList1.Text;
                    s2 = Occasion_TextBox.Text;
                    f5 = c.finalwrite(Cost_TextBox, Quantity_TextBox, s1, s2);
                }
                else
                {
                    f5 = 0;
                }
            }
            else if (GiftType_DropDownList1.Text.Equals("Others", StringComparison.OrdinalIgnoreCase) == false
                && OccasionType_DropDownList2.Text.Equals("Others", StringComparison.OrdinalIgnoreCase) == false
               && GiftType_TextBox.Text != null && Occasion_TextBox.Text != null)
            {

                if (f1 == 0 && f3 == 0)
                {
                    Gift_Label.Visible = false;
                    Occasion_Label.Visible = false;
                    s1 = GiftType_DropDownList1.Text;
                    s2 = OccasionType_DropDownList2.Text;
                    f5 = c.finalwrite(Cost_TextBox, Quantity_TextBox, s1, s2);
                }
            }


            if (f5 == 1)
            {
                HttpContext.Current.Response.Write("<script>alert('Gift Added Successfully " + c.labelval() + "')</script>");
                c.fillgift(GiftType_DropDownList1);
                c.filloccassion(OccasionType_DropDownList2);
                GiftType_TextBox.Text = "";
                Occasion_TextBox.Text = "";
                Cost_TextBox.Text = "";
                Quantity_TextBox.Text = "";
                Cost_TextBox.Enabled = false;
                Quantity_TextBox.Enabled = false;
                Cost.Enabled = false;
                Quantity.Enabled = false;
                Add_Button.Enabled = false;
                Reset_Button.Enabled = false;
                GiftType_DropDownList1.SelectedIndex = -1;
                OccasionType_DropDownList2.SelectedIndex = -1;
                GiftType_TextBox.Visible = false;
                Occasion_TextBox.Visible = false;
                Gift_Label.Visible = false;
                Occasion_Label.Visible = false;
                Gift_Validator.Visible = false;
                Occasion_Validator.Visible = false;
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            GiftType_DropDownList1.SelectedIndex = -1;
            OccasionType_DropDownList2.SelectedIndex = -1;
            Cost_TextBox.Text = "";
            Quantity_TextBox.Text = "";
            GiftType_TextBox.Text = "";
            Occasion_TextBox.Text = "";
            GiftType_TextBox.Visible = false;
            Occasion_TextBox.Visible = false;
            c.fillgift(GiftType_DropDownList1);
            c.filloccassion(OccasionType_DropDownList2);
            Gift_Label.Visible = false;
            Occasion_Label.Visible = false;
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