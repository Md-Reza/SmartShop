namespace SmartShop.SmartReports
{
    public partial class rptStockListingBySupplier : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStockListingBySupplier()
        {
            InitializeComponent();
            //this.DataSource = SmartShopReports.GetCompanyProfile();
            DataSource = sqlDataSource1;
        }

    }
}
