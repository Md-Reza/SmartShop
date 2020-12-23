using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static SmartShop.Interface.Interface;

namespace SmartShop.Repository
{
    public class UserLoginRepository : IDisposable, IBaseRepository<UserLogin>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            _connection.Close();
        }
        public IEnumerable<UserLogin> Get()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            IEnumerable<UserLogin> returnValue = connection.Query<Models.UserLogin>(@"Select * from UserLogin");
            connection.Close();
            return returnValue;
        }
        public DataTable GetAllUser()
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            DataTable dt = Connection.GetDataTable("Select * from UserLogin ");
            connection.Close();
            return dt;
        }

        public bool UserValidation(string LoginName, string password)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            bool flag = false;
            IEnumerable<Models.UserLogin> returnValue = connection.Query<Models.UserLogin>(@"Select * from UserLogin where LoginName = @LoginName and password = @password and UserStatus=1", new { LoginName, password });
            connection.Close();
            if (returnValue.Count() == 1)
                flag = true;
            else
                flag = false;
            return flag;
        }

        public UserLogin Get(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(UserLogin obj)
        {
            throw new NotImplementedException();
        }

        public void Update(UserLogin obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            string query = @"Select * from UserLogin";
            SqlCommand commad = new SqlCommand(query, connection);

            connection.Open();
            SqlDataAdapter dr = new SqlDataAdapter(commad);

            dr.Fill(dt);
            connection.Close();
            return dt;
        }
        public IEnumerable<UserLogin> All(object id)
        {
            throw new NotImplementedException();
        }
    }
}
