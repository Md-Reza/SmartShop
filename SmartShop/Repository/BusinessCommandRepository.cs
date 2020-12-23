using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.BusinessInterface;

namespace SmartShop.Repository
{
    public class BusinessCommandRepository : IDisposable, IBusinessCommand<ObjectCommand>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            _connection.Close();
        }

        public void ExecuteBusinessCommand(ObjectCommand obj)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("ObjectCommand_sp", new
            {
                @BusinessObjectCode=obj.BusinessObjectCode,
                @BusinessObjectName = obj.BusinessObjectName,
                @ObjectFormName = obj.ObjectFormName,
                @UserId = obj.UserId,
                @Permisson = obj.Permisson,
                @CreateBy = obj.CreateBy,
                @StatementType = "Create"
            }, commandType: CommandType.StoredProcedure);

            connection.Close();
        }

        public void ExecuteDeleteBusinessCommand(ObjectCommand obj)
        {
            throw new NotImplementedException();
        }

        public void ExecuteUpdateBusinessCommand(ObjectCommand obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObjectCommand> GetAllBusinessCommand()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<ObjectCommand> returnValue = connection.Query<Models.ObjectCommand>(@"select * from BusinessObjects");
            connection.Close();
            return returnValue;
        }

        public void InsertBusinessCommand(List<ObjectCommand> obj2)
        {
            foreach (var items in obj2)
            {
                ExecuteBusinessCommand(items);
            }
        }

        public IEnumerable<ObjectCommand> GetByBusinessCommand(object UserId)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<ObjectCommand> returnValue = connection.Query<Models.ObjectCommand>(@"select * from ObjectCommand where UserId=@UserId", new{ UserId= @UserId});
            connection.Close();
            return returnValue;
        }

        public IEnumerable<ObjectCommand> GetByCommandPermissonCheck(object UserId,string Name)
        {
            _connection.Open();
            IEnumerable<ObjectCommand> returnValue = _connection.Query<Models.ObjectCommand>(@"select * from ObjectCommand where LoginName=@LoginName and ObjectFormName=@ObjectFormName and Permisson=1", new { LoginName = @UserId , ObjectFormName =@Name});
            _connection.Close();
            return returnValue;
        }
    }
}
