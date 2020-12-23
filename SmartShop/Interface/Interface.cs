using System.Collections.Generic;
using System.Data;

namespace SmartShop.Interface
{
    public class Interface
    {
        public interface IBaseRepository<T> where T : class
        {
            IEnumerable<T> Get();
            T Get(object id);
            IEnumerable<T> All(object id);
            void Insert(T obj);
            void Update(T obj);
            void Delete(object id);
            DataTable GetAll();
        }
    }
}
