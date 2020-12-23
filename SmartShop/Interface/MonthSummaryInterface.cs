using SmartShop.Models;
using System.Collections.Generic;

namespace SmartShop.Interface
{
    public sealed class MonthSummaryInterface
    {
        public interface IMonthSummary<T> where T : class
        {
            IEnumerable<MonthSummary> GetAllMonthWiseStock();
            IEnumerable<MonthSummary> GetByMonthWiseStock(string SalesMonth);
            void ExecuteMonthSummaryEntry(string obj);
            void UpdateMonthSummary(T obj);
        }
    }
}
