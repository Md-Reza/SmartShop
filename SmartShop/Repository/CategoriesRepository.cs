using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.Interface;

namespace SmartShop.Repository
{
    public class CategoriesRepository : IDisposable, IBaseRepository<CategoriesSetup>
    {
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriesSetup> Get()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<CategoriesSetup> returnValue = connection.Query<Models.CategoriesSetup>(@"Select * from CategoriesTable ");
            connection.Close();
            return returnValue;
        }

        public IEnumerable<CategoriesSetup> GetCategoriesName(string Name)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<CategoriesSetup> returnValue = connection.Query<Models.CategoriesSetup>(@"Select * from CategoriesTable where CategoryName = @Name", new { @Name = Name });
            connection.Close();
            return returnValue;
        }

        public CategoriesRepository Get(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(CategoriesRepository obj)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(CategoriesSetup obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("CategoriesTable_sp", new
            { @Name = obj.CategoryName, @Logo = obj.Logo, CreateBy = obj.CreateBy, @Active = obj.Status, @StatementType = "Create" }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public void Update(CategoriesSetup obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("CategoriesTable_sp", new
            { @Name = obj.CategoryName, @Logo = obj.Logo, CreateBy = obj.CreateBy, @Active = obj.Status, @StatementType = "Update" }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        CategoriesSetup IBaseRepository<CategoriesSetup>.Get(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriesSetup> All(object id)
        {
            throw new NotImplementedException();
        }
    }
}
