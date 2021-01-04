using SmartShop.Models;
using SmartShop.Repository;
using static SmartShop.Interface.StockList;

namespace SmartShop.SmartReports
{
    public partial class rptStockList : DevExpress.XtraReports.UI.XtraReport
    {
        IStockList<Stock> stock = new StockRepository();
        public rptStockList()
        {
            InitializeComponent();
            DetailReport2.DataSource = SmartShopReports.GetCompanyProfile();
            //DetailReport.DataSource = SmartShopReports.GetAllStockList();
            DetailReport.DataSource = stock.GetAllStockList();
        }

        private void rptStockList_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            DetailReport.DataSource = stock.GetAllStockList();
        }
    }
}
