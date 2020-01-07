using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WEBBANSACH.DAL
{
    public class CommonClass
    {
        string address = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
        C:\Users\OS\Desktop\New folder\ASP-project-master\WEBBANSACH\App_Data\DBWEBBANSACH.mdf;Integrated Security=True";
        SqlConnection sqlC = new SqlConnection();
        public CommonClass()
        {
            sqlC = new SqlConnection(address);
        }

        public void Mo()
        {
            if(sqlC.State != ConnectionState.Open)
            {
                sqlC.Open();
            }
        }

        public void Dong()
        {
            if (sqlC.State != ConnectionState.Closed)
            {
                sqlC.Close();
            }
        }

        public DataTable LoadData(string sql)
        {
            SqlDataAdapter sqlD = new SqlDataAdapter(sql, sqlC);
            DataTable dt = new DataTable();
            sqlD.Fill(dt);

            return dt;
        }

        public int ExecuteNonquery(string sql)
        {
            SqlCommand sqlcommand = new SqlCommand(sql, sqlC);
            Mo();
            int ketqua = sqlcommand.ExecuteNonQuery();
            Dong();

            return ketqua;
        }

    }
}