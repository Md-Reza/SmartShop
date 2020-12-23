using SmartShop.Models;
using System.Windows.Forms;
using SmartShop.Properties;

namespace SmartShop
{
    public partial class UcActivation : DevExpress.XtraEditors.XtraUserControl
    {
        public UcActivation(UserLogin userLogin)
        {
            InitializeComponent();
            txtActivation.DataBindings.Add("EditValue", userLogin, "ActiationCode");
            //Settings.Default.ActiationCode = txtActivation.EditValue.ToString();
        }
    }
}
