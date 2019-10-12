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
    public class SupplyerInformationRepository : IDisposable, IBaseRepository<SupplyerInformation>
    {
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplyerInformation> Get()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<SupplyerInformation> returnValue = connection.Query<Models.SupplyerInformation>(@"Select * from SupplyerTable ");
            connection.Close();
            return returnValue;
        }

        public SupplyerInformation Get(object id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.SupplyerInformation> GetSupplyerInformation(string name)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<Models.SupplyerInformation> returnValue = connection.Query<Models.SupplyerInformation>(@"select * from SupplyerTable where SupplyerName = @name", new { @Name = name });
            connection.Close();
            return returnValue;
        }

        public void Insert(SupplyerInformation obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("SupplyerInformation", new
                { @Name=obj.SupplyerName, @Address=obj.Address, @ContactPerson=obj.ContactPerson, @ContactPersonMobileNo=obj.ContactPersonMobileNo, @Mobile=obj.Mobile, @Email=obj.Email, @logo=obj.Logo, @StatementType = "Create" }, commandType: CommandType.StoredProcedure);
            connection.Close();

        }

        public IEnumerable<SupplyerInformation> GetSupplyerData()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<SupplyerInformation> returnValue = connection.Query<Models.SupplyerInformation>(@"Select * from SupplyerTable ");
            connection.Close();
            return returnValue;
        }

        public void Update(SupplyerInformation obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("SupplyerInformation", new
                { @Name = obj.SupplyerName, @Address = obj.Address, @ContactPerson = obj.ContactPerson, @ContactPersonMobileNo = obj.ContactPersonMobileNo, @Mobile = obj.Mobile, @Email = obj.Email, @logo = obj.Logo, @StatementType = "Update" }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public IEnumerable<SupplyerInformation> All(object id)
        {
            throw new NotImplementedException();
        }
    }
}
