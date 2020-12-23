using Dapper;
using SmartShop.Models;
using SmartShop.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.BankTransactionInterface;

namespace SmartShop.Repository
{
    public class BankTransactionRepository : IDisposable, IBankTransaction<BankTransaction>
    {
        SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            connection.Close();
        }

        public void ExecuteBankTranscation(BankTransaction obj)
        {
            connection.Open();
            connection.Execute("BankTransaction_sp", new
            {
                @AccountNo = obj.AccountNo,
                @TransDate = obj.TransDate,
                @SalesMonth = obj.SalesMonth,
                @OpeningAmount = obj.OpeningAmount,
                @TransType = obj.TransType,
                @DebitAmount = obj.DebitAmount,
                @CreditAmount = obj.CreditAmount,
                @MiscAmount = obj.MiscAmount,
                @CreateBy = Settings.Default.LoginName,
                @StatementType = "Create"
            },
            commandType: CommandType.StoredProcedure);

            connection.Close();
        }
        public void InsertBankTransaction(List<BankTransaction> list)
        {
            foreach (var items in list)
            {
                ExecuteBankTranscation(items);
            }
        }

        public IEnumerable<BankTransaction> GetAllBankTransction()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BankTransaction> GetAllBankTransctionByBank(object BankId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BankTransaction> GetAllBankTransctionDate(string dateF, string dateT)
        {
            connection.Open();
            IEnumerable<BankTransaction> returnValue = connection.Query<BankTransaction, Bank, BankTransaction>($@"select bt.AccountNo,
                    CAST(bt.TransDate as date)TransDate,
                    bt.OpeningAmount,
                    bt.TransType,
                    bt.DebitAmount,
                    bt.CreditAmount,
                    bt.MiscAmount,
                    bt.Balance,
                    bt.CreateBy,
                    bt.CreateDateTime, 
                    b.BankName,
                    b.BankAddress
                    from BankTransaction as bt
                    inner join Bank as b on bt.AccountNo=b.AccountNo
                    where CAST(TransDate as date)>='{dateF}'" + $@" and CAST(TransDate as date)<='{dateT}'", map:
                    (bt, b) =>
                    {
                        bt.Bank = b;
                        return bt;
                    }, splitOn: "BankName");

            connection.Close();
            return returnValue;
        }
    }
}
