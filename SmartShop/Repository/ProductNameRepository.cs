using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.Interface;

namespace SmartShop.Repository
{
    public class ProductNameRepository : IDisposable, IBaseRepository<Products>
    {
        SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            connection.Dispose();
        }

        public IEnumerable<Products> GetByAll(string code)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Products> returnValue = connection.Query<Models.Products>(@"Select ProductName as Name,* from ProductName where ProductCode=@code", new { code = @code });
            connection.Close();
            return returnValue;
        }
        public IEnumerable<Products> Get()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Products> returnValue = connection.Query<Models.Products, CategoriesSetup, SupplyerInformation, Brand, Colour, Size, Products>(@"Select 
            p.ProductCode,            
            p.ProductName,
            p.Description,
            p.PurchasePrice,
            p.SellingPrice,
            p.VatPercent,
            p.DisCountPercent,
            p.ReorderLebel,
            p.logo,
            p.CreateDate, 
            p.CategoryId,
            p.CompanyId,
            p.ColurId,
            p.SizeId,
            p.BrandId,
            c.CategoryName,
            s.SupplyerName ,
            b.BrandName,
			col.ColourName,
			sz.SizeName
            from ProductName p 
            inner join CategoriesTable as c on p.CategoryId=c.Id
			inner join SupplyerTable as s on p.CompanyId=s.id
			left join BrandTable  as b on b.BrandId=p.BrandId
			left join ColourTable as col on col.ColurId=p.ColurId
			left join SizeTable as sz on sz.SizeId=p.SizeId", map: (p, c, s, b, col, sz) =>
            {
                p.CategoryName = c;
                p.SupplyerName = s;
                p.Brand = b;
                p.Colour = col;
                p.Size = sz;
                return p;
            }, splitOn: "CategoryName, SupplyerName,BrandName,ColourName,SizeName");
            connection.Close();
            return returnValue;
        }
        public IEnumerable<Products> GetAllProductWithStock()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Products> returnValue = connection.Query<Models.Products, CategoriesSetup, SupplyerInformation,Stock,Products>(@"select 
                        p.ProductCode,
                        p.ProductName,
                        p.PurchasePrice,
                        p.SellingPrice ,
                        p.VatPercent,
                        p.DisCountPercent,
                        ct.CategoryName,
                        sup.SupplyerName,
                        (ISnull(s.BalanceQtyWithReturn,0))QtyBalance
                        from ProductName as p 
                        left join CategoriesTable as ct on p.CategoryId=ct.Id
                        left join SupplyerTable as sup on p.CompanyId=sup.id
                        left join Stock_vw as s on p.ProductCode=s.ProductCode and ct.Id=s.CategoryId and sup.id=s.CompanyId ", map: (p, ct, sup, s) =>
            {
                p.CategoryName = ct;
                p.SupplyerName = sup;
                p.Stock = s;
                return p;
            }, splitOn: "CategoryName, SupplyerName,QtyBalance");
            connection.Close();
            return returnValue;
        }
        public IEnumerable<SupplyerInformation> GetAllSupplyerInformations()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<SupplyerInformation> returnValue = connection.Query<Models.SupplyerInformation>(@"Select * from SupplyerTable ");
            connection.Close();
            return returnValue;
        }

        public IEnumerable<Products> GetAllProduct()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Products> returnValue = connection.Query<Models.Products>(@"Select ProductName as Name,* from ProductName ");
            connection.Close();
            return returnValue;
        }
        public IEnumerable<Products> GetByProductCode(string ProductCode)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Products> returnValue = connection.Query<Models.Products>(@"Select * from ProductName where ProductCode=@ProductCode",new { ProductCode = @ProductCode });
            connection.Close();
            return returnValue;
        }

        public IEnumerable<Products> GetAllItem(string code)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Products> returnValue = connection.Query<Models.Products>(@"Select SellingPrice from ProductName where ProductCode=@code", new { code = @code });
            connection.Close();
            return returnValue;
        }

        public IEnumerable<Products> GetAllPrice(string code)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Products> returnValue = connection.Query<Products>(@"Select SellingPrice from ProductName where ProductCode=@code", new { code = @code });
            connection.Close();
            return returnValue;
        }

        public IEnumerable<Colour> GetAllColour()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Colour> returnValue = connection.Query<Models.Colour>(@"Select * from ColourTable ");
            connection.Close();
            return returnValue;
        }
        public IEnumerable<Brand> GetAllBrand()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Brand> returnValue = connection.Query<Models.Brand>(@"Select * from BrandTable ");
            connection.Close();
            return returnValue;
        }
        public IEnumerable<Size> GetAllSize()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Size> returnValue = connection.Query<Models.Size>(@"Select * from SizeTable ");
            connection.Close();
            return returnValue;
        }

        public IEnumerable<Products> GetAllProductByCategories(string CatagoryId)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Products> returnValue = connection.Query<Models.Products>(@"Select * from ProductName where CatagoryId=@CatagoryId", new { @CatagoryId = CatagoryId });
            connection.Close();
            return returnValue;
        }

        public Products Get(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Products obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("ProductName_sp", new
            {
                @Name = obj.ProductName,
                @ProductCode = obj.ProductCode,
                @CategoryId = obj.CategoryId,
                @CompanyId = obj.CompanyId,
                @ReorderLebel = obj.ReorderLebel,
                @logo = obj.logo,
                @Status = obj.Status,
                @PurchasePrice = obj.PurchasePrice,
                @SellingPrice = obj.SellingPrice,
                @VatPercent = obj.VatPercent,
                @Description = obj.Description,
                @ColourId = obj.ColurId,
                @SizeId = obj.SizeId,
                @BrandId = obj.BrandId,
                @DisCountPercent = obj.DisCountPercent,
                @CreateById = obj.CreateById,
                @StatementType = "Create"
            }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public void Update(Products obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("ProductName_sp", new
            {   @Name = obj.ProductName, 
                @CategoryId = obj.CategoryId, 
                @CompanyId = obj.CompanyId, 
                @ReorderLebel = obj.ReorderLebel, 
                @logo = obj.logo,  
                @PurchasePrice = obj.PurchasePrice, 
                @SellingPrice = obj.@SellingPrice, 
                @VatPercent = obj.VatPercent,
                @Status = obj.Status,
                @Description = obj.Description, 
                @ColourId=obj.CategoryId,
                @SizeId=obj.SizeId, 
                @BrandId=obj.BrandId, 
                @DisCountPercent=obj.DisCountPercent,
                @ProductCode = obj.ProductCode,
                @CreateById= obj.CreateById,
                @StatementType = "Update"  }, 
                commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public void UpdateProducts(Products obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("ProductName_sp", new
            {
                @Name = obj.ProductName,
                @CategoryId = obj.CategoryId,
                @CompanyId = obj.CompanyId,
                @ReorderLebel = obj.ReorderLebel,
                @logo = obj.logo,
                @PurchasePrice = obj.PurchasePrice,
                @SellingPrice = obj.@SellingPrice,
                @VatPercent = obj.VatPercent,
                @Status = obj.Status,
                @Description = obj.Description,
                @ColourId = obj.CategoryId,
                @SizeId = obj.SizeId,
                @BrandId = obj.BrandId,
                @DisCountPercent = obj.DisCountPercent,
                @ProductCode = obj.ProductCode,
                @StatementType = "Update"
            },
                commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Products> All(object id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Products> GetByProductCodeName(string name)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Products> returnValue = connection.Query<Models.Products>(
                    @"select *
                    from
                    (
                    select ProductCode+' '+ProductName as ProCodeName,* from ProductName )a
                    where a.ProCodeName like(@ProCodeName)", new { @ProCodeName = name });
            connection.Close();
            return returnValue;
        }
    }
}
