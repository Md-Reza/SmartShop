using System.Collections.Generic;

namespace SmartShop.Interface
{
    public sealed class CustomerInfoInterface
    {
        public interface ICustRepository<T> where T : class
        {
            IEnumerable<T> GetAllCustomer();
            T GetAllCustomer(object id);
            IEnumerable<T> GetByCustomer(object id);
            void ExecuteCustomers(T obj);
            void ExecuteDeleteCustomers(T obj);
            void ExecuteUpdateCustomers(T obj);
            IEnumerable<T> GetAllCustomerArrear(object T);
        }
    }
}
