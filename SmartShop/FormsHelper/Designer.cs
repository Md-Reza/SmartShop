using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.FormsHelper
{
   public sealed class Designer
    {
        public static void InitLayoutGroup(LayoutGroup layoutGroup, string caption)
        {
            layoutGroup.Text = caption;
            layoutGroup.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            layoutGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            layoutGroup.Parent.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            layoutGroup.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
        }
    }
}
