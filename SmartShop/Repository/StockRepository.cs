using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static SmartShop.Interface.StockList;

namespace SmartShop.Repository
{
    public class StockRepository : IDisposable, IStockList<Stock>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            _connection.Dispose();
        }
        public IEnumerable<Stock> GetAllStockList()
        {
            _connection.Open();
            IEnumerable<Stock> returnValue =
                _connection.Query<Stock, SupplyerInformation, CategoriesSetup, Brand, Size, Colour, Stock>($@"select 
                        st.ProductCode,
                        st.ProductName,
                        st.PurchaseQty,
                        st.SalesQty,
                        st.QtyBalance,
                        st.PurchasesAmount,
                        st.SalesAmount,
						st.BalanceQtyWithReturn,
						st.SalesAmountWithReturn,
						st.DamageQty,
						st.ReturnQty,
						st.DamageAmt,
						st.ReturnAmt,
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
                        left join ColourTable as col on st.ColurId=col.ColurId", map:
                    (st, s, ct, b, sz, col) =>
                    {
                        st.SupplyerInformation = s;
                        st.CategoriesSetup = ct;
                        st.Brand = b;
                        st.Size = sz;
                        st.Colour = col;
                        return st;
                    }, splitOn: "SupplyerName,CategoryName,BrandName,SizeName,ColourName");
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<Stock> GetAllStockListBySupllyer(object CategoryId)
        {
            _connection.Open();
            IEnumerable<Stock> returnValue =
                _connection.Query<Stock, SupplyerInformation, CategoriesSetup, Brand, Size, Colour, Stock>($@"select 
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
                        inner join BrandTable as b on st.BrandId=b.BrandId
                        inner join  SizeTable as sz on st.SizeId=sz.SizeId
                        inner join ColourTable as col on st.ColurId=col.ColurId
                        where st.CategoryId='{CategoryId} '", map:
                    (st, s, ct, b, sz, col) =>
                    {
                        st.SupplyerInformation = s;
                        st.CategoriesSetup = ct;
                        st.Brand = b;
                        st.Size = sz;
                        st.Colour = col;
                        return st;
                    }, splitOn: "SupplyerName,CategoryName,BrandName,SizeName,ColourName");
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<Stock> GetAllSupplyer()
        {
            throw new NotImplementedException();
        }

        public Stock GetAllSupplyer(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stock> GetByStockListProductCode(string ProductCode)
        {
            _connection.Open();
            IEnumerable<Stock> returnValue =
                _connection.Query<Stock, SupplyerInformation, CategoriesSetup, Brand, Size, Colour, Stock>($@"select 
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
                        left join ColourTable as col on st.ColurId=col.ColurId
                        where QtyBalance>=0
                        and ProductCode='{ProductCode}'", map:
                    (st, s, ct, b, sz, col) =>
                    {
                        st.SupplyerInformation = s;
                        st.CategoriesSetup = ct;
                        st.Brand = b;
                        st.Size = sz;
                        st.Colour = col;
                        return st;
                    }, splitOn: "SupplyerName,CategoryName,BrandName,SizeName,ColourName");
            _connection.Close();
            return returnValue;
        }
    }
}
