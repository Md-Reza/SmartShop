using Dapper;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SmartShop.SmartReports.ReportsRepositories
{
    public class ReportsRepository : IReports
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Reports> Get()
        {
            throw new NotImplementedException();
        }

        public Models.Reports GetBy(string key)
        {
            throw new NotImplementedException();
        }

        public Models.Reports GetBy(string key, string settingValue)
        {
            _connection.Open();
            Models.Reports returnValues = _connection.QueryFirstOrDefault<Models.Reports>(@"Select * from Reports where IsActivated = 1 and ReportIdentity = @ReportIdentity and SettingValue = @SettingValue;", new { @ReportIdentity = key, @SettingValue = settingValue });
            _connection.Close();
            return returnValues;
        }

        public bool HasFooter(string key, string settingValue)
        {
            throw new NotImplementedException();
        }

        public bool HasHeader(string key, string settingValue)
        {
            throw new NotImplementedException();
        }

        public bool IsActivated(string key, string settingValue)
        {
            throw new NotImplementedException();
        }
    }
}
