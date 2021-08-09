using Dapper;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SmartShop.SmartReports.ReportsRepositories
{
    public class RegisterRepository : Register
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());

        public IEnumerable<ArrearCollection> GetAllDueCollectionByDate(string SellsDateF, string SellsDateT)
        {
            _connection.Open();
            IEnumerable<ArrearCollection> returnValue =
                _connection.Query<ArrearCollection, CustomerInformation, ArrearCollection>($@"select 
                    vw.CustId,
                    vw.PayAmount,
                    vw.LastDueAmount,
                    vw.CreateBy,
                    ci.CustomerName,
                    ci.CustomerPermanentAddress,
                    ci.ContactNo
                    from  ArrearCollection_vw vw inner join CustomerInformation as ci on vw.CustId=ci.CustId  
                    where TransactionDate>='{SellsDateF}'" + $@" and TransactionDate<='{SellsDateT}'", map:
                    (vw, ci) =>
                    {
                        vw.CustomerInformation = ci;
                        return vw;
                    }, splitOn: "CustomerName");

            _connection.Close();
            return returnValue;
        }
        public IEnumerable<SalesRegister> GetAllPurchaseByDate(string SellsDateF, string SellsDateT)
        {
            _connection.Open();
            IEnumerable<SalesRegister> returnValues =
                _connection.Query<SalesRegister>(@" select * from PurchaseRegister_vw s where s.SellsDate>= @SellsDateF and s.SellsDate<= @SellsDateT", new { SellsDateF = SellsDateF, SellsDateT = SellsDateT });
            _connection.Close();
            return returnValues;
        }

        public IEnumerable<SellesChild> GetAllSalesByDate(DateTime SellsDateF, DateTime SellsDateT)
        {
            _connection.Open();
            string sql = $@"SELECT 
                    isnull(sc.TotalAmount,0)-isnull(ret.TotalAmount,0)TotalAmount, 
                    sc.SellingPrice, 
                    sc.VatAmount, 
                    sc.DiscountAmount, 
                    (sc.Qty-isnull(ret.Qty,0))Qty, 
					pn.PurchasePrice * sc.Qty AS PurchaseAmount, 
					case when (sc.Qty-isnull(ret.Qty,0))=0 then 0 else sc.TotalAmount - pn.PurchasePrice * sc.Qty end as BenfitAmount,
                    --sc.TotalAmount - pn.PurchasePrice * sc.Qty AS BenfitAmount, 
                    isnull(ret.Qty,0) as ReturnQty,
                    isnull(ret.TotalAmount,0) as ReturnAmt,
                    CONCAT(pn.ProductCode,', ', pn.ProductName) As ProductName, 
                    sp.DueAmount, 
                    CAST(sp.SellsDate AS date) AS SellsDate
                    FROM     dbo.SellesChild AS sc 
                    left join SalesReturn as ret on sc.ProductCode=ret.ProductCode and sc.SellsInvoice=ret.SellsInvoice
                    INNER JOIN dbo.ProductName AS pn ON sc.ProductCode = pn.ProductCode 
                    INNER JOIN dbo.SellsParent AS sp ON sc.SellsInvoice = sp.SellsInvoice 
                   where cast(sp.SellsDate as date)>=cast( '{SellsDateF}' as date)" + $@" and cast(sp.SellsDate as date)<=cast( '{SellsDateT}' as date)";

            IEnumerable<SellesChild> returnValue =_connection.Query<SellesChild, SalesReturn, Products, SellsParent, SellesChild>(sql, map:
                    (sc, ret, pn, sp) =>
                    {
                        sc.SalesReturn=ret;
                        sc.Products = pn;
                        sc.SellsParent = sp;
                        return sc;
                    }, splitOn: "ReturnQty,ProductName,DueAmount");

            _connection.Close();
            return returnValue;
        }
        public IEnumerable<CustomerArrear> GetAllCustomerArrear()
        {
            _connection.Open();
            IEnumerable<CustomerArrear> returnValue = _connection.Query<CustomerArrear >($@"select * from  CustomerAllDue_vw vw");
            _connection.Close();
            return returnValue;
        }
        public IEnumerable<ExpensesEntry> GetAllExpensesByDate(string SellsDateF, string SellsDateT)
        {
            _connection.Open();
            IEnumerable<ExpensesEntry> returnValue = _connection.Query<Models.ExpensesEntry, ExpensesList, ExpensesEntry>($@"select 
                    en.EntryDate, 
                    en.SalesMonth, 
                    en.ExpenseAmount, 
                    en.Remarks,
                    en.CreateBy,
                    en.CreateDateTime,
                    el.ExpnsName
               from ExpensesEntry as en
               inner join ExpensesList as el on en.ExpnsId = el.ExpnsId
               where EntryDate >= '{SellsDateF}'" + $@" and EntryDate<= '{SellsDateT}'", map:
               (en, el) =>
               {
                   en.ExpensesList = el;
                   return en;
               }, splitOn: "ExpnsName");
            _connection.Close();
            return returnValue;
        }
    }
}
