namespace SmartShop.Models
{
   public class Reports
    {
        public string RptCode { get; set; }
        public string ReportIdentity { get; set; }
        public Command.ReportModule ReportModule { get; set; }
        public Command.ReportType ReportType { get; set; }
        public Command.SettingValue SettingValue { get; set; }
        public string ReportDisplayName { get; set; }
        public string ReportName { get; set; }
        public bool HasHeader { get; set; }
        public bool HasFooter { get; set; }
        public bool IsActivated { get; set; }
    }
}
