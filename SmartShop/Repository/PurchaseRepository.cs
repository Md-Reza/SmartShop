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
    public class PurchaseRepository : IDisposable, IBaseRepository<PurchaseChild>
    {
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseChild> GetByAll( string code)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<PurchaseChild> returnValue = connection.Query<Models.PurchaseChild>(@"Select * from ProductName where Code=@code", new { code = @code });
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
    }
}
