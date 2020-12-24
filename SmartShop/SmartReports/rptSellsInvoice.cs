using DevExpress.XtraReports.UI;

namespace SmartShop.SmartReports
{
    public partial class rptSellsInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSellsInvoice()
        {
            InitializeComponent();
            DetailReport2.DataSource = SmartShopReports.GetCompanyProfile();
        }

        private void rptSellsInvoice_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.DataSource = SmartShopReports.GetAllSellsParentByInvoice(Parameters["SellsInvoice"].Value.ToString());
            DetailReport.DataSource = SmartShopReports.GetAllSellsByChildInvoice(Parameters["SellsInvoice"].Value.ToString());
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRTableCell xrTableCell56 = (XRTableCell)FindControl("xrTableCell56", true);
            ((XRLabel)sender).Text = xrTableCell56.Value.ToString();
        }

        private void xrLabel4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRTableCell xrTableCell54 = (XRTableCell)FindControl("xrTableCell54", true);
            ((XRLabel)sender).Text = xrTableCell54.Value.ToString();
        }

        private void xrLabel8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRTableCell xrTableCell57 = (XRTableCell)FindControl("xrTableCell57", true);

            ((XRLabel)sender).Text = xrTableCell57.Value.ToString();
        }
    }
}
