using SmartShop.Models;
using System.Collections.Generic;

namespace SmartShop.Interface
{
    public sealed class BankInterface
    {
        public interface IBank  <T> where T : class
        {
            IEnumerable<Bank> GetAllBank();
            IEnumerable<Bank> GetByBankId(object BankId);
            void ExecuteBankEntry(T obj);
            void UpdateEntry(T obj);

        }
    }
}
