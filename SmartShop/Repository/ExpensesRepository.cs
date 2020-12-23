using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.Expenses;

namespace SmartShop.Repository
{
    public class ExpensesRepository : IDisposable, IExpenses<ExpensesList>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            _connection.Close();
        }
        public void ExecuteDeleteCustomers(ExpensesEntry obj)
        {
            throw new NotImplementedException();
        }

        public void ExecuteDeleteCustomers(ExpensesList obj)
        {
            throw new NotImplementedException();
        }

        public void ExecuteExpensesList(ExpensesList obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("ExpensesList_sp", new
            {
                @ExpnsName = obj.ExpnsName,
                @Remarks = obj.Remarks,
                @IsActive = obj.IsActive,
                @StatementType = "Create"

            }, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
        public void ExecuteUpdateExpensesList(ExpensesList obj)
        {
            throw new NotImplementedException();
        }

        public void ExecuteUpdateExpensesList(ExpensesEntry obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExpensesList> GetAllExpenses()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<ExpensesList> returnValue = connection.Query<Models.ExpensesList>(@"Select * from ExpensesList where IsActive=1");
            connection.Close();
            return returnValue;
        }

        public IEnumerable<ExpensesList> GetByExpenses(string id)
        {
            throw new NotImplementedException();
        }
    }
}
