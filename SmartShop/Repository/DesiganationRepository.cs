using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.Interface;

namespace SmartShop.Repository
{
    public class DesiganationRepository : IDisposable, IBaseRepository<Desiganation>
    {
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Desiganation> Get()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Desiganation> returnValue = connection.Query<Models.Desiganation>(@"Select * from Designations");
            connection.Close();
            return returnValue;
        }

        public IEnumerable<Desiganation> GetByCode(string Name)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Desiganation> returnValue = connection.Query<Models.Desiganation>(@"Select * from DesignationTable where DesiName='" + Name + "'");
            connection.Close();
            return returnValue;
        }

        public Desiganation Get(object id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Desiganation obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("DesiganationInformation", new
            { @DesiCode = obj.DesiCode, @Name = obj.DesiName, @Status = obj.Status, @StatementType = "Create" }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public IEnumerable<Desiganation> GetByDesiCode()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Desiganation> returnValue = connection.Query<Models.Desiganation>(@"Select ISNULL( StartWith,0)+1 as DesiCode from SequencePopulateTable  where Code='DesiCode'");
            connection.Close();
            return returnValue;
        }

        public void Update(Desiganation obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("DesiganationInformation", new
            { @DesiCode = obj.DesiCode, @Name = obj.DesiName, @Status = obj.Status, @StatementType = "Update" }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public Desiganation GetByAll(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Desiganation> All(object id)
        {
            throw new NotImplementedException();
        }
    }
}
