using System.Collections.Generic;

namespace SmartShop.Interface
{
    public sealed class DueCollection
    {
        public interface IDueRepository<T> where T : class
        {
            IEnumerable<T> GetAllCustomerDue();
            IEnumerable<T> GetAllCustomerArrear();
            void ExecuteArrearCollection(T obj);
            void ExecuteDeleteCustomers(T obj);
            IEnumerable<T> GetByCustomerDue(object T);
            IEnumerable<T> GetByDateArrearDueCollection(string T);
            IEnumerable<T> GetCustomerArrear(object T);
            IEnumerable<T> GetDateWisePaymentView(string T, string F);
        }
    }
}
