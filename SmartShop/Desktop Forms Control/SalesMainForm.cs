using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.ReportsForm;
using SmartShop.Repository;
using System;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.BusinessInterface;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class SalesMainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        IBusinessCommand<ObjectCommand> businessCommand = new BusinessCommandRepository();
        public object JsonConvert { get; private set; }

        public SalesMainForm()
        {
            InitializeComponent();
            timer.Start();
            userName.Caption = Settings.Default.UserName;
         //  frmDashBoard frmDashBoard = new frmDashBoard();
          // OpenForm(frmDashBoard);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSales frmSales = new frmSales();
            OpenForm(frmSales);
        }

        private void SellsMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Are you want to really close the system?", "Smart Shop Alert! *?", new[] { DialogResult.Yes, DialogResult.No },
                 FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.QuestionRed())) == DialogResult.Yes)
            {
                Dispose();
                Application.Exit();
            }
            else
                e.Cancel = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            digitalTime.Caption = DateTime.Now.ToString("dddd | hh:mm:ss tt | dd-MMM-yyyy");
            digitalTimer.Caption = DateTime.Now.ToString("dddd | hh:mm:ss tt | dd-MMM-yyyy");
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNewSells NewSells = new frmNewSells();
            OpenForm(NewSells);
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPurchases purchases = new frmPurchases();
            OpenForm(purchases);
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPurchaseEntryByFile frmPurchaseEntryByFile = new frmPurchaseEntryByFile();
            OpenForm(frmPurchaseEntryByFile);
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCompanyInformation company = new frmCompanyInformation();
            OpenForm(company);
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSupplyerInformations supplyer = new frmSupplyerInformations();
            OpenForm(supplyer);
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCategoriesInformation categories = new frmCategoriesInformation();
            OpenForm(categories);
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProductSetup product = new frmProductSetup();
            OpenForm(product);
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCustomerInformation information = new frmCustomerInformation();
            OpenForm(information);
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDueCollection dueCollection = new frmDueCollection();
            dueCollection.ShowDialog();
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmViewDateWisePayment viewDateWise = new frmViewDateWisePayment();
            OpenForm(viewDateWise);
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBarcodeCreate barcodeCreate = new frmBarcodeCreate();
            barcodeCreate.ShowDialog();
        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmStockList stockList = new frmStockList();
            OpenForm(stockList);
        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmExpensesList expensesList = new frmExpensesList();
            OpenForm(expensesList);
        }

        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmReportsParaForm paraForm = new frmReportsParaForm();
            paraForm.ShowDialog();
        }
        private void OpenForm(Form form)
        {
            //XtraForm formm = new XtraForm();
            if (IsFormOPen(form)) return;
            form.MdiParent = this;
            form.Show();
        }
        private bool IsFormOPen(Form form)
        {
            bool isActivated = false;
            if (!MdiChildren.Any()) return isActivated;
            foreach (Form item in MdiChildren)
            {
                if (form.Name != item.Name) continue;
                TabbedMdiManager.Pages[item].MdiChild.Activate();
                isActivated = true;
            }
            return isActivated;
        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmExpenseEntryList expensesListEntry = new frmExpenseEntryList();
            OpenForm(expensesListEntry);
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUserRegistration userRegistration = new frmUserRegistration();
            OpenForm(userRegistration);
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            frmPurchaseEntryByFile frmPurchaseEntryByFile = new frmPurchaseEntryByFile();
            OpenForm(frmPurchaseEntryByFile);
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            var Name = "frmNewSells";
            frmNewSells SallesFrom = new frmNewSells();
            var permission = businessCommand.GetByCommandPermissonCheck(Settings.Default.UserName, Name);
            if (permission.Any())
            {
                OpenForm(SallesFrom);
            }
            else
                XtraMessageBox.Show("No access this menue");

        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            frmBarcodeCreate barcodeCreate = new frmBarcodeCreate();
            barcodeCreate.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProductSetup productSetupFrom = new frmProductSetup();
            OpenForm(productSetupFrom);
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            frmExpenseEntryList expenseFrom = new frmExpenseEntryList();
            OpenForm(expenseFrom);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            var Name = "frmStockList";
            frmStockList stockFrom = new frmStockList();
            var permission = businessCommand.GetByCommandPermissonCheck(Settings.Default.UserName, Name);
            if (permission.Any())
            {
                OpenForm(stockFrom);
            }
            else
                XtraMessageBox.Show("No access this menue");
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReportsParaForm reportsFrom = new frmReportsParaForm();
            reportsFrom.ShowDialog();
        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCustomerDues duesFrom = new frmCustomerDues();
            OpenForm(duesFrom);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerDues duesFrom = new frmCustomerDues();
            OpenForm(duesFrom);
        }

        private void btnDatabaseBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBackup backup = new frmBackup();
            backup.ShowDialog();
        }

        private void btnSalesReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSalesReturn salesReturn = new frmSalesReturn();
            salesReturn.ShowDialog();
        }

        private void btnDashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDashBoard frmDashBoard = new frmDashBoard();
            OpenForm(frmDashBoard);
        }

        private void btnUserAccess_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUserAccessPermission permission = new frmUserAccessPermission();
            OpenForm(permission);
        }

        private void btnBank_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBank frmBank = new frmBank();
            OpenForm(frmBank);
        }

        private void btnBankTransaction_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBankTransaction frmBankt = new frmBankTransaction();
            OpenForm(frmBankt);
        }

        private void btnMonthStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Name = "frmMonthWiseStock";
            frmMonthWiseStock monthStockFrom = new frmMonthWiseStock();
            var permission = businessCommand.GetByCommandPermissonCheck(Settings.Default.UserName, Name);
            if (permission.Any())
            {
                OpenForm(monthStockFrom);
            }
            else
                XtraMessageBox.Show("No access this menue");
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAutoGeneratePassword password = new frmAutoGeneratePassword();
            password.ShowDialog();
        }

        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDamageListEntry damageListEntry = new frmDamageListEntry();
            damageListEntry.ShowDialog();
        }

        private void btnItemOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmResOrderItem frmResOrderItem = new frmResOrderItem();
            OpenForm(frmResOrderItem);
        }
    }
}