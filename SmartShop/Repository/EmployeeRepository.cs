using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartShop.Models;
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
            {@AccountCode= user.AccountCode,@UserName=user.UserName,@UserEmail=user.UserEmail,@Password=user.Password,@ConfirmPassword=user.ConfirmPassword,@FirstName=user.FirstName,
                @LastName=user.LastName,@FullName=user.FullName,@EmployeeId=user.EmployeeId,@ReportingPerson=user.ReportingPerson,@OfficeLocation=user.OfficeLocation,@MobileNo=user.MobileNo,
                @IpPhone=user.IpPhone,@DeviceName=user.DeviceName,@DeviceQty=user.DeviceQty,@DeviceSerial=user.DeviceSerial,@IMEINo=user.DeviceIMEINo1,@ProfilePhoto=user.ProfilePhoto,@Department=user.Department,
                @Designation=user.Designation,@BasicSalary=user.BasicSalary,@HouseRent=user.HouseRent,@MedicalAllonce=user.MedicalAllonce,@DainingAllonce=user.DainingAllonce, @StatementType = "Create" }, commandType: CommandType.StoredProcedure);
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
