using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Properties;
using System.Windows.Forms;
using static SmartShop.Interface.IDamageList;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmDamageListEntry : DevExpress.XtraEditors.XtraForm
    {
        ProductNameRepository productNameRepository = new ProductNameRepository();
        DamageInterface<DamageList> damageRepo = new DamageRepository();
        public List<DamageList> damageLists = new List<DamageList>();
        public frmDamageListEntry()
        {
            InitializeComponent();
        }

        private void frmDamageListEntry_Load(object sender, EventArgs e)
        {
            LoadProduct();
            txtPcName.EditValue = System.Net.Dns.GetHostName();
            txtSellsBy.EditValue = Settings.Default.UserName;
            txtEntryDate.EditValue = DateTime.Now;
        }
        public void LoadProduct()
        {
            gridControl1.DataSource = productNameRepository.GetAllProductWithStock();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.Action == System.ComponentModel.CollectionChangeAction.Add)
            {
                int requiredQty = Convert.ToInt32(gridView1.GetRowCellValue(e.ControllerRow, QtyBalance));
                int damageQty = Convert.ToInt32(gridView1.GetRowCellValue(e.ControllerRow, Qty));
                int requestQty = 0;
                if ((requiredQty - damageQty) > 0)
                    requestQty = (requiredQty - damageQty);
                gridView1.SetRowCellValue(e.ControllerRow, Qty, requestQty);
            }
            else
                gridView1.SetRowCellValue(e.ControllerRow, Qty, 0);
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridView1.FocusedColumn.FieldName == "Qty")
            {
                if (!decimal.TryParse(e.Value as string, out decimal values))
                {
                    e.Valid = false;
                    e.ErrorText = "Only number values are accepted.";
                }
                else if (Convert.ToDecimal(e.Value) > Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Qty")))
                {
                    e.Valid = false;
                    e.ErrorText = "damage qty should be less than available qty";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEntryDate.EditValue==null)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Please fill up entry date", "System Message", new[] { DialogResult.OK },
                          FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationBlue()));
                return;
            }
            int[] selectedRowHandles = gridView1.GetSelectedRows();
            foreach (int items in selectedRowHandles)
            {
                if (!gridView1.IsGroupRow(items))
                {
                    damageLists.Add(new DamageList()
                    {
                        EntryDate = Convert.ToDateTime(txtEntryDate.EditValue),
                        SalesMonth = Convert.ToDateTime(txtEntryDate.EditValue).ToString("yyyyMM"),
                        ProductCode = gridView1.GetRowCellValue(items, ProductCode).ToString(),
                        Qty = Convert.ToInt32(gridView1.GetRowCellValue(items, Qty)),
                        PurchasePrice= Convert.ToInt32(gridView1.GetRowCellValue(items, PurchasePrice)),
                        SellingPrice = Convert.ToInt32(gridView1.GetRowCellValue(items, SellingPrice)),
                        SalesAmount = Convert.ToInt32(gridView1.GetRowCellValue(items, Qty)) * Convert.ToInt32(gridView1.GetRowCellValue(items, SellingPrice)),
                        TotalAmount= Convert.ToInt32(gridView1.GetRowCellValue(items, Qty)) * Convert.ToInt32(gridView1.GetRowCellValue(items, PurchasePrice)),
                        SellsBy = txtSellsBy.EditValue.ToString(),
                        PcName = System.Net.Dns.GetHostName()
                    }); ;
                }
            }
            if (damageLists.Any())
            {
                damageRepo.ExecuteDamageEntry(damageLists);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Damage Entry Sucessfully", "System Message", new[] { DialogResult.OK },
                           FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationBlue()));
                gridControl1.DataSource = productNameRepository.GetAllProductWithStock();
            }
            else
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No item selected for damage entry", "System Message", new[] { DialogResult.OK },
                            FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
        }
    }
}
