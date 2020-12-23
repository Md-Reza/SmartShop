using System.Collections.Generic;

namespace SmartShop.Interface
{
    public sealed class Expenses
    {
        public interface IExpenses<T> where T : class
        {
            IEnumerable<T> GetAllExpenses();
            IEnumerable<T> GetByExpenses(string id);
            void ExecuteExpensesList(T obj);
            void ExecuteDeleteCustomers(T obj);
            void ExecuteUpdateExpensesList(T obj);
        }
    }
}
