using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SmartShop.FormsHelper
{
    public sealed class FormsHelperBox
    {/// <summary>
     /// Custom Message Box Show Method
     /// <para>Author: Rezwan</para>
     /// </summary>
     /// <param name="owner"> This form owner </param>
     /// <param name="message">Message to be displayed</param>
     /// <param name="caption">Message caption</param>
     /// <param name="buttons">User accept button</param>
     /// <param name="icon">Message icon</param>
     /// <param name="sound">Message sound</param>
     /// <returns>Custom Message Box</returns>
        public static XtraMessageBoxArgs Show(IWin32Window owner = null, string message = null, string caption = null, DialogResult[] buttons = null, MessageBeepSound sound = MessageBeepSound.None)
        {
            XtraMessageBoxArgs arg = new XtraMessageBoxArgs
            {
                Owner = owner,
                Text = message,
                Caption = caption,
                Buttons = buttons,
                //Icon = icon,
                MessageBeepSound = sound
            };
            return arg;
        }
    }
}
