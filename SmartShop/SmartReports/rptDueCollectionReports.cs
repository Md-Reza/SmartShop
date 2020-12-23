namespace SmartShop.SmartReports
{
    public partial class rptDueCollectionReports : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDueCollectionReports()
        {
            InitializeComponent();
        }

        private void rptDueCollectionReports_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.DataSource = SmartShopReports.GetCompanyProfile();
            DetailReport.DataSource = SmartShopReports.GetAllDueCollectionByDate(Parameters["SellsDateF"].Value.ToString(), Parameters["SellsDateT"].Value.ToString());
        }
    }
}
