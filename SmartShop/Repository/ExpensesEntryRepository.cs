using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.IExpensesExecute;

namespace SmartShop.Repository
{
    public class ExpensesEntryRepository : IDisposable, IExpensesEntry<ExpensesEntry>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            _connection.Close();
        }

        public void ExecuteExpensesEntry(ExpensesEntry obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("ExpensesEntry_sp", new
            {
                @EntryDate = obj.EntryDate,
                @SalesMonth = obj.SalesMonth,
                @ExpnsId = obj.ExpnsId,
                @ExpenseAmount = obj.ExpenseAmount,
                @Remarks = obj.Remarks,
                @CreateBy = obj.CreateBy,
                @StatementType = "Create"

            }, commandType: CommandType.StoredProcedure);

            connection.Close();
        }

        public void ExecuteUpdateExpensesEntry(ExpensesEntry obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExpensesEntry> GetAllExpensesEntry(string EntryDate_F, string EntryDate_T)
        {
            _connection.Open();
            IEnumerable<ExpensesEntry> returnValue = _connection.Query<Models.ExpensesEntry, ExpensesList, ExpensesEntry>($@"select 
                    en.EntryDate, 
                    en.SalesMonth, 
                    en.ExpenseAmount, 
                    en.Remarks,
                    en.CreateBy,
                    en.CreateDateTime,
                    el.ExpnsName
               from ExpensesEntry as en
               inner join ExpensesList as el on en.ExpnsId = el.ExpnsId
               where EntryDate >= '{EntryDate_F}'" + $@" and EntryDate<= '{EntryDate_T}'", map:
               (en, el) =>
               {
                   en.ExpensesList = el;
                   return en;
               }, splitOn: "ExpnsName");
            _connection.Close();
            return returnValue;

        }

        public IEnumerable<ExpensesEntry> GetByExpensesEntry(string id)
        {
            throw new NotImplementedException();
        }

        public void InsertExpensesEntry(List<ExpensesEntry> obj)
        {
            foreach (var items in obj)
            {
                ExecuteExpensesEntry(items);
            }
        }
    }
}
