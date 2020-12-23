using System.Collections.Generic;

namespace SmartShop.Interface
{
    public sealed class BusinessInterface
    {
        public interface IBusinessCommand<T> where T : class
        {
            IEnumerable<T> GetAllBusinessCommand();
            IEnumerable<T> GetByBusinessCommand(object UserId);
            IEnumerable<T> GetByCommandPermissonCheck(object UserId,string Name);
            void ExecuteBusinessCommand(T obj);
            void ExecuteDeleteBusinessCommand(T obj);
            void ExecuteUpdateBusinessCommand(T obj);
        }
    }
}
