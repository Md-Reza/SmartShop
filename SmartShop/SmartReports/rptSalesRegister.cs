using System;

namespace SmartShop.SmartReports
{
    public partial class rptSalesRegister : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSalesRegister()
        {
            InitializeComponent();
        }

        private void rptSalesRegister_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.DataSource = SmartShopReports.GetCompanyProfile();
            DetailReport.DataSource= SmartShopReports.GetAllSalesByDate((DateTime)Parameters["SellsDateF"].Value, (DateTime)Parameters["SellsDateT"].Value);
        }
    }
}
