﻿using DevExpress.XtraEditors;
using SmartShop.Desktop_Forms_Control;
using SmartShop.Desktop_Helper_Form;
using SmartShop.ReportsForm;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SmartShop
{
    public partial class SShopMainMenue : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public SShopMainMenue()
        {
            InitializeComponent();
        }

        private void SShopMainMenue_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Are you want to really close the system?", "Smart Shop Alert! *?", new[] { DialogResult.Yes, DialogResult.No })) == DialogResult.Yes)
            {
                Dispose();
                Application.Exit();
            }
            else
                e.Cancel = true;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCompanyInformation frmCompany = new frmCompanyInformation();
            frmCompany.ShowDialog();
        }

        private void SShopMainMenue_Load(object sender, EventArgs e)
        {

        }

        private void LoadGlobalForm(string accessibleName, string description, string caption)
        {
            string controlName = Assembly.CreateQualifiedName("SmartFactoryFormLibrary", "SmartFactoryFormLibrary.SmartFactoryHelperFormControl." + description);
            XtraForm allowcatedControl = (XtraForm)Activator.CreateInstance(Type.GetType(controlName));
            allowcatedControl.Text = caption;
            allowcatedControl.AccessibleName = accessibleName;
            allowcatedControl.ShowInTaskbar = false;
            allowcatedControl.StartPosition = FormStartPosition.CenterParent;
            allowcatedControl.FormBorderStyle = FormBorderStyle.FixedSingle;
            allowcatedControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            allowcatedControl.MaximizeBox = false;
            allowcatedControl.MinimizeBox = false;
            allowcatedControl.FormBorderEffect = FormBorderEffect.Shadow;
            allowcatedControl.ShowDialog();
        }

        private void ribbonControl1_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Link.Item.AccessibleName) && e.Link.Item.AccessibleName != null)
            {
                //string objectPermission = await ApiControlHelper.CheckObjectPermission(UserSetting.Default.UserName, e.Link.Item.AccessibleName, Command.DbCommand.View, UserSetting.Default.Token);

                var httpResponse = ("BusinessObjects/GetObjectFormName/" + e.Link.Item.AccessibleName);
                var httpResponseFormType = ("BusinessObjects/GetObjectFormType/" + e.Link.Item.AccessibleName);

                if (!string.IsNullOrEmpty(e.Link.Item.AccessibleDescription) && e.Link.Item.AccessibleDescription == "Global")
                    LoadGlobalForm(e.Link.Item.AccessibleName, e.Link.Item.Description, e.Link.Item.Caption);
                {

                    //string fromType = JsonConvert.DeserializeObject<string>(httpResponseFormType.Content.ReadAsStringAsync().Result);
                    //string formName = JsonConvert.DeserializeObject<string>(httpResponse.Content.ReadAsStringAsync().Result);
                    //LoadDbLocalForm(e.Link.Item.AccessibleName, e.Link.Item.Caption, fromType, formName);
                }
            }
            else
                return;
        }

        private void supplyer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSupplyerInformations frmSupplyer = new frmSupplyerInformations();
            frmSupplyer.ShowDialog();
        }

        private void barBtnSells_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSales sales = new frmSales();
            sales.ShowDialog();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //SplashScreenManager.ShowDefaultWaitForm();
            frmProductSetup productSetup = new frmProductSetup();
            productSetup.ShowDialog();
            // SplashScreenManager.CloseForm();


        }

        private void btnCategory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCategoriesInformation categoriesInformation = new frmCategoriesInformation();
            categoriesInformation.ShowDialog();
        }

        private void btnPurchases_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPurchases purchases = new frmPurchases();
            purchases.ShowDialog();
        }

        private void btnPurchaseByFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPurchaseEntryByFile purchaseEntryByFile = new frmPurchaseEntryByFile();
            purchaseEntryByFile.ShowDialog();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportsParaForm paraForm = new frmReportsParaForm();
            paraForm.ShowDialog();
        }

        private void btnApproved_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmApprovePurchase approvePurchase = new frmApprovePurchase();
            approvePurchase.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnSels_Click(object sender, EventArgs e)
        {
            frmNewSells frmNewSells = new frmNewSells();
            frmNewSells.ShowDialog();
        }
    }
}
