﻿using DevExpress.Skins;
using DevExpress.UserSkins;
using SmartShop.Desktop_Helper_Form;
using System;
using System.Linq;
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
            Application.Run(new frmNewLogin());
            //Application.Run(new WaitingForm());
            //Application.Run(new frmAutoGeneratePassword());
        }
    }
}
