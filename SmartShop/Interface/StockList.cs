using System.Collections.Generic;

namespace SmartShop.Interface
{
   public sealed class StockList
    {
        public interface IStockList<T> where T : class
        {
            IEnumerable<T> GetAllSupplyer();
            T GetAllSupplyer(object id);
            IEnumerable<T> GetAllStockListBySupllyer(object T);
            IEnumerable<T> GetAllStockList();
            IEnumerable<T> GetByStockListProductCode(string T);
        }
    }
}
