using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraSplashScreen;
using SmartShop.Desktop_Forms_Control;
using SmartShop.Desktop_Helper_Form;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SmartShop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            //Application.Run(new SplashScreen1());

            SplashScreenManager.ShowForm(typeof(SplashScreen1), true, true);
            Thread.Sleep(5000);
            SplashScreenManager.CloseForm();
            frmNewLogin frmNewLogin = new frmNewLogin();
            if (frmNewLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new SalesMainForm());
            }
            
            Application.Run(new frmNewLogin());
            //Application.Run(new WaitingForm());
            //Application.Run(new frmAutoGeneratePassword());
        }
    }
}
