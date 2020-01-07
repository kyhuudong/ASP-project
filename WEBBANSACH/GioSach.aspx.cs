using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBBANSACH
{
    public partial class GioSach : System.Web.UI.Page
    {
        string address = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
        F:\ASP\WebApplication1\WEBBANSACH\App_Data\DBWEBBANSACH.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            if (Request.Cookies["TENDANGNHAP"] == null) return;           
            this.docDL();
        }

        private void docDL()
        {
            
            try
            {
                string sql = "select DONHANG.MASACH,MATSACH.TENSACH,MATSACH.DONGIA,DONHANG.SOLUONG," +
                    "MATSACH.DONGIA*DONHANG.SOLUONG as THANHTIEN " +
                    "from MATSACH,DONHANG where MATSACH.MASACH=DONHANG.MASACH";

                SqlDataAdapter sqlD = new SqlDataAdapter(sql,address);
                DataTable dt = new DataTable();
                sqlD.Fill(dt);

                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();

                double tong = 0;

                foreach (DataRow row in dt.Rows)
                {
                    double thanhtien = Convert.ToDouble(row["THANHTIEN"]);
                    tong = tong + thanhtien;
                }
                this.Label2.Text = " "+tong+" đồng";

            }
            catch (SqlException ex)
            {
                Response.Write(ex.Errors);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["TENDANGNHAP"] == null) return;

            string tendangnhap = Request.Cookies["TENDANGNHAP"].Value;
            foreach (GridViewRow row in this.GridView1.Rows)
            {
                if(((CheckBox)row.FindControl("CheckBox1")).Checked)
                {
                    string masach = ((HiddenField)row.FindControl("HiddenField1")).Value;

                    string sql = "Delete DONHANG where MASACH='"+masach+"' and TENDANGNHAP='"+tendangnhap+"'";
                    SqlConnection sqlC = new SqlConnection(address);

                    try
                    {
                        sqlC.Open();
                        SqlCommand sqlCommand = new SqlCommand(sql, sqlC);
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Response.Write(ex.Errors);
                    }
                    finally
                    {
                        sqlC.Close();
                    }
                }
            }
            this.docDL();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["TENDANGNHAP"] == null) return;

            string tendangnhap = Request.Cookies["TENDANGNHAP"].Value;
            foreach (GridViewRow row in this.GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("Checkbox1")).Checked)
                {
                    string masach = ((HiddenField)row.FindControl("HiddenField1")).Value;
                    string soluong = ((TextBox)row.FindControl("TextBox1")).Text;
                    string sql = "update DONHANG set SOLUONG='" + soluong + "' where MASACH='" + masach + "' and TENDANGNHAP='"+tendangnhap+"'";

                    SqlConnection sqlC = new SqlConnection(address);
                    try
                    {
                        sqlC.Open();
                        SqlCommand sqlCommand = new SqlCommand(sql, sqlC);
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Response.Write(ex.Errors);
                    }
                    finally
                    {
                        sqlC.Close();
                    }
                }
            }

            this.docDL();
        }
    }
}