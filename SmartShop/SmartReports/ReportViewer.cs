using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using SmartShop.Models;
using SmartShop.Reports;
using SmartShop.Reports.ReportsRepositories;
using SmartShop.Repository;
using System;
using static SmartShop.Interface.Interface;
using SmartShop.Properties;

namespace SmartShop.SmartReports
{
    public partial class ReportViewer : DevExpress.XtraEditors.XtraForm
    {
        internal static rptPurchaseRegister Report;
        ComapnySetupRepository comapny = new ComapnySetupRepository();

        IBaseRepository<CompanyInformation> companyBaseRepository = new ComapnySetupRepository();
        PurchaseRepository purchase = new PurchaseRepository();
        PurchaseReportsRepositories reportsRepositories = new PurchaseReportsRepositories();
        public XtraReport reportControl;
        ReportsHelper reportsHelper = new ReportsHelper();

        public string KeyFieldCode;
        public string KeyFieldCode2;
        public string DateT;
        public string DateF;
        public ReportViewer(string reportIdentity, string defaultValue)
        {
            InitializeComponent();

            try
            {
                Models.Reports reportInfo = SReports.GetReports(reportIdentity, defaultValue);
                if (reportInfo == null)
                {
                    XtraMessageBox.Show(this, $"Report not found. Please contact with IT Team.");
                    return;
                }
                string controlPath = "SmartShop." + "SmartReports." + reportInfo.ReportName;
                reportControl = (XtraReport)Activator.CreateInstance(Type.GetType(controlPath));
                reportControl.Visible = true;
                rptViewer.DocumentSource = reportControl;
                reportControl.RequestParameters = true;
                reportControl.ParametersRequestBeforeShow += ReportControl_ParametersRequestBeforeShow;
                if (reportControl.Parameters.Count > 0)
                    reportControl.CreateDocument();

                if (reportInfo.HasHeader) ReportHeader(reportInfo);
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message);
            }
            //if (reportInfo.HasFooter) ReportFooter();
        }
        private void ReportControl_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            LookUpEdit lookUpEdit;
            DateEdit dateEdit;
            TextEdit textEdit;

            foreach (DevExpress.XtraReports.Parameters.ParameterInfo parameterInfo in e.ParametersInformation)
            {
                lookUpEdit = new LookUpEdit();
                parameterInfo.Editor = lookUpEdit;
                lookUpEdit.Properties.DropDownRows = 10;
                lookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                lookUpEdit.Properties.PopupFilterMode = PopupFilterMode.Contains;
                lookUpEdit.EditValue = KeyFieldCode;

                dateEdit = new DateEdit();
                parameterInfo.Editor = dateEdit;
                dateEdit.EditValue = KeyFieldCode;
                dateEdit.EditValue = KeyFieldCode2;

                textEdit = new TextEdit();
                parameterInfo.Editor = textEdit;
                textEdit.EditValue = KeyFieldCode;

                switch (parameterInfo.Parameter.Name)
                {
                    case "PurchaseInvoice":
                        parameterInfo.Parameter.Description = @"Purchase Invoice : ";
                        lookUpEdit.Properties.DataSource = reportsHelper.GetPurchaseInvoice();
                        lookUpEdit.Properties.DisplayMember = "PurchaseInvoice";
                        lookUpEdit.Properties.ValueMember = "PurchaseInvoice";
                        lookUpEdit.Properties.NullText = @"Select Purchase Invoice";
                        lookUpEdit.Properties.Columns.Add(new
                            DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurchaseInvoice", 0, "Purchase Invoice"));
                        reportControl.Parameters["PurchaseInvoice"].Value = KeyFieldCode;
                        break;
                    case "SellsInvoice":
                        parameterInfo.Parameter.Description = @"Sells Invoice : ";
                        lookUpEdit.Properties.DataSource = reportsHelper.GeSellsInvoice();
                        lookUpEdit.Properties.DisplayMember = "SellsInvoice";
                        lookUpEdit.Properties.ValueMember = "SellsInvoice";
                        lookUpEdit.Properties.NullText = @"Select sells invoice";
                        lookUpEdit.Properties.Columns.Add(new
                            DevExpress.XtraEditors.Controls.LookUpColumnInfo("SellsInvoice", 0, "Sells Invoice"));
                        reportControl.Parameters["SellsInvoice"].Value = KeyFieldCode;
                        break;
                    case "PosInvoice":
                        parameterInfo.Parameter.Description = @"Sells Invoice : ";
                        lookUpEdit.Properties.DataSource = reportsHelper.GeSellsInvoice();
                        lookUpEdit.Properties.DisplayMember = "SellsInvoice";
                        lookUpEdit.Properties.ValueMember = "SellsInvoice";
                        lookUpEdit.Properties.NullText = @"Select sells invoice";
                        lookUpEdit.Properties.Columns.Add(new
                            DevExpress.XtraEditors.Controls.LookUpColumnInfo("SellsInvoice", 0, "Sells Invoice"));
                        reportControl.Parameters["PosInvoice"].Value = KeyFieldCode;
                        break;
                    case "SalesMonth":
                         parameterInfo.Parameter.Description = @"Sells Month : ";
                        textEdit.EditValue = Settings.Default.SalesMonth;
                        reportControl.Parameters["SalesMonth"].Value = KeyFieldCode;
                        break;
                    case "SellsDateF":
                        parameterInfo.Parameter.Description = @"Form Date : ";
                        dateEdit.EditValue = "SellsDateF";
                        reportControl.Parameters["SellsDateF"].Value = KeyFieldCode;
                        break;
                    case "SellsDateT":
                        parameterInfo.Parameter.Description = @"To Date : ";
                        dateEdit.EditValue = "SellsDateT";
                        reportControl.Parameters["SellsDateT"].Value = KeyFieldCode2;
                        break;

                    default:
                        break;
                }
            }
        }
        private void ReportHeader(Models.Reports reportInfo)
        {
            //  CompanyInformation companyProfile = SmartShopReports.GetCompanyProfile().FirstOrDefault();

            //XRLabel lblCompanyName = (XRLabel)reportControl.FindControl("lblCompanyName", true);
            //lblCompanyName.Text = companyProfile.Name.ToString();

            //XRLabel lblAddress = (XRLabel)reportControl.FindControl("lblAddress", true);
            //lblAddress.Text = companyProfile.Address;

            //XRLabel lblContactInfo = (XRLabel)reportControl.FindControl("lblContactInfo", true);
            //lblContactInfo.Text = companyProfile.CEO + "' ('" + companyProfile.ContactNo + "' )'";

            //XRLabel lblReportName = (XRLabel)reportControl.FindControl("lblReportName", true);
            //lblReportName.Text = reportInfo.ReportDisplayName;
        }

    }
}