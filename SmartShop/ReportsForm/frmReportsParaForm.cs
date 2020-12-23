using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using SmartShop.Models;
using SmartShop.Reports.ReportsRepositories;
using SmartShop.Repository;
using SmartShop.SmartReports;
using System;
using System.Data.SqlClient;
using SmartShop.Properties;

namespace SmartShop.ReportsForm
{
    public partial class frmReportsParaForm : DevExpress.XtraEditors.XtraForm
    {
        //IBaseRepository<PurchaseChild> purchaseReportsRepository= new PurchaseReportsRepositories();

        PurchaseReportsRepositories purchase = new PurchaseReportsRepositories();
        public frmReportsParaForm()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            rptPurchaseRegister Report_1 = new rptPurchaseRegister();

            //ReportViewer f = new ReportViewer("report");

            Report_1.ShowPreview();
            Report_1.Print();
            Report_1.PrintDialog();

            string date = txtDateF.EditValue.ToString();
            if (!string.IsNullOrEmpty(date))
            {
                ReportViewer openForm = new ReportViewer("Report_1", Command.SettingValue.NotApplicable.ToString())
                {
                    KeyFieldCode = date
                };
                openForm.ShowDialog();
            }
        }

        private void view_Click(object sender, EventArgs e)
        {
            rptPurchaseRegister report = new rptPurchaseRegister();

            //ReportViewer f = new ReportViewer("report");

            // //f.Show();
            report.ShowPreview();
            // //report.Print();
            // //report.PrintDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ReportViewer openForm = new ReportViewer("Report_2", Command.SettingValue.NotApplicable.ToString())
            {
                DateF = txtDateFrom.EditValue.ToString(),
                DateT = txtDateTo.EditValue.ToString()
            };
            openForm.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //Sales Register
            if(radioGroup1.SelectedIndex == 0)
            {
                ReportViewer openForm = new ReportViewer("Report_0", Command.SettingValue.NotApplicable.ToString())
                {
                    KeyFieldCode = txtDateFrom.EditValue.ToString(),
                    KeyFieldCode2 = txtDateTo.EditValue.ToString()
                };
                openForm.ShowDialog();
            }

            else if (radioGroup1.SelectedIndex == 1)
            {
                //Purchase Register
                ReportViewer openForm = new ReportViewer("Report_1", Command.SettingValue.NotApplicable.ToString())
                {
                    KeyFieldCode = txtDateFrom.EditValue.ToString(),
                    KeyFieldCode2 = txtDateTo.EditValue.ToString()
                };
                openForm.ShowDialog();
            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                ReportViewer openForm = new ReportViewer("Report_2", Command.SettingValue.NotApplicable.ToString());
                openForm.ShowDialog();
            }
            else if (radioGroup1.SelectedIndex == 3)
            {
                ReportViewer openForm = new ReportViewer("Report_3", Command.SettingValue.NotApplicable.ToString());
                openForm.ShowDialog();
            }
            else if (radioGroup1.SelectedIndex == 4)
            {
                ReportViewer openForm = new ReportViewer("Report_4", Command.SettingValue.NotApplicable.ToString())
                {
                    KeyFieldCode = txtDateFrom.EditValue.ToString(),
                    KeyFieldCode2 = txtDateTo.EditValue.ToString()
                };
                openForm.ShowDialog();
            }
            else if (radioGroup1.SelectedIndex == 5)
            {
                ReportViewer openForm = new ReportViewer("Report_5", Command.SettingValue.NotApplicable.ToString())
                {
                };
                openForm.ShowDialog();
            }
            else if (radioGroup1.SelectedIndex == 6)
            {
                ReportViewer openForm = new ReportViewer("Report_6", Command.SettingValue.NotApplicable.ToString())
                {
                    KeyFieldCode = txtDateFrom.EditValue.ToString(),
                    KeyFieldCode2 = txtDateTo.EditValue.ToString()
                };
                openForm.ShowDialog();
            }
            else if (radioGroup1.SelectedIndex == 9)
            {
                ReportViewer openForm = new ReportViewer("Report_10", Command.SettingValue.NotApplicable.ToString())
                {
                    KeyFieldCode = Settings.Default.SalesMonth
                };
                openForm.ShowDialog();
            }
            else if (radioGroup1.SelectedIndex == 7)
            {
                XtraMessageBox.Show("Under Constructions");
            }
        }

        private void frmReportsParaForm_Load(object sender, EventArgs e)
        {
            txtDateFrom.EditValue = DateTime.Now;
            txtDateTo.EditValue = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}