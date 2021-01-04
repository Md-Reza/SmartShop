using Dapper;
using SmartShop.Models;
using SmartShop.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.MonthSummaryInterface;

namespace SmartShop.Repository
{
    public class MonthSummaryRepository : IDisposable, IMonthSummary<MonthSummary>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            _connection.Close();
        }

        public void ExecuteMonthSummaryEntry(string obj)
        {
            _connection.Open();
            _connection.Execute("monthsummary_sp", new
            {
                @SalesMonth = Settings.Default.SalesMonth
            },
            commandType: CommandType.StoredProcedure);

            _connection.Close();
        }

        public IEnumerable<MonthSummary> GetAllMonthWiseStock()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MonthSummary> GetByMonthWiseStock(string SalesMonth)
        {
            _connection.Open();
            IEnumerable<MonthSummary> returnValue =
                _connection.Query<MonthSummary, CategoriesSetup, SupplyerInformation, MonthSummary>($@"select  SalesMonth ,
                                CategoryId,
                                CompanyId,
                                ProductCode, 
                                ProductName,
                                PurchaseQty,
                                PurchaseAmount,
                                PurchaseVatAmount ,
                                PurchaseDiscAmt ,
                                ReturnQty,
                                DamageQty,
                                ReturnAmt,
                                DamageAmt,
                                SalesQty,
                                SalesAmount ,
                                SalesVatAmount,
                                ProfitAmount,
                                SalesDiscAmt ,
                                ExpensesAmount ,
                                ArrearAmount ,
                                ArrearCollAmt,
                                SalaryAmount ,
                                ct.CategoryName,
                                s.SupplyerName
                     from MonthSummary as m
                     inner join CategoriesTable as ct on m.CategoryId=ct.Id
                     inner join SupplyerTable as s on m.CompanyId=s.id
                     where SalesMonth='{SalesMonth}'", map:
                    (m, ct, s) =>
                    {
                        m.CategoriesSetup = ct;
                        m.SupplyerInformation = s;
                        return m;
                    }, splitOn: "CategoryName,SupplyerName");
            _connection.Close();
            return returnValue;
        }

        public void UpdateMonthSummary(MonthSummary obj)
        {
            throw new NotImplementedException();
        }
    }
}
