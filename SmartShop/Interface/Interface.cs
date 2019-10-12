using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
