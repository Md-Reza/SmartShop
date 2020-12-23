using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartShop.Interface
{
    public sealed class BankTransactionInterface
    {
        public interface IBankTransaction<T> where T : class
        {
            IEnumerable<BankTransaction> GetAllBankTransction();
            IEnumerable<BankTransaction> GetAllBankTransctionDate(string dateF, string dateT);
            IEnumerable<BankTransaction> GetAllBankTransctionByBank(object BankId);
            void ExecuteBankTranscation(T obj);
        }
    }
}
