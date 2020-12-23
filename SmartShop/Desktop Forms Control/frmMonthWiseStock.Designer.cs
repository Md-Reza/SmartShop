namespace SmartShop.Desktop_Forms_Control
{
    partial class frmMonthWiseStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonthWiseStock));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SalesMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CompanyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PurchaseQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PurchaseAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PurchaseVatAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PurchaseDiscAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SalesQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SalesAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SalesVatAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProfitAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SalesDiscAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpensesAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ArrearAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ArrearCollAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SalaryAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.txtMonth = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnProcess = new DevExpress.XtraBars.BarButtonItem();
            this.btnView = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.standaloneBarDockControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1758, 620);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 45);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1734, 563);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SalesMonth,
            this.CategoryId,
            this.CompanyId,
            this.ProductCode,
            this.ProductName,
            this.PurchaseQty,
            this.PurchaseAmount,
            this.PurchaseVatAmount,
            this.PurchaseDiscAmt,
            this.SalesQty,
            this.SalesAmount,
            this.SalesVatAmount,
            this.ProfitAmount,
            this.SalesDiscAmt,
            this.ExpensesAmount,
            this.ArrearAmount,
            this.ArrearCollAmt,
            this.SalaryAmount});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // SalesMonth
            // 
            this.SalesMonth.Caption = "Month";
            this.SalesMonth.FieldName = "SalesMonth";
            this.SalesMonth.MinWidth = 25;
            this.SalesMonth.Name = "SalesMonth";
            this.SalesMonth.Visible = true;
            this.SalesMonth.VisibleIndex = 0;
            this.SalesMonth.Width = 95;
            // 
            // CategoryId
            // 
            this.CategoryId.Caption = "Category";
            this.CategoryId.FieldName = "CategoriesSetup.CategoryName";
            this.CategoryId.MinWidth = 25;
            this.CategoryId.Name = "CategoryId";
            this.CategoryId.Visible = true;
            this.CategoryId.VisibleIndex = 1;
            this.CategoryId.Width = 153;
            // 
            // CompanyId
            // 
            this.CompanyId.Caption = "Supplyer";
            this.CompanyId.FieldName = "SupplyerInformation.SupplyerName";
            this.CompanyId.MinWidth = 25;
            this.CompanyId.Name = "CompanyId";
            this.CompanyId.Visible = true;
            this.CompanyId.VisibleIndex = 2;
            this.CompanyId.Width = 178;
            // 
            // ProductCode
            // 
            this.ProductCode.Caption = "Code";
            this.ProductCode.FieldName = "ProductCode";
            this.ProductCode.MinWidth = 25;
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Visible = true;
            this.ProductCode.VisibleIndex = 3;
            this.ProductCode.Width = 85;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "Name";
            this.ProductName.FieldName = "ProductName";
            this.ProductName.MinWidth = 25;
            this.ProductName.Name = "ProductName";
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 4;
            this.ProductName.Width = 198;
            // 
            // PurchaseQty
            // 
            this.PurchaseQty.Caption = "Pur.Qty";
            this.PurchaseQty.FieldName = "PurchaseQty";
            this.PurchaseQty.MinWidth = 25;
            this.PurchaseQty.Name = "PurchaseQty";
            this.PurchaseQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PurchaseQty", "{0:0.##}")});
            this.PurchaseQty.Visible = true;
            this.PurchaseQty.VisibleIndex = 5;
            this.PurchaseQty.Width = 71;
            // 
            // PurchaseAmount
            // 
            this.PurchaseAmount.Caption = "Pur. Amount";
            this.PurchaseAmount.FieldName = "PurchaseAmount";
            this.PurchaseAmount.MinWidth = 25;
            this.PurchaseAmount.Name = "PurchaseAmount";
            this.PurchaseAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PurchaseAmount", "{0:0.##}")});
            this.PurchaseAmount.Visible = true;
            this.PurchaseAmount.VisibleIndex = 6;
            this.PurchaseAmount.Width = 108;
            // 
            // PurchaseVatAmount
            // 
            this.PurchaseVatAmount.Caption = "Pur. Vat";
            this.PurchaseVatAmount.FieldName = "PurchaseVatAmount";
            this.PurchaseVatAmount.MinWidth = 25;
            this.PurchaseVatAmount.Name = "PurchaseVatAmount";
            this.PurchaseVatAmount.Visible = true;
            this.PurchaseVatAmount.VisibleIndex = 7;
            this.PurchaseVatAmount.Width = 68;
            // 
            // PurchaseDiscAmt
            // 
            this.PurchaseDiscAmt.Caption = "Pur. Disc";
            this.PurchaseDiscAmt.FieldName = "PurchaseDiscAmt";
            this.PurchaseDiscAmt.MinWidth = 25;
            this.PurchaseDiscAmt.Name = "PurchaseDiscAmt";
            this.PurchaseDiscAmt.Visible = true;
            this.PurchaseDiscAmt.VisibleIndex = 8;
            this.PurchaseDiscAmt.Width = 61;
            // 
            // SalesQty
            // 
            this.SalesQty.Caption = "Sls Qty";
            this.SalesQty.FieldName = "SalesQty";
            this.SalesQty.MinWidth = 25;
            this.SalesQty.Name = "SalesQty";
            this.SalesQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SalesQty", "{0:0.##}")});
            this.SalesQty.Visible = true;
            this.SalesQty.VisibleIndex = 9;
            this.SalesQty.Width = 68;
            // 
            // SalesAmount
            // 
            this.SalesAmount.Caption = "Sales Amt";
            this.SalesAmount.FieldName = "SalesAmount";
            this.SalesAmount.MinWidth = 25;
            this.SalesAmount.Name = "SalesAmount";
            this.SalesAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SalesAmount", "{0:0.##}")});
            this.SalesAmount.Visible = true;
            this.SalesAmount.VisibleIndex = 10;
            this.SalesAmount.Width = 81;
            // 
            // SalesVatAmount
            // 
            this.SalesVatAmount.Caption = "Sales Vat";
            this.SalesVatAmount.FieldName = "SalesVatAmount";
            this.SalesVatAmount.MinWidth = 25;
            this.SalesVatAmount.Name = "SalesVatAmount";
            this.SalesVatAmount.Visible = true;
            this.SalesVatAmount.VisibleIndex = 11;
            this.SalesVatAmount.Width = 62;
            // 
            // ProfitAmount
            // 
            this.ProfitAmount.Caption = "Profit Amt";
            this.ProfitAmount.FieldName = "ProfitAmount";
            this.ProfitAmount.MinWidth = 25;
            this.ProfitAmount.Name = "ProfitAmount";
            this.ProfitAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ProfitAmount", "{0:0.##}")});
            this.ProfitAmount.Visible = true;
            this.ProfitAmount.VisibleIndex = 12;
            this.ProfitAmount.Width = 68;
            // 
            // SalesDiscAmt
            // 
            this.SalesDiscAmt.Caption = "Sals Disc.";
            this.SalesDiscAmt.FieldName = "SalesDiscAmt";
            this.SalesDiscAmt.MinWidth = 25;
            this.SalesDiscAmt.Name = "SalesDiscAmt";
            this.SalesDiscAmt.Visible = true;
            this.SalesDiscAmt.VisibleIndex = 13;
            this.SalesDiscAmt.Width = 87;
            // 
            // ExpensesAmount
            // 
            this.ExpensesAmount.Caption = "Expenses Amt.";
            this.ExpensesAmount.FieldName = "ExpensesAmount";
            this.ExpensesAmount.MinWidth = 25;
            this.ExpensesAmount.Name = "ExpensesAmount";
            this.ExpensesAmount.Visible = true;
            this.ExpensesAmount.VisibleIndex = 14;
            this.ExpensesAmount.Width = 101;
            // 
            // ArrearAmount
            // 
            this.ArrearAmount.Caption = "Arrear Amt";
            this.ArrearAmount.FieldName = "ArrearAmount";
            this.ArrearAmount.MinWidth = 25;
            this.ArrearAmount.Name = "ArrearAmount";
            this.ArrearAmount.Visible = true;
            this.ArrearAmount.VisibleIndex = 15;
            this.ArrearAmount.Width = 78;
            // 
            // ArrearCollAmt
            // 
            this.ArrearCollAmt.Caption = "Coll Amt.";
            this.ArrearCollAmt.FieldName = "ArrearCollAmt";
            this.ArrearCollAmt.MinWidth = 25;
            this.ArrearCollAmt.Name = "ArrearCollAmt";
            this.ArrearCollAmt.Visible = true;
            this.ArrearCollAmt.VisibleIndex = 16;
            this.ArrearCollAmt.Width = 69;
            // 
            // SalaryAmount
            // 
            this.SalaryAmount.Caption = "Salary Amt";
            this.SalaryAmount.FieldName = "SalaryAmount";
            this.SalaryAmount.MinWidth = 25;
            this.SalaryAmount.Name = "SalaryAmount";
            this.SalaryAmount.Visible = true;
            this.SalaryAmount.VisibleIndex = 17;
            this.SalaryAmount.Width = 82;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnProcess,
            this.btnPrint,
            this.txtMonth,
            this.btnView});
            this.barManager1.MaxItemId = 4;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.txtMonth),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnProcess),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnView),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Tools";
            // 
            // txtMonth
            // 
            this.txtMonth.Caption = "barEditItem1";
            this.txtMonth.Edit = this.repositoryItemTextEdit1;
            this.txtMonth.Id = 2;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(100, 0);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // btnProcess
            // 
            this.btnProcess.Caption = "Process";
            this.btnProcess.Id = 0;
            this.btnProcess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.ImageOptions.Image")));
            this.btnProcess.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProcess.ImageOptions.LargeImage")));
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnProcess.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProcess_ItemClick);
            // 
            // btnView
            // 
            this.btnView.Caption = "View";
            this.btnView.Id = 3;
            this.btnView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnView.ImageOptions.Image")));
            this.btnView.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnView.ImageOptions.LargeImage")));
            this.btnView.Name = "btnView";
            this.btnView.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnView_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Print";
            this.btnPrint.Id = 1;
            this.btnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.Image")));
            this.btnPrint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.LargeImage")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(12, 12);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(1734, 29);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1758, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 620);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1758, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 620);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1758, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 620);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1758, 620);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.standaloneBarDockControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1738, 33);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 33);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1738, 567);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmMonthWiseStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1758, 620);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmMonthWiseStock";
            this.Text = "Month Wise Stock Listing";
            this.Load += new System.EventHandler(this.frmMonthWiseStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnProcess;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.BarEditItem txtMonth;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn SalesMonth;
        private DevExpress.XtraGrid.Columns.GridColumn CategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn CompanyId;
        private DevExpress.XtraGrid.Columns.GridColumn ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn PurchaseQty;
        private DevExpress.XtraGrid.Columns.GridColumn PurchaseAmount;
        private DevExpress.XtraGrid.Columns.GridColumn PurchaseVatAmount;
        private DevExpress.XtraGrid.Columns.GridColumn PurchaseDiscAmt;
        private DevExpress.XtraGrid.Columns.GridColumn SalesQty;
        private DevExpress.XtraGrid.Columns.GridColumn SalesAmount;
        private DevExpress.XtraGrid.Columns.GridColumn SalesVatAmount;
        private DevExpress.XtraGrid.Columns.GridColumn ProfitAmount;
        private DevExpress.XtraGrid.Columns.GridColumn SalesDiscAmt;
        private DevExpress.XtraGrid.Columns.GridColumn ExpensesAmount;
        private DevExpress.XtraGrid.Columns.GridColumn ArrearAmount;
        private DevExpress.XtraGrid.Columns.GridColumn ArrearCollAmt;
        private DevExpress.XtraGrid.Columns.GridColumn SalaryAmount;
        private DevExpress.XtraBars.BarButtonItem btnView;
    }
}