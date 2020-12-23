using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using static SmartShop.Interface.BusinessInterface;
using static SmartShop.Interface.Interface;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmUserAccessPermission : DevExpress.XtraEditors.XtraForm
    {
        public List<ObjectCommand> objectCommands = new List<ObjectCommand>();
        IBaseRepository<UserLogin> baseRepository = new UserLoginRepository();
        BusinessCommandRepository commandRepository = new BusinessCommandRepository();
        UserLoginRepository userLogin = new UserLoginRepository();
        IBusinessCommand<ObjectCommand> businessCommand = new BusinessCommandRepository();

        public frmUserAccessPermission()
        {
            InitializeComponent();
        }

        private void frmUserAccessPermission_Load(object sender, EventArgs e)
        {
            LoadAllUserName();
            LoadAllObjectForms();
        }

        private void LoadAllUserName()
        {
            cmbUser.Properties.DataSource = userLogin.GetAllUser();
            cmbUser.Properties.DisplayMember = "LoginName";
            cmbUser.Properties.ValueMember = "UserId";
        }
        private void LoadAllObjectForms()
        {
            gridControl1.DataSource = businessCommand.GetAllBusinessCommand().ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DbOperation()
        {
            int[] selectedRowHandles = gridView1.GetSelectedRows();

            foreach (var items in selectedRowHandles)
            {
                objectCommands.Add(new ObjectCommand()
                {
                    BusinessObjectCode = gridView1.GetRowCellValue(items, BusinessObjectCode).ToString(),
                    BusinessObjectName = gridView1.GetRowCellValue(items, BusinessObjectName).ToString(),
                    ObjectFormName = gridView1.GetRowCellValue(items, ObjectFormName).ToString(),
                    UserId = Convert.ToInt32(cmbUser.EditValue),
                    Permisson = Convert.ToBoolean(gridView1.GetRowCellValue(items, Permisson)),
                    CreateBy = Settings.Default.LoginName
                });
            }
            commandRepository.InsertBusinessCommand(objectCommands);
            XtraMessageBox.Show("Save successfully");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbOperation();
            gridControl2.DataSource = null;
            gridControl2.DataSource = businessCommand.GetByBusinessCommand(cmbUser.EditValue.ToString());
        }

        private void cmbUser_EditValueChanged(object sender, EventArgs e)
        {
            gridControl2.DataSource = null;
            gridControl2.DataSource = businessCommand.GetByBusinessCommand(cmbUser.EditValue.ToString());
        }
    }
}