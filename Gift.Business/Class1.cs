using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using PdfSharp.Pdf;
using System.Data.SqlClient;
using Gift.Data;


namespace Gift.Business
{
    public class Class1
    {
        string log = @"C:\log.txt";

        Class2 c = new Class2();

        public int login(TextBox t1, TextBox t2)
        {
            int f = 0;
            f = c.login(t1, t2);
            return f;
        }

        public bool email(string t)
        {
            bool f = true;
            f = c.email(t);
            return f;
        }

        public void write(TextBox t1, TextBox t2, TextBox t3, TextBox t4, DropDownList c1, TextBox dt1, TextBox t5)
        {
            string f = "";
            f = c.write(t1, t2, t3, t4, c1, dt1, t5);
            if (f.Length != 0)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Your User ID is " + f + "')</script>");
            }
            else
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    c.Log("Database Write Error", w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    c.DumpLog(r);
                }
            }
        }

        //fill gift

        public void fillgift(DropDownList c1)
        {
            c.fillgift(c1);
        }

        public void filloccassion(DropDownList c2)
        {
            c.filloccassion(c2);

        }

        public int giftwrite(TextBox t)
        {
            int f = 0;
            f = c.giftwrite(t);
            return f;
        }

        public int occassionwrite(TextBox t)
        {
            int f = 0;
            f = c.occassionwrite(t);
            return f;
        }

        public int gifttype(TextBox t)
        {
            int f = 0;
            if (t.Text.Length > 0)
            {
                f = c.giftvalidate(t);
            }
            else
            {
                f = 0;
            }
            return f;
        }

        public int occasion(TextBox t)
        {
            int f = 0;
            if (t.Text.Length > 0)
            {
                f = c.occassionvalidate(t);
            }

            return f;
        }

        public int finalwrite(TextBox t, TextBox t1, string S, string S1)
        {
            int f = 0;
            f = c.finalwrite(t, t1, S, S1);
            return f;
        }

        public string labelval()
        {
            string f = " ";
            f = c.labelval();
            return f;
        }

       //book gift

        public void formLoadDataB(DropDownList giftTypeList, DropDownList occassion)
        {
            c.formLoadData(giftTypeList, occassion);
        }

        public void giftTypeList_changedB(DropDownList giftTypeList, DropDownList occassion)
        {
            c.giftTypeList_changed(giftTypeList, occassion);
        }

        public void button1ClickB(Button button4, TextBox TextBox1, TextBox TextBox2, TextBox TextBox3, DropDownList giftTypeList, DropDownList occassion, DropDownList giftsubtypelist, Label label5, Label label7, Label label9)
        {
            c.button1Click(button4, TextBox1, TextBox2, TextBox3, giftTypeList, occassion, giftsubtypelist, label5, label7, label9);
        }

        public SqlDataReader giftsubtypelist_changedB(DropDownList giftsubtypelist)
        {
            SqlDataReader sdr = c.giftsubtypelist_changed(giftsubtypelist);
            return sdr;
        }

        public string writeB(TextBox t1,string custid, TextBox t2, TextBox dt1, DropDownList c1, DateTime d1)
        {

            string s1 = c.bwrite(t1,custid, t2, dt1, c1, d1);
            return s1;
        }

        public void quantity_updateB(string bid)
        {
            c.quantity_update(bid);
        }

        //update details

        public int get_details(TextBox textBox1)
        {
            int g = 0;
            int f = c.get_booking_form1(textBox1);
            if (textBox1.Text == "" || textBox1.Text.Length < 15)
            {
                g = 2;
            }
            else if (f == 1)
            {
                g = 1;
                //int f = 0;
            }
            else
            {
                g = 0;
            }
            return g;
        }

        public void user_details(Label label6, Label label5, Label label10, Label label7)
        {
            c.user_data(label6, label5, label10, label7);
        }

        public void update_details(DropDownList DropDownList1, TextBox Textbox1, Label label7)
        {
            c.get_data_form2(DropDownList1, Textbox1, label7);
            HttpContext.Current.Response.Write("<script type = text/javascript> alert('Updated Successfully')</script>");
        } 
        //report generation

        public void gifttype(DropDownList gt, string d1, string d2)
        {
            c.gifttype(gt, d1, d2);
        }

        public void subid(DropDownList si, string gt)
        {
            c.subid(si, gt);
        }

        public void bookingid(DropDownList bi, string si, string d1, string d2)
        {
            c.bookingid(bi, si, d1, d2);
        }

        public void status(Label st, Label ed, Label ad, string bi)
        {
            c.status(st, ed, ad, bi);
        }

        public void tamt(DropDownList gt, Label ta, string d1, string d2)
        {
            c.tamt(gt, ta, d1, d2);
        }

        public void amt(DropDownList si, Label a, string d1, string d2)
        {
            c.amt(si, a, d1, d2);
        }

        public void quantity(DropDownList si, Label quant, string d1, string d2)
        {
            c.quantity(si, quant, d1, d2);
        }

        public PdfDocument report(string d1, string d2)
        {
            PdfDocument pdf = c.report(d1, d2);
            return pdf;
        }

        //log file

        public void Log(string logMessage, TextWriter w)
        {
            c.Log(logMessage, w);
        }

        public void DumpLog(StreamReader r)
        {
            c.DumpLog(r);
        }
    }
}
