using Dapper;
using SmartShop.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SmartShop.Repository
{
    public class GetByAllSequence
    {
        public IEnumerable<SequencePopulate> GetByAll()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            IEnumerable<SequencePopulate> returnValue = connection.Query<SequencePopulate>(@"Select * from SequencePopulate ");
            connection.Close();
            return returnValue;
        }
    }
}
