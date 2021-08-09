using System.Collections.Generic;

namespace SmartShop.Interface
{
    public sealed class ISalesReturn
    {
        public interface IReturn <T> where T : class
        {
            IEnumerable<T> GetAllInvoice();
            IEnumerable<T> GetByInvoice( string T);
            IEnumerable<T> GetByReturnInvoice(string T);
            void ExecuteSalesReturnEntry(T obj);

        }
    }
}
