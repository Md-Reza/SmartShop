using System.Collections.Generic;

namespace SmartShop.Interface
{
    public sealed  class IExpensesExecute
    {
        public interface IExpensesEntry<T> where T : class
        {
            IEnumerable<T> GetAllExpensesEntry(string dateF,string dateT);
            IEnumerable<T> GetByExpensesEntry(string id);
            void ExecuteExpensesEntry(T obj);
            void InsertExpensesEntry(List<T> obj);
            void ExecuteUpdateExpensesEntry(T obj);
        }
    }
}
