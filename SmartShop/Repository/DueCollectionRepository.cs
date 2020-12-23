using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.DueCollection;

namespace SmartShop.Repository
{
    public class DueCollectionRepository : IDisposable, IDueRepository<ArrearCollection>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());

        public void Dispose()
        {
            _connection.Close();
        }

        public void ExecuteArrearCollection(ArrearCollection obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("ArrearCollection_sp", new
            {
                @CustId = obj.CustId,
                @TransactionDate = obj.TransactionDate,
                @SalesMonth = obj.SalesMonth,
                @DueAmount = obj.DueAmount,
                @PayAmount = obj.PayAmount,
                @LastDueAmount = obj.LastDueAmount,
                @CreateBy = obj.CreateBy,
                @StatementType = "Create"
            }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public void ExecuteDeleteCustomers(ArrearCollection obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArrearCollection> GetAllCustomerArrear()
        {
            _connection.Open();
            IEnumerable<ArrearCollection> returnValue = _connection.Query<ArrearCollection, CustomerInformation, ArrearCollection>($@"select 
                            vw.CustId,
                            vw.CustomerName,
                            vw.DueAmount,
                            vw.PayAmount,
                            vw.LastDueAmount, 
                            ci.ContactNo,
                            ci.CustomerPresentAddress
                          from  CustomerAllDue_vw as vw left join CustomerInformation as ci on vw.CustId=ci.CustId", map:
                    (vw,ci )=>
                    {
                        vw.CustomerInformation = ci;
                        return vw;
                    }, splitOn: "ContactNo");
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<ArrearCollection> GetAllCustomerDue()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArrearCollection> GetByCustomerDue(object T)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArrearCollection> GetByDateArrearDueCollection(string TransactionDate)
        {
            _connection.Open();
            IEnumerable<ArrearCollection> returnValue = _connection.Query<ArrearCollection>(" select* from  ArrearCollection_vw vw inner join CustomerInformation as ci on vw.CustId=ci.CustId where TransactionDate = @TransactionDate order by sl desc", new { TransactionDate = @TransactionDate });
            _connection.Close();
            return returnValue;
        }

        public IEnumerable<ArrearCollection> GetCustomerArrear(object CustId)
        {
            _connection.Open();
            IEnumerable<ArrearCollection> returnValue = _connection.Query<ArrearCollection>("select ar.CustId,ar.CustomerName, sum(isnull(ac.PayAmount,0))PayAmount,ar.DueAmount,isnull(ar.DueAmount,0)-sum(isnull(ac.PayAmount,0))LastDueAmount from ArrearAmount_vw as ar left join ArrearCollection_vw as ac on ar.CustId = ac.CustId where ar.CustId = @CustId group by ar.CustId, ar.CustomerName, ar.DueAmount", new { CustId = CustId });
            _connection.Close();
            return returnValue;
        }
        

        public IEnumerable<ArrearCollection> GetDateWisePaymentView(string TransactionDate_F,string TransactionDate_T)
        {
            _connection.Open();
            IEnumerable<ArrearCollection> returnValue =_connection.Query<ArrearCollection, CustomerInformation, ArrearCollection>($@"select 
                    vw.CustId,
                    vw.PayAmount,
                    vw.LastDueAmount,
                    vw.CreateBy,
                    ci.CustomerName,
                    ci.CustomerPermanentAddress,
                    ci.ContactNo
                    from  ArrearCollection_vw vw inner join CustomerInformation as ci on vw.CustId=ci.CustId  
                    where TransactionDate>='{TransactionDate_F}'" + $@" and TransactionDate<='{TransactionDate_T}'", map:
                    (vw, ci) =>
                    {
                        vw.CustomerInformation = ci;
                        return vw;
                    }, splitOn: "CustomerName");
            
                _connection.Close();
            return returnValue;
        }
    }
}
