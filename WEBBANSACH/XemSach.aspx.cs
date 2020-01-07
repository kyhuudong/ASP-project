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
    public partial class XemSach : System.Web.UI.Page
    {
        //string address = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
        //F:\ASP\WebApplication1\WEBBANSACH\App_Data\DBWEBBANSACH.mdf;Integrated Security=True";
        DAL.CommonClass sqlJob = new DAL.CommonClass();        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["MALOAI"] != null)
                {
                    string bmaloai = Request.QueryString["MALOAI"].ToString();
                    NapSach(bmaloai);

                }
                else
                    return;
            }
        }

        void NapSach(string bmaloai)
        {
            string sql = "select * from MATSACH where MALOAI='" + bmaloai + "'";
            DataTable dt = sqlJob.LoadData(sql);
            this.DataList1.DataSource = dt;
            this.DataList1.DataBind();
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string masach = ((ImageButton)sender).CommandArgument;
            Context.Items["MASACH"] = masach;
            Server.Transfer("MatSachChiTiet.aspx?MASACH="+masach);
        }


    }
}