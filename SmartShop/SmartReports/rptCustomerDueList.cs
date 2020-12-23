namespace SmartShop.SmartReports
{
    public partial class rptCustomerDueList : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCustomerDueList()
        {
            InitializeComponent();
            this.DataSource = SmartShopReports.GetCompanyProfile();
            DetailReport.DataSource = SmartShopReports.GetAllCustomerArrear();
        }
    }
}
