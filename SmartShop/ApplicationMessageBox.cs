using System;
using System.Linq;

namespace SmartShop
{
    public sealed class ApplicationMessageBox
    {
        public static string SuccessfullySaved()
        {
            return $@"Data successfully saved.";
        }
        public static string NoData()
        {
            return $@"No data to display.";
        }
        public static string SuccessfullyUpdated()
        {
            return $@"Data successfully updated.";
        }
    }
}
