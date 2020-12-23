using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static SmartShop.Interface.IBusinessInterface;

namespace SmartShop.Repository
{
    public class BusinessObjectRepository : IDisposable, IBusinessRepository<BusinessObjects>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessObjects> GetAllForm()
        {
            _connection.Open();
            IEnumerable<BusinessObjects> returnValue = _connection.Query<BusinessObjects>(@"Select * from BusinessObjects ");
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<BusinessObjects> GetByAllForm(object id)
        {
            throw new NotImplementedException();
        }
    }
}
