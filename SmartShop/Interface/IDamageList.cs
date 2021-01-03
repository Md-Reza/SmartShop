using System.Collections.Generic;

namespace SmartShop.Interface
{
    public sealed class IDamageList
    {
        public interface DamageInterface<T> where T : class
        {
            IEnumerable<T> GetAllDamageEntry(string dateF, string dateT);
            IEnumerable<T> GetByExpensesEntry(string id);
            void ExecuteDamageEntry(List<T> obj);
            void InsertDamageEntry(List<T> obj);
        }
    }
}
