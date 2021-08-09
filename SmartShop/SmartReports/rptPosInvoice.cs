using DevExpress.XtraReports.UI;

namespace SmartShop.SmartReports
{
    public partial class rptPosInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPosInvoice()
        {
            InitializeComponent();
        }

        private void rptPosInvoice_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.DataSource = SmartShopReports.GetAllSalesParentPosInvoice(Parameters["PosInvoice"].Value.ToString());
        }
    }  
}
