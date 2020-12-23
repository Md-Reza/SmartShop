namespace SmartShop.Desktop_Forms_Control
{
    partial class frmUserRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserRegistration));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AccountCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReportingPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Religeon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PresentAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MobileNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeviceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeviceQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeviceIMEINo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BasicSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MedicalAllonce = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HouseRent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DainingAllonce = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProfilePhoto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
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
            this.layoutControl1.Size = new System.Drawing.Size(1766, 684);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 45);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1742, 627);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AccountCode,
            this.UserName,
            this.UserEmail,
            this.FirstName,
            this.LastName,
            this.FullName,
            this.ReportingPerson,
            this.Religeon,
            this.PresentAddress,
            this.MobileNo,
            this.DeviceName,
            this.DeviceQty,
            this.DeviceIMEINo1,
            this.BasicSalary,
            this.MedicalAllonce,
            this.HouseRent,
            this.DainingAllonce,
            this.ProfilePhoto});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // AccountCode
            // 
            this.AccountCode.Caption = "Account Code";
            this.AccountCode.FieldName = "AccountCode";
            this.AccountCode.MinWidth = 25;
            this.AccountCode.Name = "AccountCode";
            this.AccountCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "AccountCode", "{0}")});
            this.AccountCode.Visible = true;
            this.AccountCode.VisibleIndex = 0;
            this.AccountCode.Width = 94;
            // 
            // UserName
            // 
            this.UserName.Caption = "User Name";
            this.UserName.FieldName = "UserName";
            this.UserName.MinWidth = 25;
            this.UserName.Name = "UserName";
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 1;
            this.UserName.Width = 94;
            // 
            // UserEmail
            // 
            this.UserEmail.Caption = "User Email";
            this.UserEmail.FieldName = "UserEmail";
            this.UserEmail.MinWidth = 25;
            this.UserEmail.Name = "UserEmail";
            this.UserEmail.Visible = true;
            this.UserEmail.VisibleIndex = 2;
            this.UserEmail.Width = 94;
            // 
            // FirstName
            // 
            this.FirstName.Caption = "First Name";
            this.FirstName.FieldName = "FirstName";
            this.FirstName.MinWidth = 25;
            this.FirstName.Name = "FirstName";
            this.FirstName.Visible = true;
            this.FirstName.VisibleIndex = 3;
            this.FirstName.Width = 94;
            // 
            // LastName
            // 
            this.LastName.Caption = "Last Name";
            this.LastName.FieldName = "LastName";
            this.LastName.MinWidth = 25;
            this.LastName.Name = "LastName";
            this.LastName.Visible = true;
            this.LastName.VisibleIndex = 4;
            this.LastName.Width = 94;
            // 
            // FullName
            // 
            this.FullName.Caption = "Full Name";
            this.FullName.FieldName = "FullName";
            this.FullName.MinWidth = 25;
            this.FullName.Name = "FullName";
            this.FullName.Visible = true;
            this.FullName.VisibleIndex = 5;
            this.FullName.Width = 94;
            // 
            // ReportingPerson
            // 
            this.ReportingPerson.Caption = "Reporting Person";
            this.ReportingPerson.FieldName = "ReportingPerson";
            this.ReportingPerson.MinWidth = 25;
            this.ReportingPerson.Name = "ReportingPerson";
            this.ReportingPerson.Visible = true;
            this.ReportingPerson.VisibleIndex = 6;
            this.ReportingPerson.Width = 94;
            // 
            // Religeon
            // 
            this.Religeon.Caption = "Religeon";
            this.Religeon.FieldName = "Religeon";
            this.Religeon.MinWidth = 25;
            this.Religeon.Name = "Religeon";
            this.Religeon.Visible = true;
            this.Religeon.VisibleIndex = 7;
            this.Religeon.Width = 94;
            // 
            // PresentAddress
            // 
            this.PresentAddress.Caption = "Address";
            this.PresentAddress.FieldName = "PresentAddress";
            this.PresentAddress.MinWidth = 25;
            this.PresentAddress.Name = "PresentAddress";
            this.PresentAddress.Visible = true;
            this.PresentAddress.VisibleIndex = 8;
            this.PresentAddress.Width = 94;
            // 
            // MobileNo
            // 
            this.MobileNo.Caption = "Mobile No";
            this.MobileNo.FieldName = "MobileNo";
            this.MobileNo.MinWidth = 25;
            this.MobileNo.Name = "MobileNo";
            this.MobileNo.Visible = true;
            this.MobileNo.VisibleIndex = 9;
            this.MobileNo.Width = 94;
            // 
            // DeviceName
            // 
            this.DeviceName.Caption = "Device Name";
            this.DeviceName.FieldName = "DeviceName";
            this.DeviceName.MinWidth = 25;
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.Visible = true;
            this.DeviceName.VisibleIndex = 10;
            this.DeviceName.Width = 94;
            // 
            // DeviceQty
            // 
            this.DeviceQty.Caption = "Device Qty";
            this.DeviceQty.MinWidth = 25;
            this.DeviceQty.Name = "DeviceQty";
            this.DeviceQty.Visible = true;
            this.DeviceQty.VisibleIndex = 11;
            this.DeviceQty.Width = 94;
            // 
            // DeviceIMEINo1
            // 
            this.DeviceIMEINo1.Caption = "Imei";
            this.DeviceIMEINo1.FieldName = "DeviceIMEINo1";
            this.DeviceIMEINo1.MinWidth = 25;
            this.DeviceIMEINo1.Name = "DeviceIMEINo1";
            this.DeviceIMEINo1.Visible = true;
            this.DeviceIMEINo1.VisibleIndex = 12;
            this.DeviceIMEINo1.Width = 94;
            // 
            // BasicSalary
            // 
            this.BasicSalary.Caption = "Basic Salary";
            this.BasicSalary.FieldName = "BasicSalary";
            this.BasicSalary.MinWidth = 25;
            this.BasicSalary.Name = "BasicSalary";
            this.BasicSalary.Visible = true;
            this.BasicSalary.VisibleIndex = 13;
            this.BasicSalary.Width = 94;
            // 
            // MedicalAllonce
            // 
            this.MedicalAllonce.Caption = "Medical Allonce";
            this.MedicalAllonce.FieldName = "MedicalAllonce";
            this.MedicalAllonce.MinWidth = 25;
            this.MedicalAllonce.Name = "MedicalAllonce";
            this.MedicalAllonce.Visible = true;
            this.MedicalAllonce.VisibleIndex = 14;
            this.MedicalAllonce.Width = 94;
            // 
            // HouseRent
            // 
            this.HouseRent.Caption = "House Rent";
            this.HouseRent.FieldName = "HouseRent";
            this.HouseRent.MinWidth = 25;
            this.HouseRent.Name = "HouseRent";
            this.HouseRent.Visible = true;
            this.HouseRent.VisibleIndex = 15;
            this.HouseRent.Width = 94;
            // 
            // DainingAllonce
            // 
            this.DainingAllonce.Caption = "Daining Allonce";
            this.DainingAllonce.FieldName = "DainingAllonce";
            this.DainingAllonce.MinWidth = 25;
            this.DainingAllonce.Name = "DainingAllonce";
            this.DainingAllonce.Visible = true;
            this.DainingAllonce.VisibleIndex = 16;
            this.DainingAllonce.Width = 94;
            // 
            // ProfilePhoto
            // 
            this.ProfilePhoto.Caption = "Photo";
            this.ProfilePhoto.FieldName = "ProfilePhoto";
            this.ProfilePhoto.MinWidth = 25;
            this.ProfilePhoto.Name = "ProfilePhoto";
            this.ProfilePhoto.Visible = true;
            this.ProfilePhoto.VisibleIndex = 17;
            this.ProfilePhoto.Width = 94;
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
            this.btnNew,
            this.btnEdit,
            this.btnRefresh});
            this.barManager1.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh)});
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Tools";
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Id = 0;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.LargeImage")));
            this.btnNew.Name = "btnNew";
            this.btnNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Id = 1;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.btnEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 2;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.LargeImage")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(12, 12);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(1742, 29);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1766, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 684);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1766, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 684);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1766, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 684);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1766, 684);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.standaloneBarDockControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1746, 33);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 33);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1746, 631);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmUserRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1766, 684);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUserRegistration";
            this.Text = "User Registration";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn AccountCode;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn UserEmail;
        private DevExpress.XtraGrid.Columns.GridColumn FirstName;
        private DevExpress.XtraGrid.Columns.GridColumn LastName;
        private DevExpress.XtraGrid.Columns.GridColumn FullName;
        private DevExpress.XtraGrid.Columns.GridColumn ReportingPerson;
        private DevExpress.XtraGrid.Columns.GridColumn Religeon;
        private DevExpress.XtraGrid.Columns.GridColumn PresentAddress;
        private DevExpress.XtraGrid.Columns.GridColumn MobileNo;
        private DevExpress.XtraGrid.Columns.GridColumn DeviceName;
        private DevExpress.XtraGrid.Columns.GridColumn DeviceQty;
        private DevExpress.XtraGrid.Columns.GridColumn DeviceIMEINo1;
        private DevExpress.XtraGrid.Columns.GridColumn BasicSalary;
        private DevExpress.XtraGrid.Columns.GridColumn MedicalAllonce;
        private DevExpress.XtraGrid.Columns.GridColumn HouseRent;
        private DevExpress.XtraGrid.Columns.GridColumn DainingAllonce;
        private DevExpress.XtraGrid.Columns.GridColumn ProfilePhoto;
    }
}