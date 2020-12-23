namespace SmartShop.SmartReports
{
    public partial class rptExpensesEntryReports : DevExpress.XtraReports.UI.XtraReport
    {
        public rptExpensesEntryReports()
        {
            InitializeComponent();
        }

        private void rptExpensesEntryReports_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.DataSource = SmartShopReports.GetCompanyProfile();
            DetailReport.DataSource = SmartShopReports.GetAllExpensesByDate(Parameters["SellsDateF"].Value.ToString(), Parameters["SellsDateT"].Value.ToString());
        }
    }
}
