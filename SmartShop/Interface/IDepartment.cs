using System.Collections.Generic;

namespace SmartShop.Interface
{
    public sealed  class IDepartment
    {
        public interface Idepartments<T> where T : class
        {
            IEnumerable<T> GetAllDepartment();
            IEnumerable<T> GetByDepartment( string T);
        }
    }
}
