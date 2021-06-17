
namespace SmartShop.Desktop_Forms_Control
{
    partial class frmResItemOrder
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
            this.galleryControl2 = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient2 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.galleryControl1 = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl2)).BeginInit();
            this.galleryControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl1)).BeginInit();
            this.galleryControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // galleryControl2
            // 
            this.galleryControl2.Controls.Add(this.galleryControlClient2);
            this.galleryControl2.Location = new System.Drawing.Point(-2, 268);
            this.galleryControl2.Name = "galleryControl2";
            this.galleryControl2.Size = new System.Drawing.Size(120, 95);
            this.galleryControl2.TabIndex = 0;
            this.galleryControl2.Text = "galleryControl2";
            // 
            // galleryControlClient2
            // 
            this.galleryControlClient2.GalleryControl = this.galleryControl2;
            this.galleryControlClient2.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient2.Size = new System.Drawing.Size(95, 91);
            // 
            // galleryControl1
            // 
            this.galleryControl1.Controls.Add(this.galleryControlClient1);
            this.galleryControl1.Location = new System.Drawing.Point(180, 5);
            this.galleryControl1.Name = "galleryControl1";
            this.galleryControl1.Size = new System.Drawing.Size(1534, 737);
            this.galleryControl1.TabIndex = 0;
            this.galleryControl1.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.galleryControl1;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(1509, 733);
            // 
            // groupControl1
            // 
            this.groupControl1.Location = new System.Drawing.Point(0, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(174, 737);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "groupControl1";
            // 
            // frmResItemOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1714, 747);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.galleryControl1);
            this.Name = "frmResItemOrder";
            this.Text = "Item Order";
            this.Load += new System.EventHandler(this.frmResItemOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl2)).EndInit();
            this.galleryControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl1)).EndInit();
            this.galleryControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControl2;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient2;
        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControl1;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}