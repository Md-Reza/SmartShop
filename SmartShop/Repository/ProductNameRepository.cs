using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SmartShop.Models;
using static SmartShop.Interface.Interface;

namespace SmartShop.Repository
{
    public class ProductNameRepository : IDisposable, IBaseRepository<ProductName>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductName> GetByAll( string code)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<ProductName> returnValue = connection.Query<Models.ProductName>(@"Select * from ProductName where Code=@code", new { code = @code });
            connection.Close();
            return returnValue;
        }

        public IEnumerable<ProductName> Get()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<ProductName> returnValue = connection.Query<Models.ProductName, CategoriesSetup, SupplyerInformation,Brand,Colour,Size, ProductName>(@"Select 
            p.Code,            
            p.ProductName as Name,
            p.Description,
            p.ProductPrice,
            p.SellingPrice,
            p.VatPercent,
            p.ReorderLebel,
            p.CreateDate, 
            p.CategoryId,
            p.CompanyId,
            c.CategoryName,
            s.SupplyerName ,
            b.BrandName,
			col.ColourName,
			sz.SizeName
            from ProductName p,CategoriesTable c,SupplyerTable s,BrandTable b,ColourTable col,SizeTable sz
            where p.CategoryId=c.Id
                and p.CompanyId=s.id
                and p.BrandId=b.BrandId
				and p.ColourId=col.ColourId
				and p.SizeId=sz.SizeId", map: (p, c, s,b,col,sz) =>
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

        public IEnumerable<SupplyerInformation> GetAllSupplyerInformations()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<SupplyerInformation> returnValue = connection.Query<Models.SupplyerInformation>(@"Select * from SupplyerTable ");
            connection.Close();
            return returnValue;
        }

        public IEnumerable<ProductName> GetAllProduct()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<ProductName> returnValue = connection.Query<Models.ProductName>(@"Select * from ProductName ");
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

        public IEnumerable<ProductName> GetAllProductByCategories(string CatagoryId)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<ProductName> returnValue = connection.Query<Models.ProductName>(@"Select * from ProductName where CatagoryId=@CatagoryId", new { @CatagoryId = CatagoryId });
            connection.Close();
            return returnValue;
        }

        public ProductName Get(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductName obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("ProductName_sp", new
            { @Name = obj.Name, @Code = obj.Code, @CategoryId = obj.CategoryId, @CompanyId = obj.CompanyId, @ReorderLebel = obj.ReorderLebel, @logo = obj.logo,@Status=obj.Status, @ProductPrice = obj.ProductPrice,
                @SellingPrice = obj.SellingPrice, @VatPercent = obj.VatPercent, @Description=obj.Description, @ColourId = obj.ColourId, @SizeId = obj.SizeId,
                @BrandId = obj.BrandId, @DisCountPercent = obj.DisCountPercent, @CreateById =obj.CreateById, @StatementType = "Create" }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public void Update(ProductName obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("ProductName_sp", new
                { @Name = obj.Name, @Code = obj.Code, @CatagoryId = obj.CategoryId, @CompanyId = obj.CompanyId, @ReorderLebel = obj.ReorderLebel, @logo = obj.logo,@Status=obj.Status, @ProductPrice = obj.ProductPrice, @SellingPrice = obj.@SellingPrice, @VatPercent=obj.VatPercent, @Description = obj.Description, @StatementType = "Update" }, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<ProductName> All(object id)
        {
            throw new NotImplementedException();
        }
    }
}
