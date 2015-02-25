using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp;
using System.Web;
using System.Globalization;

namespace Gift.Data
{
    public class Class2
    {
        string cs = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
        string log = @"C:\log.txt";

        //registration

        public int login(TextBox t1, TextBox t2)
        {
            int f = 0;
            try
            {
                string query = "admin_login";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@inp1", t1.Text);
                cmd.Parameters.AddWithValue("@inp2", t2.Text);
                SqlDataReader dbr;
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    f = 1;
                }
                con.Close();
                if (f == 0)
                {
                    query = "customer_login ";
                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@inp1", t1.Text);
                    cmd.Parameters.AddWithValue("@inp2", t2.Text);
                    con.Open();
                    dbr = cmd.ExecuteReader();
                    while (dbr.Read())
                    {
                        f = 2;
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + ex.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }

            return f;
        }

        public string write(TextBox t1, TextBox t2, TextBox t3, TextBox t4, DropDownList c1, TextBox dt1, TextBox t5)
        {
            string s = "";
            try
            {
                string connectionString = cs;
                string query = "insertion";
                string query2 = "custid";

                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(t1.Text.ToString()));
                cmd.Parameters.AddWithValue("@contact", t2.Text);
                cmd.Parameters.AddWithValue("@pass", t3.Text);
                cmd.Parameters.AddWithValue("@email", t4.Text);
                cmd.Parameters.AddWithValue("@gender", c1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@dob", Convert.ToDateTime(dt1.Text).Date);
                cmd.Parameters.AddWithValue("@addr", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(t5.Text.ToString()));
                cmd.ExecuteNonQuery();
                cn.Close();

                SqlCommand cm1 = new SqlCommand(query2, cn);
                cm1.CommandType = CommandType.StoredProcedure;
                cm1.Parameters.AddWithValue("@inp", t4.Text);
                cn.Open();
                using (SqlDataReader dbr = cm1.ExecuteReader())
                {
                    while (dbr.Read())
                    {
                        s = dbr.GetString(0);
                    }
                }
                cn.Close();
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
            return s;
        }

        public bool email(string t)
        {
            bool f = true;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = cs;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "FindString";
            command.Parameters.AddWithValue("@inp", t);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    f = false;
                    return f;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + ex.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return f;
        }
        //add gift

        public void fillgift(DropDownList c1)
        {
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlDataAdapter da1 = new SqlDataAdapter(" select Type from gtype order by id  ", conn);
            DataTable t1 = new DataTable();
            da1.Fill(t1);
            c1.DataSource = t1;
            c1.DataValueField = "Type";
            c1.DataTextField = "Type";
            c1.DataBind();
            conn.Close();
        }

        public void filloccassion(DropDownList c2)
        {
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlDataAdapter da1 = new SqlDataAdapter(" select name from occassion order by id ", conn);
            DataTable t2 = new DataTable();
            da1.Fill(t2);
            c2.DataSource = t2;
            c2.DataValueField = "name";
            c2.DataTextField = "name";
            c2.DataBind();
            conn.Close();

        }

        public int giftvalidate(TextBox t)
        {
            int f = 0;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = cs;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "FindString";
            command.Parameters.AddWithValue("@inp", t.Text.ToUpper());
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    f = 1;
                    return f;
                }
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return f;
        }
       
        public int occassionvalidate(TextBox t)
        {
            int f = 0;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = cs;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "FindOccas";
            command.Parameters.AddWithValue("@inp1", t.Text.ToUpper());
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    f = 1;
                    return f;
                }
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return f;
        }

