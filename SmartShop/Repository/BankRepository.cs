using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.BankInterface;

namespace SmartShop.Repository
{
    public class BankRepository : IDisposable, IBank<Bank>
    {
        SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            connection.Close();
        }

        public void ExecuteBankEntry(Bank obj)
        {
            connection.Open();
            connection.Execute("Bank_sp", new
            {
                @BankId = 0,
                @BankName = obj.BankName,
                @AccountNo = obj.AccountNo,
                @BankAddress = obj.BankAddress,
                @Status = obj.Status,
                @CreateBy = obj.CreateBy,
                @StatementType = "Create"
            },
            commandType: CommandType.StoredProcedure);

            connection.Close();
        }

        //public void InsertBankTransaction(List<Bank> list)
        //{
        //    foreach (var items in list)
        //    {
        //        ExecuteBankTranscation(items);
        //    }
        //}

        //public void ExecuteBankTranscation(Bank obj)
        //{
        //    connection.Open();
        //    connection.Execute("BankTransaction_sp", new
        //    {
        //        @AccountNo = obj.BankTransaction.AccountNo,
        //        @TransDate = obj.BankTransaction.TransDate,
        //        @SalesMonth = obj.BankTransaction.SalesMonth,
        //        @OpeningAmount = obj.BankTransaction.OpeningAmount,
        //        @TransType = obj.BankTransaction.TransType,
        //        @DebitAmount = obj.BankTransaction.DebitAmount,
        //        @CreditAmount = obj.BankTransaction.CreditAmount,
        //        @MiscAmount = obj.BankTransaction.MiscAmount,
        //        @CreateBy = Settings.Default.LoginName,
        //        @StatementType = "Create"
        //    },
        //    commandType: CommandType.StoredProcedure);

        //    connection.Close();
        //}

        public IEnumerable<Bank> GetAllBank()
        {
            connection.Open();
            IEnumerable<Bank> returnValue = connection.Query<Models.Bank>(@"Select * from Bank where Status=1");
            connection.Close();
            return returnValue;
        }

        public IEnumerable<Bank> GetByBankId(object AccountNo)
        {
            connection.Open();
            IEnumerable<Bank> returnValue = connection.Query<Models.Bank>(@"Select * from Bank where Status=1 and AccountNo=@AccountNo", new { AccountNo = @AccountNo });
            connection.Close();
            return returnValue;
        }

        public void UpdateEntry(Bank obj)
        {
            connection.Open();
            connection.Execute("Bank_sp", new
            {
                @BankId = obj.BankId,
                @BankName = obj.BankName,
                @AccountNo = obj.AccountNo,
                @BankAddress = obj.BankAddress,
                @Status = obj.Status,
                @CreateBy = obj.CreateBy,
                @StatementType = "Update"
            },
            commandType: CommandType.StoredProcedure);
            connection.Close();
        }
    }
}
