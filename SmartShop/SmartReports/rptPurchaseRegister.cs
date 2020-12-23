namespace SmartShop.SmartReports
{
    public partial class rptPurchaseRegister : DevExpress.XtraReports.UI.XtraReport
    {

        public rptPurchaseRegister()
        {
            InitializeComponent();
        }
        private void rptPurchaseRegister_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.DataSource = SmartShopReports.GetCompanyProfile();
            PurchaseChild.DataSource = SmartShopReports.GetAllPurchaseByDate(Parameters["SellsDateF"].Value.ToString(), Parameters["SellsDateT"].Value.ToString());
        }
    }
}
