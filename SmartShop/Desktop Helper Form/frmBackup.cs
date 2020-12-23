using DevExpress.XtraEditors;
using SmartShop.Repository;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmBackup : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public frmBackup()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dr = new FolderBrowserDialog();
            if (dr.ShowDialog() == DialogResult.OK)
            {
                txtBrowse.EditValue = dr.SelectedPath;
                txtBrowse.Enabled = true;
            }
        }

        public static int ExecuteStatment(string query)
        {
            SqlConnection conn = new SqlConnection(Connection.GetConnectionString());
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    int rowCount = command.ExecuteNonQuery();
                    return rowCount;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    return -1;
                }
            }
        }
        private void btnBackup_Click(object sender, EventArgs e)
        {
            string nameDatabase = txtBrowse.EditValue.ToString();
            try
            {
                string database = _connection.Database.ToString();
                if (nameDatabase == string.Empty)
                {
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Please Select Directory Path", "System Message", new[] { DialogResult.OK },
                  FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                }
                else
                {
                    string cmd = "BACKUP DATABASE[" + database + "] TO DISK ='" + nameDatabase + "\\" + "SalesDatabase" + "_" + DateTime.Now.ToString("yyyy-mm-MM-HH-mm-ss") + ".bak'";
                    _connection.Open();
                     ExecuteStatment(cmd);
                    txtBrowse.Enabled = false;
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, @" " + nameDatabase + "\\" + @"SalesDatabase" + "-" + DateTime.Now.ToString("yyyy-mm-MM--HH-mm-ss") + ".bak " + " DataBase Backup Complete Successfully ", "System Message", new[] { DialogResult.OK },
                    FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Backup not completed");
            }
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            txtBrowse.EditValue = @"E:\SmartShop\SmartShop\BackupDatabase";
        }
    }
}