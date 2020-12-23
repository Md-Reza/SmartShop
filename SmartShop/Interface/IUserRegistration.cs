using System.Collections.Generic;

namespace SmartShop.Interface
{
    public sealed class IUserRegistration
    {
        public interface IBaseUserRegistration<T> where T : class
        {
            IEnumerable<T> GetAllUserRegistration();
            IEnumerable<T> GetByUserRegistration(string id);
            void ExecuteUserRegistration(T obj);
            void InsertUserRegistration(List<T> obj);
            void ExecuteUpdateUserRegistration(T obj);
        }
    }
}