        public int giftwrite(TextBox t)
        {
            int f = 0;
            try
            {
                string connectionString = cs;
                string query = "gift_insertion";
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@inp", t.Text.ToUpper());
                cmd.ExecuteNonQuery();
                cn.Close();
                f = 1;
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
            return f;
        }

        public int occassionwrite(TextBox t)
        {
            int f = 0;
            try
            {
                string connectionString = cs;
                string query = "occassion_insertion";
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@inp", t.Text.ToUpper());
                cmd.ExecuteNonQuery();
                cn.Close();
                f = 1;
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
            return f;
        }

        public int finalwrite(TextBox t, TextBox t1, string S1, string S2)
        {
            int f = 0;
            try
            {
                string connectionString = cs;
                string query = "occgift";
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@gift", S1);
                cmd.Parameters.AddWithValue("@occ", S2);
                cmd.Parameters.AddWithValue("@cost", t.Text);
                cmd.Parameters.AddWithValue("@qun", t1.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                f = 1;
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
            return f;
        }

        public string labelval()
        {
            string f = " ";
            SqlDataReader dr;
            string connectionString = cs;
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd2 = new SqlCommand("select top 1 sub_id from sub_item order by sub_id desc", cn);
            dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                f = dr[0].ToString();
            }
            cn.Close();
            return f;
        }

        //book gift

        public void formLoadData(DropDownList giftTypeList, DropDownList occassion)
        {
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlDataAdapter da1 = new SqlDataAdapter(" select gift from sub_item", conn);
            DataTable t1 = new DataTable();
            da1.Fill(t1);
            giftTypeList.DataSource = t1;
            giftTypeList.DataValueField = "gift";
            giftTypeList.DataTextField = "gift";
            giftTypeList.DataBind();


            //SqlDataAdapter da2 =  new SqlDataAdapter("select Distinct(occ) from sub_item where gift='" + giftTypeList.Text.ToString() + "'", conn);
            //DataTable t2 = new DataTable();
            //da2.Fill(t2);
            //occassion.DataSource = t2;
            //occassion.DataValueField = "occ";
            //occassion.DataTextField = "occ";
            //occassion.DataBind();
            //conn.Close();
        }

        public void giftTypeList_changed(DropDownList giftTypeList, DropDownList occassion)
        {
            //int ret = 0;
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlDataAdapter da2 = new SqlDataAdapter(" select Distinct(occ) from sub_item where gift='" + giftTypeList.Text.ToString() + "'", conn);
            DataTable t2 = new DataTable();
            da2.Fill(t2);
            occassion.DataSource = t2;
            occassion.DataValueField = "occ";
            occassion.DataTextField = "occ";
            occassion.DataBind();
            conn.Close();
            /*if (t2.Rows.Count == 0)
            {
                ret = 0;
            }
            else
            {
                ret = 1;
            }
            return ret;
             */
        }

        public void button1Click(Button button4, TextBox TextBox1, TextBox TextBox2, TextBox TextBox3, DropDownList giftTypeList, DropDownList occassion, DropDownList giftsubtypelist, Label label5, Label label7, Label label9)
        {
            //adding data to gift subtype dropdownlist3
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlDataAdapter da3 = new SqlDataAdapter(" select Sub_id from Sub_Item where Gift = '" + giftTypeList.Text.ToString() + "' AND  occ='" + occassion.Text.ToString() + "'", conn);
            DataTable t3 = new DataTable();
            da3.Fill(t3);
            giftsubtypelist.DataSource = t3;
            giftsubtypelist.DataValueField = "Sub_id".ToString();
            giftsubtypelist.DataTextField = "Sub_id";
            giftsubtypelist.DataBind();

            //first value from button
            SqlDataReader dr1;
            //SqlConnection conn = new SqlConnection(cs);
            //conn.Open();
            SqlCommand cmd = new SqlCommand("select Quantity,cost from Sub_Item where sub_id=(select min(Sub_id) from Sub_Item where Gift = '" + giftTypeList.Text.ToString() + "' AND  occ='" + occassion.Text.ToString() + "')", conn);
            dr1 = cmd.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    label5.Text = dr1[1].ToString();         //shows cost
                    if ((Int32)dr1[0] <= 0)
                    {
                        label7.Text = "0";
                        label9.Text = "OUT OF STOCK";
                        TextBox1.Visible = false;
                        TextBox2.Visible = false;
                        TextBox3.Visible = false;
                        button4.Enabled = false;
                        //Label10.Hide();
                        //Label11.Hide();
                        //Label12.Hide();
                    }
                    else
                    {
                        label7.Text = dr1[0].ToString();         //shows quantity
                        label9.Text = "IN STOCK";
                        TextBox1.Visible = true;
                        TextBox2.Visible = true;
                        TextBox3.Visible = true;
                        button4.Enabled = true;
                        TextBox1.Enabled = true;
                        TextBox2.Enabled = true;
                        TextBox3.Enabled = true;
                        //Button4.Enabled = true;

                    }
                }
            }

            conn.Close();
        }

        public SqlDataReader giftsubtypelist_changed(DropDownList giftsubtypelist)
        {
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Quantity,cost from Sub_Item where sub_id='" + giftsubtypelist.Text + "'", conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }

        public string bwrite(TextBox t1, string custid, TextBox t2, TextBox dt1, DropDownList c1, DateTime d1)
        {
            string s = "";
            try
            {
                string connectionString = cs;
                string query = "bookinsertion";
                string query2 = "bookingid";

                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@addr", t1.Text);
                cmd.Parameters.AddWithValue("@custid", custid);
                cmd.Parameters.AddWithValue("@phoneno", t2.Text);
                cmd.Parameters.AddWithValue("@gsubid", c1.Text);
                //cmd.Parameters.AddWithValue("@edate", "2015-01-22");
                cmd.Parameters.AddWithValue("@edate", Convert.ToDateTime(dt1.Text).Date);
                cmd.Parameters.AddWithValue("@bdate", d1.Date.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
                cn.Close();

                SqlCommand cm1 = new SqlCommand(query2, cn);
                cm1.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dbr = cm1.ExecuteReader())
                {
                    while (dbr.Read())
                    {
                        s = dbr.GetString(0);
                    }
                }
                cn.Close();
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }

            }
            return s;
        }

        public void quantity_update(string bid)
        {
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Sub_Item set Quantity=Quantity-1 where Sub_id=(select gsubid from booking_details where bookingid='" + bid + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }


        //update details

        public int get_booking_form1(TextBox textbox1)
        {
            int f = 0;
            SqlDataReader dr;
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand sc = new SqlCommand("select bookingid from booking_details where bookingid= '" + textbox1.Text + "';", conn);
            dr = sc.ExecuteReader();
            if (dr.HasRows)
            {
                f = 1;
            }
            conn.Close();
            return f;
        }

        public void user_data(Label label6, Label label5, Label label10, Label label7)
        {
            SqlDataReader dr;
            string connectionString = cs;
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlCommand cmd2 = new SqlCommand("select phoneno, addr, edate from booking_details where bookingid = '" + label7.Text + "';", cn);
            dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                label6.Text = dr[0].ToString();
                label5.Text = dr[1].ToString();
                label10.Text = Convert.ToDateTime(dr[2].ToString()).Date.ToShortDateString();
            }
            cn.Close();
        }

        public void get_data_form2(DropDownList dropdownList1, TextBox TextBox1, Label label7)
        {
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand sc = new SqlCommand("update booking_details set status1 = '" + dropdownList1.Text + "', adate = '" + Convert.ToDateTime(TextBox1.Text).Date + "'where bookingid = '" + label7.Text + "';", conn);
            int o = sc.ExecuteNonQuery();
            conn.Close();
        }

        //report generation

        public void gifttype(DropDownList gt, string d1, string d2)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("select Type from gtype gt join sub_item si on gt.Type=si.gift join booking_details bd on si.sub_id=bd.gsubid where bd.bdate between '" + d1 + "' and '" + d2 + "' group by gt.Type;", conn);
                DataTable t1 = new DataTable();
                da1.Fill(t1);
                gt.DataSource = t1;
                gt.DataValueField = "Type";
                gt.DataTextField = "Type";
                gt.SelectedIndex = -1;
                gt.DataBind();
                conn.Close();
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
        }

        public void subid(DropDownList si, string gt)
        {
            try
            {
                SqlConnection conn1 = new SqlConnection(cs);
                conn1.Open();
                SqlDataReader dr;
                SqlCommand cmd;
                cmd = new SqlCommand("select sub_id from sub_item where gift=(select Type from gtype where Type='" + gt + "')", conn1);
                dr = cmd.ExecuteReader();
                si.DataTextField = "sub_id".ToString();
                si.Items.Clear();
                si.DataValueField = "sub_id";
                si.DataBind();
                while (dr.Read())
                {
                    si.Items.Add(dr[0].ToString());
                }
                conn1.Close();
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
        }

        public void bookingid(DropDownList bi, string si, string d1, string d2)
        {
            try
            {
                SqlConnection conn2 = new SqlConnection(cs);
                conn2.Open();
                SqlDataReader dr1;
                SqlCommand cmd1;
                cmd1 = new SqlCommand("select bookingid from booking_details where gsubid ='" + si + "' and bdate between '" + d1 + "' and '" + d2 + "'", conn2);
                dr1 = cmd1.ExecuteReader();
                bi.DataTextField = "bookingid".ToString();
                bi.Items.Clear();
                bi.DataValueField = "bookingid";
                bi.DataBind();

                while (dr1.Read())
                {
                    bi.Items.Add(dr1[0].ToString());
                }
                conn2.Close();
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
        }

        public void status(Label st, Label ed, Label ad, string bi)
        {
            try
            {
                SqlConnection conn3 = new SqlConnection(cs);
                conn3.Open();
                SqlDataReader dr2;
                SqlCommand cmd2;
                cmd2 = new SqlCommand("select status1,convert(varchar(10),edate,111),convert(varchar(10),adate,111) from booking_details where bookingid='" + bi + "'", conn3);
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    st.Text = dr2[0].ToString();
                    ed.Text = dr2[1].ToString();
                    ad.Text = dr2[2].ToString();
                }
                conn3.Close();
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }

        }

        public void tamt(DropDownList gt, Label ta, string d1, string d2)
        {
            try
            {
                SqlConnection conn3 = new SqlConnection(cs);
                conn3.Open();
                SqlDataReader dr2;
                SqlCommand cmd2;
                cmd2 = new SqlCommand("select SUM(si.cost) from gtype gt join sub_item si on si.gift=gt.Type join booking_details bd on bd.gsubid=si.sub_id where bd.bdate between '" + d1 + "' and '" + d2 + "' and gt.Type='" + gt.SelectedValue + "'", conn3);
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    ta.Text = dr2[0].ToString();
                }
                conn3.Close();
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
        }

        public void amt(DropDownList si, Label a, string d1, string d2)
        {
            try
            {
                SqlConnection conn3 = new SqlConnection(cs);
                conn3.Open();
                SqlDataReader dr2;
                SqlCommand cmd2;
                cmd2 = new SqlCommand("select sum(si.cost) from sub_item si join booking_details bd on si.sub_id=bd.gsubid where bd.bdate between '" + d1 + "' and '" + d2 + "' and si.sub_id='" + si.SelectedValue + "'", conn3);
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    a.Text = dr2[0].ToString();
                }
                conn3.Close();
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
        }

        public void quantity(DropDownList si, Label quant, string d1, string d2)
        {
            try
            {
                SqlConnection conn3 = new SqlConnection(cs);
                conn3.Open();
                SqlDataReader dr2;
                SqlCommand cmd2;
                cmd2 = new SqlCommand("select count(si.sub_id) from sub_item si join booking_details bd on si.sub_id=bd.gsubid where bd.bdate between '" + d1 + "' and '" + d2 + "' and si.sub_id='" + si.SelectedValue + "'", conn3);
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    quant.Text = dr2[0].ToString();
                }
                conn3.Close();
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }
            }
        }

