using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.ISalesReturn;

namespace SmartShop.Repository
{
    public class SalesReturnRepository : IDisposable, IReturn<SalesReturn>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            _connection.Close();
        }
        public void ExecuteSalesReturnEntry(SalesReturn obj)
        {
            _connection.Open();
            _connection.Execute("SalesReturn_sp", new
            {
                @SellsDate = obj.SellsDate,
                @SalesMonth = obj.SalesMonth,
                @SellsInvoice = obj.SellsInvoice,
                @ProductCode = obj.ProductCode,
                @Qty = obj.Qty,
                @SellingPrice = obj.SellingPrice,
                @SalesAmount=obj.SalesAmount,
                @TotalAmount = obj.TotalAmount,
                @SellsBy = obj.SellsBy,
                @PcName = System.Environment.MachineName,
                @StatementType = "Create"

            }, commandType: CommandType.StoredProcedure);

            _connection.Close();
        }

        public IEnumerable<SalesReturn> GetAllInvoice()
        {
            throw new NotImplementedException();
        }
        public void InsertSalesReturn(List<SalesReturn> obj2)
        {
            foreach (var items in obj2)
            {
                ExecuteSalesReturnEntry(items);
            }
        }

        public IEnumerable<SalesReturn> GetByInvoice(string SellsInvoice)
        {
            _connection.Open();
            IEnumerable<SalesReturn> returnValue = _connection.Query<Models.SalesReturn>($@"select 
                           sc.SellsDate,
                           sc.SellsInvoice,
	                       sc.SellsBy, 
	                       sc.ProductCode,
                           sc.TotalAmount,
	                       sc.Qty,
	                       sc.ProductName,
	                       sc.SellingPrice,
                            VatAmount,
                            DiscountAmount
                    from SalesReturn_vw as sc
               where sc.SellsInvoice= '{SellsInvoice}'");
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<SalesReturn> GetByReturnInvoice(string SellsInvoice)
        {
            _connection.Open();
            IEnumerable<SalesReturn> returnValue = _connection.Query<Models.SalesReturn>($@"select *
                  From SalesReturn
               where SellsInvoice= '{SellsInvoice}'");
            _connection.Close();
            return returnValue;
        }
    }
}
