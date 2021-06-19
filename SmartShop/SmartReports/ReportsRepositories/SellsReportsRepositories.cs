using Dapper;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SmartShop.SmartReports.ReportsRepositories
{
    public class SellsReportsRepositories : ISmartShopReport
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            _connection.Close();
        }

        public IEnumerable<Products> GetAllProductBarcode()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SellesChild> GetAllSalesChildPosInvoice(string SellsInvoice)
        {
            //_connection.Open();
            //IEnumerable<SellesChild> returnValues = _connection.Query<SellesChild>(@" select s.ProductCode, p.ProductName, ColourName, SizeName, BrandName, s.Qty, s.SellingPrice, s.VatPercent, s.VatAmount, s.DiscountPercent, s.DiscountAmount, s.TotalAmount
            //from SellesChild s
            //inner join ProductName p on s.ProductCode= p.ProductCode
            //left join SizeTable sz on sz.SizeId= s.SizeId
            //left join ColourTable c on c.ColourId= s.ColurId
            //left join BrandTable b on b.BrandId= s.BrandId
            //where s.SellsInvoice= @SellsInvoice", new { SellsInvoioce = SellsInvoice });
            //_connection.Close();
            //return returnValues;
            throw new NotImplementedException();
        }

        public IEnumerable<SellsParent> GetAllSalesParentPosInvoice(string SellsInvoice)
        {
            //_connection.Open();
            //IEnumerable<SellsParent> returnValues = _connection.Query<SellsParent>(@" select * from SellsParent s
            //where s.SellsInvoice= @SellsInvoice", new { SellsInvoioce = SellsInvoice });
            //_connection.Close();
            //return returnValues;
            throw new NotImplementedException();
        }

        public IEnumerable<SellesChild> GetAllSellsByChildInvoice(string sellsInvoice)
        {
            _connection.Open();
            IEnumerable<SellesChild> returnValues =
                _connection.Query<SellesChild>(@" select s.ProductCode, p.ProductName, ColourName, SizeName, BrandName, s.Qty, s.SellingPrice, s.VatPercent, s.VatAmount, s.DiscountPercent, s.DiscountAmount, s.TotalAmount
            from SellesChild s
            inner join ProductName p on s.ProductCode= p.ProductCode
            left join SizeTable sz on sz.SizeId= s.SizeId
            left join ColourTable c on c.ColourId= s.ColurId
            left join BrandTable b on b.BrandId= s.BrandId
            where s.SellsInvoice= @SellsInvoicce", new { SellsInvoioce = sellsInvoice });
            _connection.Close();
            return returnValues;
        }
        
        public IEnumerable<SellsParent> GetAllSellsParentByInvoice(string sellsInvoice)
        {
            _connection.Open();
            IEnumerable<SellsParent> returnValues =
                _connection.Query<SellsParent>(@" select * from SellsParent s
            where s.SellsInvoice= @SellsInvoicce", new { SellsInvoioce = sellsInvoice });
            _connection.Close();
            return returnValues;
        }

        public IEnumerable<Stock> GetAllStockList()
        {
            _connection.Open();
            IEnumerable<Stock> returnValue = _connection.Query<Stock>($@"select 
                        st.ProductCode,
                        st.ProductName,
                        st.PurchaseQty,
                        st.SalesQty,
                        st.QtyBalance,
                        st.PurchasesAmount,
                        st.SalesAmount,
                        s.SupplyerName,
                        ct.CategoryName,
                        b.BrandName,
                        sz.SizeName,
                        col.ColourName
                        from Stock_vw as st
                        inner join SupplyerTable as s on st.CompanyId=s.id
                        inner join CategoriesTable  as ct on st.CategoryId=ct.Id
                        left join BrandTable as b on st.BrandId=b.BrandId
                        left join  SizeTable as sz on st.SizeId=sz.SizeId
                        left join ColourTable as col on st.ColurId=col.ColurId");
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<CompanyInformation> GetCompanyInformation()
        {
            _connection.Open();
            IEnumerable<CompanyInformation> returnValues = _connection.Query<CompanyInformation>(@" select OfficeCode,Name,Address,ContactNo,Email,Logo,CEO from CompanyTables");
            _connection.Close();
            return returnValues;
        }

        public IEnumerable<CompanyInformation> GetCompanyProfile()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyInformation> GetCompanyProfile(string OfficeCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseChild> GetPurchaseByDate()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseChild> GetPurchaseChild(string PurchaseInvoice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseParent> GetPurchaseHeaderDataByDate(string dateF, string dateT)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseParent> GetPurchaseParent(string PurchaseInvoice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SellesChild> GetSellsChild(string sellsInvoice)
        {
            _connection.Open();
            IEnumerable<SellesChild> returnValues =
                _connection.Query<SellesChild>(@" select s.ProductCode, p.ProductName, ColourName, SizeName, BrandName, s.Qty, s.SellingPrice, s.VatPercent, s.VatAmount, s.DiscountPercent, s.DiscountAmount, s.TotalAmount
            from SellesChild s
            inner join ProductName p on s.ProductCode= p.ProductCode
            left join SizeTable sz on sz.SizeId= s.SizeId
            left join ColourTable c on c.ColourId= s.ColurId
            left join BrandTable b on b.BrandId= s.BrandId
            where s.SellsInvoice= @SellsInvoicce", new { SellsInvoioce = sellsInvoice });
            _connection.Close();
            return returnValues;
        }
        public IEnumerable<SellsParent> GetSellsParent(string sellsInvoice)
        {
            _connection.Open();
            IEnumerable<SellsParent> returnValues =
                _connection.Query<SellsParent>(@" select * from SellsParent s
            where s.SellsInvoice= @SellsInvoice", new { SellsInvoioce = sellsInvoice });
            _connection.Close();
            return returnValues;
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
    }
}