        public PdfDocument report(string d1, string d2)
        {
            PdfDocument pdf = new PdfDocument();
            try
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                int i = 0;
                string sql = null;
                int yPoint = 0;
                string gifttype = null;
                string subid = null;
                string bookingid = null;
                string bdate = null;
                string edate = null;
                string adate = null;
                string status = null;
                string amount = null;
                string tamount = null;
                string ordered = null;


                connetionString = cs;
                sql = "select gt.Type, si.sub_id, bd.bookingid, convert(varchar(10),bd.bdate,111),convert(varchar(10),bd.edate,111), convert(varchar(10),bd.adate,111), bd.status1 from gtype gt join sub_item si on gt.Type=si.gift join booking_details bd on si.sub_id=bd.gsubid where bd.bdate between '" + d1 + "' and '" + d2 + "' order by gt.Type, bd.gsubid, bd.bookingid; ";
                connection = new SqlConnection(connetionString);
                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                connection.Close();

                pdf.Info.Title = "REPORT";
                PdfPage pdfPage = pdf.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont font = new XFont("Times New Roman", 08, XFontStyle.Regular);
                XFont bold = new XFont("Arial", 08, XFontStyle.Bold);
                XFont head = new XFont("Arial", 18, XFontStyle.Bold);
                yPoint = yPoint + 80;
                graph.DrawString("GIFT DELIVERY REPORT", head, XBrushes.Black, new XRect(210, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint = yPoint + 50;
                graph.DrawString("Gift Type", bold, XBrushes.Black, new XRect(25, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString("Sub Item Id", bold, XBrushes.Black, new XRect(125, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString("Booking Id", bold, XBrushes.Black, new XRect(225, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString("Booking Date", bold, XBrushes.Black, new XRect(325, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString("Expected Delivery Date", bold, XBrushes.Black, new XRect(425, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString("Actual Delivery Date", bold, XBrushes.Black, new XRect(525, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString("Status", bold, XBrushes.Black, new XRect(625, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                yPoint = yPoint + 30;

                for (i = 0; i <= (ds.Tables[0].Rows.Count - 1); i++)
                {
                    gifttype = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    subid = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    bookingid = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    bdate = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    edate = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    adate = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                    status = ds.Tables[0].Rows[i].ItemArray[6].ToString();

                    graph.DrawString(gifttype, font, XBrushes.Black, new XRect(25, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(subid, font, XBrushes.Black, new XRect(125, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(bookingid, font, XBrushes.Black, new XRect(225, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(bdate, font, XBrushes.Black, new XRect(325, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(edate, font, XBrushes.Black, new XRect(425, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(adate, font, XBrushes.Black, new XRect(525, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(status, font, XBrushes.Black, new XRect(625, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    yPoint = yPoint + 20;
                }

                ds.Reset();
                sql = "select si.sub_id,COUNT(bd.gsubid),sum(si.cost) from sub_item si join booking_details bd on si.sub_id=bd.gsubid where bd.bdate between '" + d1 + "' and '" + d2 + "' group by si.sub_id";
                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                connection.Close();

                yPoint = yPoint + 50;
                int s = yPoint;
                graph.DrawString("Sub Item Id", bold, XBrushes.Black, new XRect(70, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString("Quantity", bold, XBrushes.Black, new XRect(130, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString("Amount", bold, XBrushes.Black, new XRect(190, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint = yPoint + 30;

                for (i = 0; i <= (ds.Tables[0].Rows.Count - 1); i++)
                {
                    subid = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                    ordered = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                    amount = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                    graph.DrawString(subid, font, XBrushes.Black, new XRect(70, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(ordered, font, XBrushes.Black, new XRect(130, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(amount, font, XBrushes.Black, new XRect(190, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    yPoint = yPoint + 20;
                }

                ds.Reset();
                sql = "select gt.Type,SUM(si.cost) from gtype gt join sub_item si on si.gift=gt.Type join booking_details bd on bd.gsubid=si.sub_id where bd.bdate between '" + d1 + "' and '" + d2 + "' group by gt.Type;";
                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                connection.Close();

                yPoint = s;
                graph.DrawString("Gift Type", bold, XBrushes.Black, new XRect(350, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                graph.DrawString("Total Amount", bold, XBrushes.Black, new XRect(450, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint = yPoint + 30;

                for (i = 0; i <= (ds.Tables[0].Rows.Count - 1); i++)
                {
                    gifttype = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                    tamount = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                    graph.DrawString(gifttype, font, XBrushes.Black, new XRect(350, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(tamount, font, XBrushes.Black, new XRect(450, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    yPoint = yPoint + 20;
                }

                //string pdfFilename = "report.pdf";
                //pdf.Save(pdfFilename);
                //Process.Start(pdfFilename);
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(log))
                {
                    Log("Exception " + e.Message, w);
                }

                using (StreamReader r = File.OpenText(log))
                {
                    DumpLog(r);
                }

            }
            return pdf;
        }

        //Log File

        //Write Log File
        public void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        //Dump Log File
        public void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

    }
}
