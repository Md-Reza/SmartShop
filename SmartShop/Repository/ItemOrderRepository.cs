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
    public class ItemOrderRepository : IDisposable, IBaseRepository<ItemOrder>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemOrder> Get()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<ItemOrder> returnValue = connection.Query<Models.ItemOrder>(@"Select * from tbl_PurchaseRequgitionTable ");
            connection.Close();
            return returnValue;
        }

        public IEnumerable<ItemOrder> GetItemOrderInvoice()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<ItemOrder> returnValue = connection.Query<Models.ItemOrder>(@"Select ISNULL( StartWith,0)+1 as OrderInvoice from SequencePopulateTable  where Code='ItemInv'");
            connection.Close();
            return returnValue;
        }
        public IEnumerable<ProductName> GetItemOrderPrice(string Code)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<ProductName> returnValue = connection.Query<Models.ProductName>(@"select * from ProductName where code='"+ Code+"'");
            connection.Close();
            return returnValue;
        }

        public ItemOrder Get(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ItemOrder obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("PurchaseRequisitionTable_sp", new { @OrderInvoice=obj.OrderInvoice,@OrderDate =obj.OrderDate, @CategoryId=obj.CategoryId, @CompanyId=obj.CompanyId, @Code=obj.Code, @Qty=obj.Qty, @PurchasePrice=obj.PurchasePrice, @DelivaryDate=obj.DelivaryDate, @VatPercent=obj.VatPercent, @Comments =obj.Comments, @StatementType = "Create" }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public void Update(ItemOrder obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ItemOrder> GetAllItemOrder()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<ItemOrder> returnValue = connection.Query<Models. ItemOrder, ProductName,CategoriesSetup, SupplyerInformation, ItemOrder>
            (@"select a.* from
            (
            Select 
			pr.OrderInvoice,
            pr.OrderDate OrderDate,
			 pr.PurchasePrice,
             pr.Qty,
             pr.Vat,
             pr.VatAmount,
             pr.Amount,
             pr.DelivaryDate,
             pr.CreateDate,
             p.ProductName,
			 p.Code,
             p.Description,
             p.ReorderLebel,
             c.CategoryName,
             s.SupplyerName 
			from tbl_PurchaseRequgitionTable as pr
			inner join ProductName as p on pr.Code=p.Code
			inner join CategoriesTable as c on p.CatagoryId=c.Id
			inner join SupplyerTable as s on p.CompanyId=s.id
          )a", 
                map: (pr, p, c, s) =>
                {
                    pr.ProductName = p;
                    pr.CategoriesSetup = c;
                    pr.SupplyerInformation = s;
                    return pr;
                }, splitOn: "ProductName,CategoryName,SupplyerName");
            connection.Close();
            return returnValue;
        }
        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public ItemOrder GetByAll(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemOrder> All(object id)
        {
            throw new NotImplementedException();
        }
    }
}
