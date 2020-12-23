using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static SmartShop.Interface.IDepartment;

namespace SmartShop.Repository
{
    public class DepartmentRepository : IDisposable, Idepartments<Departments>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            _connection.Close();
        }

        public IEnumerable<Departments> GetAllDepartment()
        {
            _connection.Open();
            IEnumerable<Departments> returnValue = _connection.Query<Departments>("select * from Departments");
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<Departments> GetByDepartment(string T)
        {
            throw new NotImplementedException();
        }
    }
}
