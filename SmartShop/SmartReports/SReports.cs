using System.Collections.Generic;
using SmartShop.Reports.ReportsRepositories;
using SmartShop.SmartReports.ReportsRepositories;

namespace SmartShop.SmartReports
{
    public sealed class SReports
    {
        public static readonly IReports _reports = new ReportsRepository();

        public static IEnumerable<Models.Reports> GetReports()
        {
            return _reports.Get();
        }

        private static Models.Reports GetReport(string reportName)
        {
            return _reports.GetBy(reportName);
        }
        public static Models.Reports GetReports(string reportName, string defaultValue)
        {
            return _reports.GetBy(reportName, defaultValue);
        }

        public static bool HasHeader(string reportName, string defaultValue)
        {
            return _reports.HasHeader(reportName, defaultValue);
        }
        public static bool HasFooter(string reportName, string defaultValue)
        {
            return _reports.HasFooter(reportName, defaultValue);
        }
        public static bool IsActivated(string reportName, string defaultValue)
        {
            return _reports.IsActivated(reportName, defaultValue);
        }
    }

}
