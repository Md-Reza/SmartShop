
namespace SmartShop.Desktop_Helper_Form
{
    partial class frmGridStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGridStock));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SupplyerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PurchaseQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SalesQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DamageQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReturnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QtyBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BalanceQtyWithReturn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PurchasesAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SalesAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReturnAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DamageAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SalesAmountWithReturn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BrandName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SizeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColourName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.SaveFileDialog = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1369, 676);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1369, 676);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(24, 51);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1321, 601);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProductCode,
            this.ProductName,
            this.SupplyerName,
            this.CategoryName,
            this.PurchaseQty,
            this.SalesQty,
            this.DamageQty,
            this.ReturnQty,
            this.QtyBalance,
            this.BalanceQtyWithReturn,
            this.PurchasesAmount,
            this.SalesAmount,
            this.ReturnAmt,
            this.DamageAmt,
            this.SalesAmountWithReturn,
            this.BrandName,
            this.SizeName,
            this.ColourName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // ProductCode
            // 
            this.ProductCode.Caption = "Code";
            this.ProductCode.FieldName = "ProductCode";
            this.ProductCode.MinWidth = 25;
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Visible = true;
            this.ProductCode.VisibleIndex = 0;
            this.ProductCode.Width = 94;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "Name";
            this.ProductName.FieldName = "ProductName";
            this.ProductName.MinWidth = 25;
            this.ProductName.Name = "ProductName";
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 1;
            this.ProductName.Width = 94;
            // 
            // SupplyerName
            // 
            this.SupplyerName.Caption = "Supplyer Name";
            this.SupplyerName.FieldName = "SupplyerInformation.SupplyerName";
            this.SupplyerName.MinWidth = 25;
            this.SupplyerName.Name = "SupplyerName";
            this.SupplyerName.Visible = true;
            this.SupplyerName.VisibleIndex = 2;
            this.SupplyerName.Width = 94;
            // 
            // CategoryName
            // 
            this.CategoryName.Caption = "Category Name";
            this.CategoryName.FieldName = "CategoriesSetup.CategoryName";
            this.CategoryName.MinWidth = 25;
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Visible = true;
            this.CategoryName.VisibleIndex = 3;
            this.CategoryName.Width = 94;
            // 
            // PurchaseQty
            // 
            this.PurchaseQty.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PurchaseQty.AppearanceCell.Options.UseBackColor = true;
            this.PurchaseQty.Caption = "Purchase Qty";
            this.PurchaseQty.FieldName = "PurchaseQty";
            this.PurchaseQty.MinWidth = 25;
            this.PurchaseQty.Name = "PurchaseQty";
            this.PurchaseQty.Visible = true;
            this.PurchaseQty.VisibleIndex = 4;
            this.PurchaseQty.Width = 94;
            // 
            // SalesQty
            // 
            this.SalesQty.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SalesQty.AppearanceCell.Options.UseBackColor = true;
            this.SalesQty.Caption = "Sales Qty";
            this.SalesQty.FieldName = "SalesQty";
            this.SalesQty.MinWidth = 25;
            this.SalesQty.Name = "SalesQty";
            this.SalesQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SalesQty", "{0:0.##}")});
            this.SalesQty.Visible = true;
            this.SalesQty.VisibleIndex = 5;
            this.SalesQty.Width = 94;
            // 
            // DamageQty
            // 
            this.DamageQty.Caption = "Damage Qty";
            this.DamageQty.FieldName = "DamageQty";
            this.DamageQty.MinWidth = 25;
            this.DamageQty.Name = "DamageQty";
            this.DamageQty.Visible = true;
            this.DamageQty.VisibleIndex = 6;
            this.DamageQty.Width = 94;
            // 
            // ReturnQty
            // 
            this.ReturnQty.Caption = "Return Qty";
            this.ReturnQty.FieldName = "ReturnQty";
            this.ReturnQty.MinWidth = 25;
            this.ReturnQty.Name = "ReturnQty";
            this.ReturnQty.Visible = true;
            this.ReturnQty.VisibleIndex = 7;
            this.ReturnQty.Width = 94;
            // 
            // QtyBalance
            // 
            this.QtyBalance.Caption = "Qty Balance";
            this.QtyBalance.FieldName = "QtyBalance";
            this.QtyBalance.MinWidth = 25;
            this.QtyBalance.Name = "QtyBalance";
            this.QtyBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QtyBalance", "{0:0.##}")});
            this.QtyBalance.Visible = true;
            this.QtyBalance.VisibleIndex = 8;
            this.QtyBalance.Width = 94;
            // 
            // BalanceQtyWithReturn
            // 
            this.BalanceQtyWithReturn.Caption = "Balance Qty WithReturn";
            this.BalanceQtyWithReturn.FieldName = "BalanceQtyWithReturn";
            this.BalanceQtyWithReturn.MinWidth = 25;
            this.BalanceQtyWithReturn.Name = "BalanceQtyWithReturn";
            this.BalanceQtyWithReturn.Visible = true;
            this.BalanceQtyWithReturn.VisibleIndex = 9;
            this.BalanceQtyWithReturn.Width = 94;
            // 
            // PurchasesAmount
            // 
            this.PurchasesAmount.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PurchasesAmount.AppearanceCell.Options.UseBackColor = true;
            this.PurchasesAmount.Caption = "Purchase Amount";
            this.PurchasesAmount.FieldName = "PurchasesAmount";
            this.PurchasesAmount.MinWidth = 25;
            this.PurchasesAmount.Name = "PurchasesAmount";
            this.PurchasesAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PurchasesAmount", "{0:0.##}")});
            this.PurchasesAmount.Visible = true;
            this.PurchasesAmount.VisibleIndex = 10;
            this.PurchasesAmount.Width = 94;
            // 
            // SalesAmount
            // 
            this.SalesAmount.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SalesAmount.AppearanceCell.Options.UseBackColor = true;
            this.SalesAmount.Caption = "Sales Amount";
            this.SalesAmount.FieldName = "SalesAmount";
            this.SalesAmount.MinWidth = 25;
            this.SalesAmount.Name = "SalesAmount";
            this.SalesAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SalesAmount", "{0:0.##}")});
            this.SalesAmount.Visible = true;
            this.SalesAmount.VisibleIndex = 11;
            this.SalesAmount.Width = 94;
            // 
            // ReturnAmt
            // 
            this.ReturnAmt.Caption = "Return Amt";
            this.ReturnAmt.FieldName = "ReturnAmt";
            this.ReturnAmt.MinWidth = 25;
            this.ReturnAmt.Name = "ReturnAmt";
            this.ReturnAmt.Visible = true;
            this.ReturnAmt.VisibleIndex = 12;
            this.ReturnAmt.Width = 94;
            // 
            // DamageAmt
            // 
            this.DamageAmt.Caption = "Damage Amt";
            this.DamageAmt.FieldName = "DamageAmt";
            this.DamageAmt.MinWidth = 25;
            this.DamageAmt.Name = "DamageAmt";
            this.DamageAmt.Visible = true;
            this.DamageAmt.VisibleIndex = 13;
            this.DamageAmt.Width = 94;
            // 
            // SalesAmountWithReturn
            // 
            this.SalesAmountWithReturn.Caption = "Final Sells Amt";
            this.SalesAmountWithReturn.FieldName = "SalesAmountWithReturn";
            this.SalesAmountWithReturn.MinWidth = 25;
            this.SalesAmountWithReturn.Name = "SalesAmountWithReturn";
            this.SalesAmountWithReturn.Visible = true;
            this.SalesAmountWithReturn.VisibleIndex = 14;
            this.SalesAmountWithReturn.Width = 94;
            // 
            // BrandName
            // 
            this.BrandName.Caption = "Brand Name";
            this.BrandName.FieldName = "Brand.BrandName";
            this.BrandName.MinWidth = 25;
            this.BrandName.Name = "BrandName";
            this.BrandName.Width = 94;
            // 
            // SizeName
            // 
            this.SizeName.Caption = "Size Name";
            this.SizeName.FieldName = "Size.SizeName";
            this.SizeName.MinWidth = 25;
            this.SizeName.Name = "SizeName";
            this.SizeName.Width = 94;
            // 
            // ColourName
            // 
            this.ColourName.Caption = "Colour Name";
            this.ColourName.FieldName = "Colour.ColourName";
            this.ColourName.MinWidth = 25;
            this.ColourName.Name = "ColourName";
            this.ColourName.Width = 94;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1325, 605);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            buttonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions1.Image")));
            buttonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions2.Image")));
            buttonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions3.Image")));
            this.layoutControlGroup2.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Refresh", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Export", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Close", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1)});
            this.layoutControlGroup2.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1349, 656);
            this.layoutControlGroup2.Text = "Stock List";
            this.layoutControlGroup2.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.layoutControlGroup2_CustomButtonClick);
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.FileName = "SaveFileDialog";
            // 
            // frmGridStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 676);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGridStock";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn SupplyerName;
        private DevExpress.XtraGrid.Columns.GridColumn CategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn PurchaseQty;
        private DevExpress.XtraGrid.Columns.GridColumn SalesQty;
        private DevExpress.XtraGrid.Columns.GridColumn DamageQty;
        private DevExpress.XtraGrid.Columns.GridColumn ReturnQty;
        private DevExpress.XtraGrid.Columns.GridColumn QtyBalance;
        private DevExpress.XtraGrid.Columns.GridColumn BalanceQtyWithReturn;
        private DevExpress.XtraGrid.Columns.GridColumn PurchasesAmount;
        private DevExpress.XtraGrid.Columns.GridColumn SalesAmount;
        private DevExpress.XtraGrid.Columns.GridColumn ReturnAmt;
        private DevExpress.XtraGrid.Columns.GridColumn DamageAmt;
        private DevExpress.XtraGrid.Columns.GridColumn SalesAmountWithReturn;
        private DevExpress.XtraGrid.Columns.GridColumn BrandName;
        private DevExpress.XtraGrid.Columns.GridColumn SizeName;
        private DevExpress.XtraGrid.Columns.GridColumn ColourName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.XtraSaveFileDialog SaveFileDialog;
    }
}