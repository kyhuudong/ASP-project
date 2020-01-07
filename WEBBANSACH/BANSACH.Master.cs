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
    public partial class BANHANG : System.Web.UI.MasterPage
    {
        //string address = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
        //F:\ASP\WebApplication1\WEBBANSACH\App_Data\DBWEBBANSACH.mdf;Integrated Security=True";
        DAL.CommonClass sqlJob = new DAL.CommonClass();
        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack) return;

            try
            {
                string sql = "select * from LOAISACH";
                DataTable dt = sqlJob.LoadData(sql);
                this.DataList1.DataSource = dt;
                this.DataList1.DataBind();

            }
            catch (SqlException ex)
            {
                Response.Write(ex.Errors);
            }
        }


        
        protected void Button2_Click(object sender, EventArgs e)
        {

            string sql = "select * from KHACHHANG where TENDANGNHAP='"+txtTenDangNhap.Text+"' and MATKHAU='"+txtMatKhau.Text+"'";
            DataTable dt = sqlJob.LoadData(sql);

            if (dt.Rows.Count > 0)
            {
                Response.Cookies["TENDANGNHAP"].Value = txtTenDangNhap.Text;
                Response.Cookies["MATKHAU"].Value = txtMatKhau.Text;
                Response.Cookies["TENDANGNHAP"].Expires = DateTime.Now.AddMinutes(1);
                Response.Cookies["MATKHAU"].Expires = DateTime.Now.AddMinutes(1);

                txtThongBao.Text = "Chào "+Request.Cookies["TENDANGNHAP"].Value+" đã đăng nhập thành công !";
                
            }
            else
            {
                txtThongBao.Text = "Bạn đã nhập sai thông tin đắng nhập !";
            }
        }
    }
}