namespace SmartShop.SmartReports
{
    public partial class rptStockList : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockList()
        {
            InitializeComponent();
            DetailReport2.DataSource = SmartShopReports.GetCompanyProfile();
            DetailReport.DataSource = SmartShopReports.GetAllStockList();
        }

        private void rptStockList_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            DetailReport.DataSource = SmartShopReports.GetAllStockList();
        }
    }
}
