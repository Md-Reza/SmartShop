using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static SmartShop.Interface.Interface;

namespace SmartShop.Repository
{

    public  class EmployeeRepository:IDisposable, IBaseRepository<EmployeeInformation>
    {

        SqlConnection _sqlConnection;
       // SqlDataAdapter _sqlDataAdapter;
       // SqlCommand _sqlCommand;
       // DataTable _dt;

        // IBaseRepository<EmployeeInformation> baseRepository = new EmployeeRepository();
        public void UserRepository()
        {
            _sqlConnection = new SqlConnection(Connection.GetConnectionString());
        }
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _sqlConnection.Dispose();
        }

        public IEnumerable<EmployeeInformation> Get()
        {
            throw new NotImplementedException();
        }

        public EmployeeInformation Get(object id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            try
            {
                DataTable dt = new DataTable();
                _sqlConnection = new SqlConnection(Connection.GetConnectionString());
                string query = "select * from EmployeeInformation";
                SqlCommand commad = new SqlCommand(query, _sqlConnection);

                _sqlConnection.Open();
                SqlDataAdapter dr = new SqlDataAdapter(commad);

                dr.Fill(dt);
                _sqlConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        //public DataTable GetAll()
        //{
        //    throw new NotImplementedException();
        //}
        public void Insert(EmployeeInformation user)
        {
            SqlConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Open();
            connection.Execute("EmployeeInformation_sp", new
            {@AccountCode= user.AccountCode,@UserName=user.UserName,@UserEmail=user.UserEmail,@FirstName=user.FirstName,
                @LastName=user.LastName,@FullName=user.FullName,@ReportingPerson=user.ReportingPerson,@MobileNo=user.MobileNo
                ,@DeviceName=user.DeviceName,@DeviceQty=user.DeviceQty,@IMEINo=user.IMEINo,@ProfilePhoto=user.Photo,@Department=user.DepartmentCode,
                @Designation=user.DesiCode,@BasicSalary=user.BasicSalary,@HouseRent=user.HouseRent,@MedicalAllonce=user.MedicalAllonce,@DainingAllonce=user.DainingAllonce, @StatementType = "Create" }, commandType: CommandType.StoredProcedure);
            connection.Close();
        }

        public void Update(EmployeeInformation obj)
        {
            throw new NotImplementedException();
        }

        public EmployeeInformation GetByAll(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeInformation> All(object id)
        {
            throw new NotImplementedException();
        }
    }

}
