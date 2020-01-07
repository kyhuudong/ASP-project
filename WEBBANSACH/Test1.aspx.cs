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
    public partial class Test1 : System.Web.UI.Page
    {
        string address = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
        F:\ASP\WebApplication1\WEBBANSACH\App_Data\DBWEBBANSACH.mdf;Integrated Security=True";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            try
            {
                string sql = "select * from LOAISACH";
                SqlConnection sqlC = new SqlConnection(address);
                SqlDataAdapter sqlD = new SqlDataAdapter(sql,sqlC);
                DataTable dt = new DataTable();

                sqlD.Fill(dt);
                this.DataList1.DataSource = dt;
                this.DataList1.DataBind();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Errors);
            }
        }
    }
}