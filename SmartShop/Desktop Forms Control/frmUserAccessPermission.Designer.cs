namespace SmartShop.Desktop_Forms_Control
{
    partial class frmUserAccessPermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserAccessPermission));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.OCommandId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gBusinessObjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gBusinessObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gObjectFormName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LoginName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gPermisson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BusinessObjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ObjectFormName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BusinessObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Permisson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbUser = new DevExpress.XtraEditors.LookUpEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl2);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.cmbUser);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnNew);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1563, 651);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(775, 49);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(764, 578);
            this.gridControl2.TabIndex = 10;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.OCommandId,
            this.gBusinessObjectCode,
            this.gBusinessObjectName,
            this.gObjectFormName,
            this.LoginName,
            this.gPermisson,
            this.CreateBy,
            this.CreateDate});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            // 
            // OCommandId
            // 
            this.OCommandId.Caption = "OCommand Id";
            this.OCommandId.FieldName = "OCommandId";
            this.OCommandId.MinWidth = 25;
            this.OCommandId.Name = "OCommandId";
            this.OCommandId.Visible = true;
            this.OCommandId.VisibleIndex = 0;
            this.OCommandId.Width = 94;
            // 
            // gBusinessObjectCode
            // 
            this.gBusinessObjectCode.Caption = "Object Code";
            this.gBusinessObjectCode.FieldName = "BusinessObjectCode";
            this.gBusinessObjectCode.MinWidth = 25;
            this.gBusinessObjectCode.Name = "gBusinessObjectCode";
            this.gBusinessObjectCode.Visible = true;
            this.gBusinessObjectCode.VisibleIndex = 1;
            this.gBusinessObjectCode.Width = 94;
            // 
            // gBusinessObjectName
            // 
            this.gBusinessObjectName.Caption = "Object Name";
            this.gBusinessObjectName.FieldName = "BusinessObjectName";
            this.gBusinessObjectName.MinWidth = 25;
            this.gBusinessObjectName.Name = "gBusinessObjectName";
            this.gBusinessObjectName.Visible = true;
            this.gBusinessObjectName.VisibleIndex = 2;
            this.gBusinessObjectName.Width = 94;
            // 
            // gObjectFormName
            // 
            this.gObjectFormName.Caption = "Form Name";
            this.gObjectFormName.FieldName = "ObjectFormName";
            this.gObjectFormName.MinWidth = 25;
            this.gObjectFormName.Name = "gObjectFormName";
            this.gObjectFormName.Visible = true;
            this.gObjectFormName.VisibleIndex = 3;
            this.gObjectFormName.Width = 94;
            // 
            // LoginName
            // 
            this.LoginName.Caption = "Login Name";
            this.LoginName.FieldName = "LoginName";
            this.LoginName.MinWidth = 25;
            this.LoginName.Name = "LoginName";
            this.LoginName.Visible = true;
            this.LoginName.VisibleIndex = 4;
            this.LoginName.Width = 94;
            // 
            // gPermisson
            // 
            this.gPermisson.Caption = "Permisson";
            this.gPermisson.FieldName = "Permisson";
            this.gPermisson.MinWidth = 25;
            this.gPermisson.Name = "gPermisson";
            this.gPermisson.Visible = true;
            this.gPermisson.VisibleIndex = 5;
            this.gPermisson.Width = 94;
            // 
            // CreateBy
            // 
            this.CreateBy.Caption = "Create By";
            this.CreateBy.FieldName = "CreateBy";
            this.CreateBy.MinWidth = 25;
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.Visible = true;
            this.CreateBy.VisibleIndex = 6;
            this.CreateBy.Width = 94;
            // 
            // CreateDate
            // 
            this.CreateDate.Caption = "CreateDate";
            this.CreateDate.FieldName = "CreateDate";
            this.CreateDate.MinWidth = 25;
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Visible = true;
            this.CreateDate.VisibleIndex = 7;
            this.CreateDate.Width = 94;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 88);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(747, 520);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BusinessObjectCode,
            this.ObjectFormName,
            this.BusinessObjectName,
            this.Permisson});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // BusinessObjectCode
            // 
            this.BusinessObjectCode.Caption = "Object Code";
            this.BusinessObjectCode.FieldName = "BusinessObjectCode";
            this.BusinessObjectCode.MinWidth = 25;
            this.BusinessObjectCode.Name = "BusinessObjectCode";
            this.BusinessObjectCode.Visible = true;
            this.BusinessObjectCode.VisibleIndex = 1;
            this.BusinessObjectCode.Width = 94;
            // 
            // ObjectFormName
            // 
            this.ObjectFormName.Caption = "Form Name";
            this.ObjectFormName.FieldName = "ObjectFormName";
            this.ObjectFormName.MinWidth = 25;
            this.ObjectFormName.Name = "ObjectFormName";
            this.ObjectFormName.OptionsColumn.AllowEdit = false;
            this.ObjectFormName.OptionsColumn.ReadOnly = true;
            this.ObjectFormName.Visible = true;
            this.ObjectFormName.VisibleIndex = 2;
            this.ObjectFormName.Width = 200;
            // 
            // BusinessObjectName
            // 
            this.BusinessObjectName.Caption = "Form Description";
            this.BusinessObjectName.FieldName = "BusinessObjectName";
            this.BusinessObjectName.MinWidth = 25;
            this.BusinessObjectName.Name = "BusinessObjectName";
            this.BusinessObjectName.OptionsColumn.AllowEdit = false;
            this.BusinessObjectName.OptionsColumn.ReadOnly = true;
            this.BusinessObjectName.Visible = true;
            this.BusinessObjectName.VisibleIndex = 3;
            this.BusinessObjectName.Width = 284;
            // 
            // Permisson
            // 
            this.Permisson.Caption = "Permisson";
            this.Permisson.FieldName = "Permisson";
            this.Permisson.MinWidth = 25;
            this.Permisson.Name = "Permisson";
            this.Permisson.Visible = true;
            this.Permisson.VisibleIndex = 4;
            this.Permisson.Width = 117;
            // 
            // cmbUser
            // 
            this.cmbUser.Location = new System.Drawing.Point(90, 49);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUser.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserId", "UserId", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoginName", "LoginName")});
            this.cmbUser.Properties.NullText = "";
            this.cmbUser.Size = new System.Drawing.Size(657, 23);
            this.cmbUser.StyleController = this.layoutControl1;
            this.cmbUser.TabIndex = 5;
            this.cmbUser.EditValueChanged += new System.EventHandler(this.cmbUser_EditValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(700, 612);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 27);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(621, 612);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Approve";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.Location = new System.Drawing.Point(12, 612);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(76, 27);
            this.btnNew.StyleController = this.layoutControl1;
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1563, 651);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(751, 524);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnClose;
            this.layoutControlItem1.Location = new System.Drawing.Point(688, 600);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(63, 31);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnSave;
            this.layoutControlItem4.Location = new System.Drawing.Point(609, 600);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(79, 31);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnNew;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 600);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(80, 31);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(80, 600);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(529, 31);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(751, 76);
            this.layoutControlGroup2.Text = "Access Allocation";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmbUser;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(727, 27);
            this.layoutControlItem2.Text = "User Name";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(63, 16);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6});
            this.layoutControlGroup3.Location = new System.Drawing.Point(751, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(792, 631);
            this.layoutControlGroup3.Text = "View Access Allocation";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.gridControl2;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(768, 582);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // frmUserAccessPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1563, 651);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserAccessPermission";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Access Permission";
            this.Load += new System.EventHandler(this.frmUserAccessPermission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit cmbUser;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn ObjectFormName;
        private DevExpress.XtraGrid.Columns.GridColumn BusinessObjectName;
        private DevExpress.XtraGrid.Columns.GridColumn Permisson;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn BusinessObjectCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn OCommandId;
        private DevExpress.XtraGrid.Columns.GridColumn gBusinessObjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn gBusinessObjectName;
        private DevExpress.XtraGrid.Columns.GridColumn gObjectFormName;
        private DevExpress.XtraGrid.Columns.GridColumn LoginName;
        private DevExpress.XtraGrid.Columns.GridColumn gPermisson;
        private DevExpress.XtraGrid.Columns.GridColumn CreateBy;
        private DevExpress.XtraGrid.Columns.GridColumn CreateDate;
    }
}