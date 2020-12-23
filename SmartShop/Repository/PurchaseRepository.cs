using Dapper;
using DevExpress.XtraEditors;
using SmartShop.Dtos;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static SmartShop.Interface.Interface;

namespace SmartShop.Repository
{
    public class PurchaseRepository : IDisposable, IBaseRepository<PurchaseChild>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public IEnumerable<PurchaseChild> GetByAll(string ProductCode)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<PurchaseChild> returnValue = connection.Query<Models.PurchaseChild>(@"Select * from ProductName where ProductCode=@ProductCode", new { ProductCode = @ProductCode });
            connection.Close();
            return returnValue;
        }

        public IEnumerable<PurchaseParent> GetByAllInvoice( string PurchaseDate)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<PurchaseParent> returnValue = connection.Query<Models.PurchaseParent>(@"Select * from PurchaseParentTable where IsApproved=0 and cast(PurchaseDate as date)=cast(@PurchaseDate as date)",new { PurchaseDate = @PurchaseDate });
            connection.Close();
            return returnValue;
        }

        public IEnumerable<PurchaseParent> GetAllInvoice()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<PurchaseParent> returnValue = connection.Query<Models.PurchaseParent>(@"Select * from PurchaseParentTable");
            connection.Close();
            return returnValue;
        }

        public IEnumerable<PurchaseChild> GetByInvoice(string PurchaseInvoice)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<PurchaseChild> returnValue = connection.Query<Models.PurchaseChild>(@"Select ProductCode,PurchaseInvoice,ProductCode,Qty,PurchasePrice,SellingPrice,DiscountPrice,DiscountAmount,TotalAmount from PurchaseChildTable where PurchaseInvoice=@PurchaseInvoice", new { PurchaseInvoice = @PurchaseInvoice });
            connection.Close();
            return returnValue;
        }
        public IEnumerable<PurchaseChild> GetByInvoiceApprove(string PurchaseInvoice)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<PurchaseChild> returnValue = connection.Query<Models.PurchaseChild>(@"select  
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

        public IEnumerable<PurchaseChild> GetByLastPurchase(string PurchaseDate)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<PurchaseChild> returnValue = connection.Query<Models.PurchaseChild>(
                $@"select * from vw_LastPurchase p where PurchaseDate='{PurchaseDate}' order by PurchaseInvoice desc");
            connection.Close();
            return returnValue;
        }

        public IEnumerable<PurchaseChild> Get()
        {
            throw new NotImplementedException();
        }

        public PurchaseChild Get(object id)
        {
            throw new NotImplementedException();
        }

        public PurchaseChild GetByAll(object id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }


        public void Insert(PurchaseChild obj)
        {
            throw new NotImplementedException();
        }

        public void Update(PurchaseChild obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseChild> All(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.PurchaseParent> GetParentId(string purchaseInvoice)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Models.PurchaseParent> returnValue = connection.Query<Models.PurchaseParent>(@"select * from PurchaseParentTable where PurchaseInvoice = @purchaseInvoice", new { @PurchaseInvoice = purchaseInvoice });
            connection.Close();
            return returnValue;
        }

        public void InsertPurchaseChild(List<PurchaseChild> obj2)
        {
            foreach (var items in obj2)
            {
                InsertData(items);
            }
        }

        public void InsertData(PurchaseChild obj1)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            //Purchase Child
            var id = GetParentId(obj1.PurchaseInvoice);
            connection.Execute("PurchaseChild_sp", new
            {
                @PurchaseInvoice = obj1.PurchaseInvoice,
                @PurchaseId = id.FirstOrDefault().PurchaseId.ToString(),
                @ProductCode = obj1.ProductCode,
                @SalesMonth = obj1.SalesMonth,
                @Qty = obj1.Qty,
                @PurchasePrice = obj1.PurchasePrice,
                @SellingPrice = obj1.SellingPrice,
                @DiscountPrice = obj1.DiscountPrice,
                @DiscountAmount = obj1.DiscountAmount,
                @TotalAmount = obj1.TotalAmount,
                @BrandId = obj1.BrandId,
                @ColourId = obj1.ColourId,
                @SizeId = obj1.SizeId,
                @StatementType = "Create"

            }, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
        public void InsertPurchaseData(PurchaseCreateDto obj2)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());

            try
            {
                connection.Open();
                // Purchase Parent
                connection.Execute("PurchaseParent_sp", new
                {
                    @PurchaseDate = obj2.purchaseParent.PurchaseDate,
                    @SalesMonth = obj2.purchaseParent.SalesMonth,
                    @PurchaseInvoice = obj2.purchaseParent.PurchaseInvoice,
                    @CompanyInvoice = obj2.purchaseParent.CompanyInvoice,
                    @SupplyerId = obj2.purchaseParent.SupplyerId,
                    @DelivaryBy = obj2.purchaseParent.DelivaryBy,
                    @ContactNo = obj2.purchaseParent.ContactNo,
                    @CreateDate = obj2.purchaseParent.CreateDate,
                    @CreateBy = obj2.purchaseParent.CreateBy,
                    @PcName = obj2.purchaseParent.PcName,
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
