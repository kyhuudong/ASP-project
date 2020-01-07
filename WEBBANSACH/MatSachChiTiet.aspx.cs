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
    public partial class MatSachChiTiet : System.Web.UI.Page
    {
        string address = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
        F:\ASP\WebApplication1\WEBBANSACH\App_Data\DBWEBBANSACH.mdf;Integrated Security=True";

        SqlConnection sqlC = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            sqlC.ConnectionString = address;
            sqlC.Open();
            sqlCommand.Connection = sqlC;
            sqlCommand.CommandType = CommandType.Text;
            if (!IsPostBack)
            {
                if (Request.Cookies["TENDANGNHAP"] == null)
                {
                    this.Label8.Text = "Bạn phải đăng nhập để xem mặt sách";
                    return;
                }

                if (Request.QueryString["MASACH"] != null)
                {
                    string masach = Request.QueryString["MASACH"].ToString();

                    ChiTietSach(masach);

                }
            }
        }

        public void ChiTietSach(string masach)
        {
            SqlConnection sqlC = new SqlConnection(address);
            string sql = "select * from MATSACH where MASACH="+masach+"";
            SqlDataAdapter sqlD = new SqlDataAdapter(sql, sqlC);
            DataTable dt = new DataTable();
            sqlD.Fill(dt);

            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Button mua = (Button)sender;
            string masach = Request.QueryString["MASACH"].ToString();

            DataListItem item = (DataListItem)mua.Parent;
            string soluong = ((TextBox)item.FindControl("TextBox1")).Text;
            

            if (Request.Cookies["TENDANGNHAP"] == null)
            {
                this.Label8.Text = "Bạn phải đăng nhập để mua hàng !";
            }

            string tendangnhap = Request.Cookies["TENDANGNHAP"].Value;
            string query = "select * from DONHANG where TENDANGNHAP='"+tendangnhap+"' and MASACH='"+masach+"'";

            sqlCommand = new SqlCommand(query,sqlC);           
            SqlDataReader sqlR = sqlCommand.ExecuteReader();

            if (sqlR.Read())
            {
                sqlR.Close();
                sqlCommand = new SqlCommand("update DONHANG set SOLUONG=SOLUONG+'"+soluong+"' where TENDANGNHAP='"+tendangnhap+"' and MASACH='"+masach+"'",sqlC);

            }
            else
            {
                sqlR.Close();
                sqlCommand = new SqlCommand("insert into DONHANG values('"+tendangnhap+"','"+masach+"','"+soluong+"')",sqlC);
            }
            sqlCommand.ExecuteNonQuery();
            sqlC.Close();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("GioSach.aspx");
        }
    }
}