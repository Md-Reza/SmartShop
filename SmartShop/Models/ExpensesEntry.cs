using System;

namespace SmartShop.Models
{
    public class ExpensesEntry
    {
        public int ExpensEntryId { get; set; }
        public DateTime EntryDate { get; set; }
        public string SalesMonth { get; set; }
        public int ExpnsId { get; set; }
        public string ExpnsName { get; set; }
        public int ExpenseAmount { get; set; }
        public string Remarks { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDateTime { get; set; }
        public ExpensesList ExpensesList { get; set; }
    }
}
