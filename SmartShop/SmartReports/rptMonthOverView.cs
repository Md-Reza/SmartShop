namespace SmartShop.SmartReports
{
    public partial class rptMonthOverView : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMonthOverView()
        {
            InitializeComponent();
          //  Detail.DataSource = SmartShopReports.GetCompanyProfile();
        }

        private void rptMonthOverView_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.DataSource = SmartShopReports.GetCompanyProfile();
            DetailReport.DataSource = SmartShopReports.GetByMonthWiseStock(Parameters["SalesMonth"].Value.ToString());
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
