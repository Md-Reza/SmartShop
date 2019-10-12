using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SmartShop.Interface;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using static SmartShop.Interface.Interface;
using System.Speech.Synthesis;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmPurchases : DevExpress.XtraEditors.XtraForm
    {
        public Command.DbCommand dbAccess;
        public DataTable dataTable;
        public string code;
        IBaseRepository<ProductName> baseRepository = new ProductNameRepository();
        IBaseRepository<CategoriesSetup> cateBaseRepository = new CategoriesRepository();
        ProductNameRepository productNameRepository = new ProductNameRepository();
        public List<PurchaseChild> listPurchaseChildren = new List<PurchaseChild>();
        IBaseRepository<PurchaseChild> purchaseBaseRepository = new PurchaseRepository();
        PurchaseRepository purchase = new PurchaseRepository();
        public frmPurchases()
        {
            InitializeComponent();

            dataTable = new DataTable();
            dataTable.Columns.Add("serial", typeof(int));
            dataTable.Columns.Add("Code", typeof(string));
            dataTable.Columns.Add("PurchaseInvoice", typeof(string));
            dataTable.Columns.Add("Qty", typeof(int));
            dataTable.Columns.Add("ProductPrice", typeof(int));
            dataTable.Columns.Add("SellingPrice", typeof(int));
            dataTable.Columns.Add("DiscountPrice", typeof(int));
            dataTable.Columns.Add("DiscountAmount", typeof(int));
            dataTable.Columns.Add("TotalAmount", typeof(int));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["serial"] };
        }

        private void frmPurchases_Load(object sender, EventArgs e)
        {
            LoadSupplyer();
            txtDate.EditValue = DateTime.Now;
        }

        private void LoadSupplyer()
        {
            cmbSupplyer.Properties.DataSource = productNameRepository.GetAllSupplyerInformations().ToList();
            cmbSupplyer.Properties.DisplayMember = "SupplyerName";
            cmbSupplyer.Properties.ValueMember = "Id";
            txtUserName.EditValue = Settings.Default.UserName;
            txtComputerName.EditValue = System.Net.Dns.GetHostName();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            if (!ValidationProvider.Validate()) return;

            if (txtDate.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $" Please input purchase date.");
                txtDate.SelectAll();
                txtDate.Focus();
                return;
            }

            if (txtCompanyInvoice.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $" Please input company invoice");
                txtCompanyInvoice.SelectAll();
                txtCompanyInvoice.Focus();
                return;
            }

            if (txtCode.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $" Please scan qr code");
                txtCode.SelectAll();
                txtCode.Focus();
                return;
            }

            if ((from DataRow dr in dataTable.Rows
                 where (string)dr["Code"] == txtCode.EditValue.ToString()
                 select (string)dr["Code"]).Any())
            {
                Voice.Speech("Already scan this item try another item");
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $" Already scan this item..try another item");
                txtCode.SelectAll();
                txtCode.Focus();
                return;
            }

            var list = productNameRepository.GetByAll(txtCode.EditValue.ToString());

            IEnumerable<PurchaseChild> purchaseChildren = purchase.GetByAll(Convert.ToString(txtCode.EditValue.ToString()));
            if (purchaseChildren.Any())
            {
                DataRow row = dataTable.NewRow();
                if ((from DataRow dr in dataTable.Rows
                     where (string)dr["Code"] == purchaseChildren.FirstOrDefault().ProductCode
                     select (string)dr["Code"]).Count() == 0)
                {
                    row["serial"] = DefultSettings.GetNewId(dataTable);
                    row["Code"] = txtCode.EditValue.ToString();
                    row["PurchaseInvoice"] = txtCompanyInvoice.EditValue;
                    row["Qty"] = 0;
                    row["ProductPrice"] = purchaseChildren.FirstOrDefault().ProductPrice;
                    row["SellingPrice"] = purchaseChildren.FirstOrDefault().SellingPrice;
                    row["DiscountPrice"] = 0;
                    row["DiscountAmount"] = 0;
                    row["TotalAmount"] = 0;
                    dataTable.Rows.Add(row);
                    gridControl1.DataSource = dataTable;
                }
                else
                {
                    SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                    synthesizer.Volume = 100;  // 0...100
                    synthesizer.Rate = -2;     // -10...10

                    synthesizer.Speak("Duplicate product code please try with different one.");
                    synthesizer.SpeakAsync("Duplicate product code please try with different one.");

                    XtraMessageBox.Show(this, "Duplicate product code please try with different one.");
                    txtCode.SelectAll();
                }

            }

            PurchaseChild purchaseChild = new PurchaseChild()
            {
                // PurchaseInvoice = 
            };
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
            gridView1.RefreshData();
        }
    }
}