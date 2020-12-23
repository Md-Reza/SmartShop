using Dapper;
using DevExpress.XtraEditors;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SmartShop.Properties;

namespace SmartShop.Repository
{

    public class Connection
    {

        // public static readonly string ServerName = "CMABLVK-ITD08";
        public static readonly string ServerName = Settings.Default.DataBaseName;
        public static readonly string DatabaseName = "shop";
        public static readonly string LoginName = "sa";
        public static readonly string LoginPassword = "Crystal@1234";

        public static string GetConnectionString()
        {
            return "Data Source = " + ServerName + "; Initial Catalog = " + DatabaseName + "; User Id = " + LoginName + "; Password = " + LoginPassword + ";";
        }
        public static string ValueCheck(CheckEdit Check)
        {
            if (Check.Checked)
                return "A";
            else
                return "N";
        }

        public static DataTable GetDataTable(String query)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, GetConnectionString());
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dt;
            }
        }

        public IEnumerable<UserLogin> Get()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<UserLogin> returnValue = connection.Query<Models.UserLogin>(@"Select * from UserLogin");
            connection.Close();
            return returnValue;
        }
    }
}
