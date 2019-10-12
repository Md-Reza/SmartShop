using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Models;
using static SmartShop.Interface.Interface;

namespace SmartShop.Repository
{
    public class ComapnySetupRepository : IDisposable, IBaseRepository<CompanyInformation>
    {
        // SqlConnection _sqlConnection;
        //SqlDataAdapter _sqlDataAdapter;
        //SqlCommand _sqlCommand;
        // DataTable _dt;

        // IBaseRepository<EmployeeInformation> baseRepository = new EmployeeRepository();

        public IEnumerable<CompanyInformation> Get()
        {

            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<CompanyInformation> returnValue = connection.Query<Models.CompanyInformation>(@"Select * from CompanyTables ");
            connection.Close();
            return returnValue;
        }
        public void CompanyInsert(CompanyInformation obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("companyProfile", new
            { @Name = obj.Name, @Address = obj.Address, @FactoryAddress = obj.FactoryAddress, @ContactNo = obj.ContactNo, @Email = obj.Email, @Fax = obj.Fax, @Logo = obj.Logo, @CEO = obj.CEO, @AppInstallDate = obj.AppInstallDate, @AppVersion = obj.AppVersion, @StatementType = "Create" }, commandType: CommandType.StoredProcedure);
            connection.Close();

        }

        public IEnumerable<CompanyInformation> GetCompanyData()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<CompanyInformation> returnValue = connection.Query<Models.CompanyInformation>(@"Select * from CompanyTables ");
            connection.Close();
            return returnValue;
        }

        public void UpdateCompanyInformation(CompanyInformation obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("companyProfile", new
            { @Name = obj.Name, @Address = obj.Address, @FactoryAddress = obj.FactoryAddress, @ContactNo = obj.ContactNo, @Email = obj.Email, @Fax = obj.Fax, @Logo = obj.Logo, @CEO = obj.CEO, @AppInstallDate = obj.AppInstallDate, @AppVersion = obj.AppVersion, @StatementType = "Update" }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public CompanyInformation Get(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(CompanyInformation obj)
        {
            throw new NotImplementedException();
        }

        public void Update(CompanyInformation obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public CompanyInformation GetByAll(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyInformation> All(object id)
        {
            throw new NotImplementedException();
        }
    }
}
