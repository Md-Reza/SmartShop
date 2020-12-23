using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.CustomerInfoInterface;

namespace SmartShop.Repository
{
    public sealed class CustomersRepository : IDisposable, ICustRepository<CustomerInformation>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            _connection.Close();
        }

        public void ExecuteCustomers(CustomerInformation obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("CustomerInfo_sp", new
            {
                @CustId = obj.CustId,
                @CustomerName = obj.CustomerName,
                @CustomerPresentAddress = obj.CustomerPresentAddress,
                @CustomerPermanentAddress = obj.CustomerPermanentAddress,
                @ContactNo = obj.ContactNo,
                @Email = obj.Email,
                @Gender = obj.Gender,
                @Photo = obj.Photo,
                @IsActive = obj.IsActive,
                @CreateBy = obj.CreateBy,
                @StatementType = "Create"
            }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public void ExecuteDeleteCustomers(CustomerInformation obj)
        {
            throw new NotImplementedException();
        }

        public void ExecuteUpdateCustomers(CustomerInformation obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("CustomerInfo_sp", new
            {
                @CustId = obj.CustId,
                @CustomerName = obj.CustomerName,
                @CustomerPresentAddress = obj.CustomerPresentAddress,
                @CustomerPermanentAddress = obj.CustomerPermanentAddress,
                @ContactNo = obj.ContactNo,
                @Email = obj.Email,
                @Gender = obj.Gender,
                @Photo = obj.Photo,
                @IsActive = obj.IsActive,
                @CreateBy = obj.CreateBy,
                @StatementType = "Update"
            }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public IEnumerable<CustomerInformation> GetAllCustomer()
        {
            _connection.Open();
            IEnumerable<CustomerInformation> customerInformation = _connection.Query<CustomerInformation>("select * from CustomerInformation");
            _connection.Close();
            return customerInformation;
        }

        public CustomerInformation GetAllCustomer(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerInformation> GetAllCustomerArrear(object CustId)
        {
            _connection.Open();
            IEnumerable<CustomerInformation> returnValue = _connection.Query<CustomerInformation>("select sum(ISNULL(DueAmount,0))DueAmount,ci.CustId,ci.CustomerName from CustomerInformation as ci left join CustomerArrear as ca on ci.CustId = ca.CustId  where ci.CustId=@CustId group by ci.CustId, ci.CustomerName", new{CustId=CustId});
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<CustomerInformation> GetByCustomer(object CustId)
        {
            _connection.Open();
            IEnumerable<CustomerInformation> customerInformation = _connection.Query<CustomerInformation>("select * from CustomerInformation where CustId=@CustId", new { CustId = @CustId });
            _connection.Close();
            return customerInformation;
        }

    }
}
