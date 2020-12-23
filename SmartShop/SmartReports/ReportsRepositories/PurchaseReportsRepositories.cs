using Dapper;
using SmartShop.Models;
using SmartShop.Repository;
using SmartShop.SmartReports;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SmartShop.Reports.ReportsRepositories
{
    public class PurchaseReportsRepositories : ISmartShopReport
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Models.Reports GetByInvoice(string key)
        {
            Models.Reports returnValues = _connection.QueryFirstOrDefault<Models.Reports>(@"select ROW_NUMBER() OVER( order by c.ProductCode)Sl, (c.ProductCode+' , '+ProductName) ProductName,c.Qty,c.PurchasePrice,c.SellingPrice,c.DiscountPrice,c.DiscountAmount,c.TotalAmount
                                from PurchaseChildTable c
                                inner join PurchaseParentTable pc on c.PurchaseInvoice=pc.PurchaseInvoice
                                inner join ProductName pn on pn.Code=c.ProductCode 
                                where pc.PurchaseInvoice =@PurchaseInvoice", new { PurchaseInvoice = key });
            _connection.Close();
            return returnValues;
        }

        public Models.Reports GetPurchaseReportsByDate(string key1, string key2)
        {
            Models.Reports returnValues = _connection.QueryFirstOrDefault<Models.Reports>(@"select ROW_NUMBER() OVER( order by c.ProductCode)Sl, (c.ProductCode+' , '+ProductName) ProductName,c.Qty,c.PurchasePrice,c.SellingPrice,c.DiscountPrice,c.DiscountAmount,c.TotalAmount
                            from PurchaseChildTable c
                            inner join PurchaseParentTable pc on c.PurchaseInvoice=pc.PurchaseInvoice
                            inner join ProductName pn on pn.Code=c.ProductCode
                            where pc.PurchaseDate <=@PurchaseDateT and pc.PurchaseDate >=@PurchaseDateT ", new { PurchaseDateT = key1, PurchaseDateF = key2 });
            _connection.Close();
            return returnValues;

        }

        public Models.Reports GetPurchaseReportsDate(string key1, string key2)
        {
            Models.Reports returnValues = _connection.QueryFirstOrDefault<Models.Reports>(@"select ROW_NUMBER() OVER( order by c.ProductCode)Sl, (c.ProductCode+' , '+ProductName) ProductName,c.Qty,c.PurchasePrice,c.SellingPrice,c.DiscountPrice,c.DiscountAmount,c.TotalAmount
                            from PurchaseChildTable c
                            inner join PurchaseParentTable pc on c.PurchaseInvoice=pc.PurchaseInvoice
                            inner join ProductName pn on pn.Code=c.ProductCode");
            _connection.Close();
            return returnValues;

        }
        public IEnumerable<PurchaseParent> GetByAllInvoice()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<PurchaseParent> returnValue = connection.Query<Models.PurchaseParent>(@"Select * from PurchaseParentTable");
            connection.Close();
            return returnValue;
        }

        public Models.Reports GetBy(string key)
        {
            throw new NotImplementedException();
        }

        public Models.Reports GetBy(string key, string settingValue)
        {
            Models.Reports returnValues = _connection.QueryFirstOrDefault<Models.Reports>(@"Select * from Reports where IsActivated = 1 and ReportIdentity = @ReportIdentity and SettingValue = @SettingValue;", new { @ReportIdentity = key, @SettingValue = settingValue });
            _connection.Close();
            return returnValues;
        }

        public bool HasHeader(string key, string settingValue)
        {
            throw new NotImplementedException();
        }

        public bool HasFooter(string key, string settingValue)
        {
            throw new NotImplementedException();
        }

        public bool IsActivated(string key, string settingValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Reports> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseChild> GetPurchaseChild(string purchaseInvoice)
        {
            _connection.Open();
            IEnumerable<PurchaseChild> returnValues = _connection.Query<PurchaseChild>(@"select ROW_NUMBER() OVER( order by c.ProductCode)Sl, (c.ProductCode+' , '+ProductName) ProductName,c.Qty,c.PurchasePrice,c.SellingPrice,c.DiscountPrice,c.DiscountAmount,c.TotalAmount from PurchaseChildTable c inner join PurchaseParentTable pc on c.PurchaseInvoice=pc.PurchaseInvoice inner join ProductName pn on pn.Code=c.ProductCode where pc.PurchaseInvoice =@PurchaseInvoice", new { PurchaseInvoice = purchaseInvoice });
            _connection.Close();
            return returnValues;
        }

        public IEnumerable<PurchaseChild> GetPurchaseByDate()
        {
            _connection.Open();
            IEnumerable<PurchaseChild> returnValues = _connection.Query<PurchaseChild>(@"select ROW_NUMBER() OVER( order by c.ProductCode)ProductChildCode, (c.ProductCode+' , '+ProductName) ProductCode,c.Qty,c.PurchasePrice,c.SellingPrice,c.DiscountPrice,c.DiscountAmount,c.TotalAmount from PurchaseChildTable c inner join PurchaseParentTable pc on c.PurchaseInvoice=pc.PurchaseInvoice inner join ProductName pn on pn.ProductCode=c.ProductCode ");
            _connection.Close();
            return returnValues;
        }

        public IEnumerable<PurchaseParent> GetPurchaseHeaderDataByDate(string dateF, string dateT)
        {
            _connection.Open();
            IEnumerable<PurchaseParent> returnValues = _connection.Query<PurchaseParent>(@" select * from ( select CAST( PurchaseDate as date)date,PurchaseDate,PurchaseInvoice,CompanyInvoice,s.SupplyerName,DelivaryBy,ContactNo from PurchaseParentTable p inner join SupplyerTable s on p.SupplyerId=s.id)a where a.date>=@DateF and a.date<=@DateT", new { dateF = @dateF, dateT = @dateT });
            _connection.Close();
            return returnValues;
        }

        public IEnumerable<PurchaseParent> GetPurchaseParent(string purchaseInvoice)
        {
            _connection.Open();
            IEnumerable<PurchaseParent> returnValue = _connection.Query<Models.PurchaseParent>(@"Select * from PurchaseParentTable where PurchaseInvoice=@purchaseInvoice", new { purchaseInvoice = purchaseInvoice });
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<CompanyInformation> GetCompanyInformation()
        {
            _connection.Open();
            IEnumerable<CompanyInformation> returnValue = _connection.Query<Models.CompanyInformation>(@"Select * from CompanyTables ");
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<ProductName> GetAllProductBarcode()
        {
            _connection.Open();
            IEnumerable<ProductName> returnValue = _connection.Query<Models.ProductName>(@"Select * from ProductName ");
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<SellesChild> GetAllSellsByChildInvoice(string SellsInvoice)
        {
            _connection.Open();
            string sql= @"select s.ProductCode,
                s.Qty,s.SellingPrice,
                s.VatPercent,s.VatAmount,
                s.DiscountPercent,
                s.DiscountAmount,
                s.TotalAmount,
                p.ProductName as Name,
                sz.SizeName ,
                c.ColourName,
                b.BrandName,
				pr.TotalAmount,
				pr.PayAmount,
				pr.ReturnAmount
            from SellesChild as s
            inner join ProductName as p on s.ProductCode= p.ProductCode
            left join SizeTable as sz on sz.SizeId= s.SizeId
            left join ColourTable as c on c.ColurId= s.ColurId
            left join BrandTable as b on b.BrandId= s.BrandId
			inner join SellsParent pr on s.SellsInvoice=pr.SellsInvoice
            where s.SellsInvoice= @SellsInvoice"; 
            IEnumerable<SellesChild> returnValues = _connection.Query<SellesChild, ProductName, Size, Colour, Brand,SellsParent, SellesChild>(@sql,
                map: (s, p, sz,c,b,pr) =>
                {
                    s.ProductName = p;
                    s.Size = sz;
                    s.Colour = c;
                    s.Brand = b;
                    s.SellsParent = pr;
                    return s;
                }, splitOn: "Name, SizeName, ColourName, BrandName,TotalAmount", param: new
                {
                    @SellsInvoice = SellsInvoice
                });
            _connection.Close();
            return returnValues;
        }

        public IEnumerable<SellsParent> GetAllSellsParentByInvoice(string SellsInvoice)
        {
            _connection.Open();
            IEnumerable<SellsParent> returnValues =
                _connection.Query<SellsParent>(@" select SellsInvoice, SellsDate,CustomerName,ContactNo,TotalAmount,PayAmount,DueAmount,ReturnAmount,SellsBy,CreateDateTime
                                                from SellsParent s where s.SellsInvoice= @SellsInvoice", new { SellsInvoice = SellsInvoice });
            _connection.Close();
            return returnValues;
        }

        public IEnumerable<SellsParent> GetAllSellsInvoice()
        {
            _connection.Open();
            IEnumerable<SellsParent> returnValues =_connection.Query<SellsParent>(@" select SellsInvoice, SellsDate,CustomerName,ContactNo,TotalAmount,PayAmount,ReturnAmount,SellsBy,CreateDateTime
                                                from SellsParent ");
            _connection.Close();
            return returnValues;
        }

        public IEnumerable<CompanyInformation> GetCompanyProfile()
        {
            _connection.Open();
            IEnumerable<CompanyInformation> returnValues = _connection.Query<CompanyInformation>(@" select OfficeCode,Name,Address,ContactNo,Email,Logo,CEO from CompanyTables");
            _connection.Close();
            return returnValues;
        }

        public IEnumerable<Stock> GetAllStockList()
        {
            _connection.Open();
            string sql = @"select 
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
                        left join ColourTable as col on st.ColurId=col.ColurId";
            IEnumerable<Stock> returnValues = _connection.Query<Stock, SupplyerInformation, CategoriesSetup, Brand, Size, Colour, Stock>(@sql,
                map: (st, s, ct, b, sz, col) =>
                {
                    st.SupplyerInformation = s;
                    st.CategoriesSetup = ct;
                    st.Brand = b;
                    st.Size = sz;
                    st.Colour = col;
                    return st;
                }, splitOn: "SupplyerName,CategoryName,BrandName,SizeName,ColourName");
            _connection.Close();
            return returnValues;
        }

        public IEnumerable<SellesChild> GetAllSalesChildPosInvoice(string posInvoice)
        {
            _connection.Open();
            string sql = @"select s.ProductCode,
                s.Qty,s.SellingPrice,
                s.VatPercent,s.VatAmount,
                s.DiscountPercent,
                s.DiscountAmount,
                s.TotalAmount,
                p.ProductName as Name,
                sz.SizeName ,
                c.ColourName,
                b.BrandName,
				pr.TotalAmount,
				pr.PayAmount,
				pr.ReturnAmount
            from SellesChild as s
            inner join ProductName as p on s.ProductCode= p.ProductCode
            left join SizeTable as sz on sz.SizeId= s.SizeId
            left join ColourTable as c on c.ColurId= s.ColurId
            left join BrandTable as b on b.BrandId= s.BrandId
			inner join SellsParent pr on s.SellsInvoice=pr.SellsInvoice
            where s.SellsInvoice= @SellsInvoice";
            IEnumerable<SellesChild> returnValues = _connection.Query<SellesChild, ProductName, Size, Colour, Brand, SellsParent, SellesChild>(@sql,
                map: (s, p, sz, c, b, pr) =>
                {
                    s.ProductName = p;
                    s.Size = sz;
                    s.Colour = c;
                    s.Brand = b;
                    s.SellsParent = pr;
                    return s;
                }, splitOn: "Name, SizeName, ColourName, BrandName,TotalAmount", param: new
                {
                    @SellsInvoice = posInvoice
                });
            _connection.Close();
            return returnValues;
        }

        public IEnumerable<SellsParent> GetAllSalesParentPosInvoice(string posInvoice)
        {
            _connection.Open();
            IEnumerable<SellsParent> returnValues =_connection.Query<SellsParent>(@" select * from SellsParent s
            where s.SellsInvoice= @SellsInvoice", new { SellsInvoice = posInvoice });
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

