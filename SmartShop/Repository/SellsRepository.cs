﻿using Dapper;
using DevExpress.XtraEditors;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static SmartShop.Interface.Interface;

namespace SmartShop.Repository
{
    public class SellsRepository : IDisposable, IBaseRepository<SellesChild>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public IEnumerable<SellesChild> All(object id)
        {
            _connection.Open();
            IEnumerable<SellesChild> returnValue = _connection.Query<Models.SellesChild>(@"select * from SellsParent where SellsInvoice =@SellsInvoice", new { SellsInvoice = id });
            _connection.Close();
            return returnValue;
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _connection.Open();
        }

        public IEnumerable<SellesChild> Get()
        {
            throw new NotImplementedException();
        }

        public SellesChild Get(object id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(SellesChild obj)
        {
            throw new NotImplementedException();
        }

        public void Update(SellesChild obj)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Products> GetByAll(string ProductCode)
        {
            _connection.Open();
            IEnumerable<Products> returnValue = _connection.Query<Models.Products>(@"Select * from ProductName where ProductCode=@ProductCode", new { ProductCode = @ProductCode });
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<Products> GetByAllSellsProduct(string ProductCode)
        {
            _connection.Open();
            IEnumerable<Products> returnValue = _connection.Query<Models.Products>(@"Select id,ProductCode,ProductName as Name,CategoryId,CompanyId,ReorderLebel,logo,PurchasePrice,SellingPrice,VatPercent,Description,ColurId,SizeId,BrandId,DisCountPercent from ProductName where ProductCode=@ProductCode", new { ProductCode = @ProductCode });
            _connection.Close();
            return returnValue;
        }
        public IEnumerable<Products> GetByAllSellsProducts()
        {
            _connection.Open();
            IEnumerable<Products> returnValue = _connection.Query<Models.Products>(@"Select id,ProductCode,ProductName as Name,CategoryId,CompanyId,ReorderLebel,logo,PurchasePrice,SellingPrice,VatPercent,Description,ColurId,SizeId,BrandId,DisCountPercent from ProductName");
            _connection.Close();
            return returnValue;
        }
        public IEnumerable<SellesChild> GetByInvoiceSells(string PurchaseInvoice)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<SellesChild> returnValue = connection.Query<Models.SellesChild>(@"select  
                                    PChidId,
                                    PurchaseInvoice,
                                    PurchaseId,
                                    ProductCode,
                                    Qty,
                                    PurchasePrice,
                                    SellingPrice,
                                    DiscountPrice,
                                    DiscountAmount,
                                    TotalAmount
                                    from PurchaseChildTable where PurchaseInvoice in (select PurchaseInvoice from PurchaseParentTable where PurchaseInvoice=@PurchaseInvoice  and IsApproved=0 )
                                    and PurchaseInvoice=@PurchaseInvoice", new { PurchaseInvoice = @PurchaseInvoice });
            connection.Close();
            return returnValue;
        }
        public IEnumerable<SellesChild> GetByLastSells( string SellsDate)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<SellesChild> returnValue = connection.Query<Models.SellesChild>(
                @"select * from vw_LastSells p where SellsDate=@SellsDate  order by SellsInvoice desc",new { SellsDate = @SellsDate.ToString() });
            connection.Close();
            return returnValue;
        }

        public IEnumerable<SellesChild> GetAllSales()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<SellesChild> returnValue2 = connection.Query<Models.SellesChild, Products, SellesChild>(@"select 
                    SellsInvoice,
                    Sum(Qty) as Qty,
                    sum(VatAmount)as VatAmount,
                    sum(DiscountAmount)as DiscountAmount,
                    Sum(TotalAmount)as TotalAmount,
                    ProductName
                    from SellesChild as c
                    inner join ProductName as p on c.ProductCode=p.ProductCode
                    group by SellsInvoice,ProductName", map: (c,p) =>
            {
                c.Products = p;
                return c;
            }, splitOn: "ProductName");
            connection.Close();
            return returnValue2;
        }
        public IEnumerable<SellesChild> GetAllPendingSales(long SellsInvoice)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<SellesChild> returnValue2 = connection.Query<Models.SellesChild, Products, SellesChild>(@"select 
                    SellsInvoice,
                    Qty,
                    VatAmount,
                    DiscountAmount,
                    TotalAmount,
                    p.ProductName,
                    p.ProductCode
                    from SellesChild as c
                    inner join ProductName as p on c.ProductCode=p.ProductCode
                    where SellsInvoice=@SellsInvoice", map: (c, p) =>
            {
                c.Products = p;
                return c;
            },
            param: new
            {
                SellsInvoice= SellsInvoice
            },
            splitOn: "ProductName");
            connection.Close();
            return returnValue2;
        }

        public IEnumerable<Models.SellsParent> GetParentId(string sellsInvoice)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Models.SellsParent> returnValue = connection.Query<Models.SellsParent>(@"select * from SellsParent where SellsInvoice = @sellsInvoice", new { @SellsInvoice = sellsInvoice });
            connection.Close();
            return returnValue;
        }
        public void InsertSellsChild(List<SellesChild> obj2)
        {
            foreach (var items in obj2)
            {
                InsertData(items);
            }
        }
        public void InsertSellsChildByItem(List<SellesChild> obj2)
        {
            foreach (var items in obj2)
            {
                SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
                connection.Open();
                connection.Execute("SellsChildByItem_sp", new
                {
                    @SellsInvoice = items.SellsInvoice,
                    @SalesMonth = items.SalesMonth,
                    @ProductCode = items.ProductCode,
                    @Qty = items.Qty,
                    @SellingPrice = items.SellingPrice,
                    @VatAmount = items.VatAmount,
                    @DiscountAmount = items.DiscountAmount,
                    @TotalAmount = items.TotalAmount,
                    @StatementType = "Create"

                }, commandType: CommandType.StoredProcedure);

                connection.Close();
            }
        }

        public void InsertData(SellesChild obj1)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            var id = GetParentId(obj1.SellsInvoice);
            connection.Execute("SellsChild_sp", new
            {
                @SellsParId = id.FirstOrDefault().SellsParId.ToString(),
                @SellsInvoice = obj1.SellsInvoice,
                @SalesMonth=obj1.SalesMonth,
                @ProductCode = obj1.ProductCode,
                @ColurId = obj1.ColurId,
                @SizeId = obj1.SizeId,
                @BrandId = obj1.BrandId,
                @Qty = obj1.Qty,
                @SellingPrice = obj1.SellingPrice,
                @VatPercent = obj1.VatPercent,
                @VatAmount = obj1.VatAmount,
                @DiscountPercent = obj1.DisCountPercent,
                @DiscountAmount = obj1.DiscountAmount,
                @TotalAmount = obj1.TotalAmount,
                @StatementType = "Create"

            }, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
        public void InsertSellsParent(SellsParent obj2)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            try
            {
                connection.Open();
                connection.Execute("SellsParent_sp", new
                {
                    @SellsInvoice = obj2.SellsInvoice,
                    @SellsDate = obj2.SellsDate,
                    @SalesMonth = obj2.SalesMonth,
                    @CustomerName = obj2.CustomerName,
                    @ContactNo = obj2.ContactNo,
                    @TotalAmount = obj2.TotalAmount,
                    @PayAmount = obj2.PayAmount,
                    @DueAmount = obj2.DueAmount,
                    @ReturnAmount = obj2.ReturnAmount,
                    @SellsBy = obj2.SellsBy,
                    @PcName = obj2.PcName,
                    @StatementType = "Create"
                }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message);
            }
        }
    }
}
