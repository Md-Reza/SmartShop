using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SmartShop.Models;


namespace SmartShop.Repository
{
    public static class GlobalVeriable
    {
        public static UserLogin gUserLoginInformation;
        public static DataTable DataTable;
        public static bool FncInitCompanyInfo(string UserName , string Password)
        {
            string sql = "select * from UserLogin where userStatus='A'";
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            DataTable or1 = Connection.GetDataTable(sql);
            if (or1.Rows.Count > 0)
            {
                DataRow or = or1.Rows[0];
                try
                {
                    gUserLoginInformation =new UserLogin();
                    gUserLoginInformation.UserName = or["Name"].ToString();
                    gUserLoginInformation.NickName = or["LoginName"].ToString();
                    gUserLoginInformation.LoginName = or["LoginName"].ToString();
                    gUserLoginInformation.Password = or["Password"].ToString();
                    gUserLoginInformation.MobileNo = or["MobileNo"].ToString();
                    gUserLoginInformation.DesiCode = or["DesiCode"].ToString();
                    gUserLoginInformation.Status = or["UserStatus"].ToString();
                }
                catch (Exception eee)
                {
                    MessageBox.Show(eee.ToString());
                }
                return true;
            }
            else
            {

                MessageBox.Show(@"User Information Not OK");
            }

            return false;

        }
    }
}
