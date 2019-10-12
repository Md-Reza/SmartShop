using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraEditors;
using SmartShop.Models;

namespace SmartShop.Repository
{
    
   public class Connection
    {

        //SqlConnection _sqlConnection;
        //SqlDataAdapter _sqlDataAdapter;
        //SqlCommand _sqlCommand;
       // DataTable _dt;
        /// <summary>
        /// Get Database Server Name -- Developed By : Chandra Shakar
        /// </summary>
        public static readonly string ServerName = "CMABLVK-ITD08";

        /// <summary>
        /// Get Database Name -- Developed By : Chandra Shakar
        /// </summary>
        public static readonly string DatabaseName = "shop";

        /// <summary>
        /// Get Database Login Name -- Developed By : Chandra Shakar
        /// </summary>
        public static readonly string LoginName = "sa";

        /// <summary>
        /// Get Database Login Password -- Developed By : Chandra Shakar
        /// </summary>
        public static readonly string LoginPassword = "Crystal@1234";

        /// <summary>
        /// Get Database Connection String -- Developed By : Chandra Shakar
        /// </summary>
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
