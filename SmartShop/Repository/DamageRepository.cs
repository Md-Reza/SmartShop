using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartShop.Interface.IDamageList;

namespace SmartShop.Repository
{
    public class DamageRepository : IDisposable, DamageInterface<DamageList>
    {
        SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            connection.Dispose();
        }

        public void ExecuteDamageEntry(List<DamageList> obj)
        {
            foreach (var item in obj)
            {
                connection.Open();
                connection.Execute("DamageListEntry_Sp", new
                {
                    @EntryDate = item.EntryDate,
                    @SalesMonth = item.SalesMonth,
                    @ProductCode=item.ProductCode,
                    @Qty = item.Qty,
                    @PurchasePrice = item.PurchasePrice,
                    @SellingPrice = item.SellingPrice,
                    @SalesAmount = item.SalesAmount,
                    @TotalAmount = item.TotalAmount,
                    @SellsBy = item.SellsBy,
                    @PcName = item.PcName,
                    @StatementType = "Create"
                },
                commandType: CommandType.StoredProcedure);

                connection.Close();
            }
        }

        public IEnumerable<DamageList> GetAllDamageEntry(string dateF, string dateT)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DamageList> GetByExpensesEntry(string id)
        {
            throw new NotImplementedException();
        }

        public void InsertDamageEntry(List<DamageList> obj)
        {
            throw new NotImplementedException();
        }
    }
}
