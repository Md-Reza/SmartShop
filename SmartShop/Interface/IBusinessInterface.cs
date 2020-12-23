using System.Collections.Generic;

namespace SmartShop.Interface
{
   public sealed class IBusinessInterface
    {
        public interface IBusinessRepository<T> where T : class
        {
            IEnumerable<T> GetAllForm();
            IEnumerable<T> GetByAllForm(object id);
    
           
        }
    }
}
