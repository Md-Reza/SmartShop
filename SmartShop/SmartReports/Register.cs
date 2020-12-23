using SmartShop.Models;
using System;
using System.Collections.Generic;

namespace SmartShop.SmartReports
{
    public  interface Register
    {
        IEnumerable<SellesChild> GetAllSalesByDate(DateTime SellsDateF, DateTime SellsDateT);
        IEnumerable<SalesRegister> GetAllPurchaseByDate(string SellsDateF, string SellsDateT);
        IEnumerable<ArrearCollection> GetAllDueCollectionByDate(string SellsDateF, string SellsDateT);
        IEnumerable<CustomerArrear> GetAllCustomerArrear();
        IEnumerable<ExpensesEntry> GetAllExpensesByDate(string SellsDateF, string SellsDateT);


    }
}
