using DevExpress.XtraEditors;
using SmartShop.Repository;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartShop.FormsHelper
{
    public sealed class FormsHelperMessageBox
    {
        public static XtraMessageBoxArgs Show(IWin32Window owner = null, string message = null, string caption = null, DialogResult[] buttons = null, Icon icon = null, MessageBeepSound sound = MessageBeepSound.None)
        {
            XtraMessageBoxArgs arg = new XtraMessageBoxArgs
            {
                Owner = owner,
                Text = message,
                Caption = caption,
                Buttons = buttons,
                Icon = icon,
                MessageBeepSound = sound
            };
            return arg;
        }
        public class SFMessageBoxIcon
        {
            public static Icon SuccessfullGreen()
            {
                Bitmap bitmap = new Bitmap(Properties.Resources.Successfull_64x64);
                Icon icon = Icon.FromHandle(bitmap.GetHicon());
                return icon;
            }
            public static Icon QuestionRed()
            {
                Bitmap bitmap = new Bitmap(Properties.Resources.Question_Red);
                Icon icon = Icon.FromHandle(bitmap.GetHicon());
                return icon;
            }
          
            public static Icon InformationBlue()
            {
                Bitmap bitmap = new Bitmap(Properties.Resources.Information_Blue);
                Icon icon = Icon.FromHandle(bitmap.GetHicon());
                return icon;
            }
            public static Icon InformationRed()
            {
                Bitmap bitmap = new Bitmap(Properties.Resources.Information_Red);
                Icon icon = Icon.FromHandle(bitmap.GetHicon());
                return icon;
            }
        }

        internal static XtraMessageBoxArgs Show(ComapnySetupRepository comapnySetupRepository, string v1, string v2, DialogResult[] dialogResults, Icon icon)
        {
            throw new NotImplementedException();
        }
    }
}
