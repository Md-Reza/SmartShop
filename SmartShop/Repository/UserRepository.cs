using Dapper;
using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static SmartShop.Interface.IUserRegistration;

namespace SmartShop.Repository
{
    public class UserRepository : IDisposable, IBaseUserRegistration<EmployeeInformation>
    {
        SqlConnection _connection = new SqlConnection(Connection.GetConnectionString());
        public void Dispose()
        {
            _connection.Close();
        }
        public void ExecuteUpdateUserRegistration(EmployeeInformation obj)
        {
            _connection.Open();
            _connection.Execute("EmployeeInformation_sp", new
            {
                @AccountCode = obj.AccountCode,
                @UserName = obj.UserName,
                @Password = obj.Password,
                @ConfirmPassword = obj.ConfirmPassword,
                @UserEmail = obj.UserEmail,
                @FirstName = obj.FirstName,
                @LastName = obj.LastName,
                @FullName = obj.FullName,
                @PresentAddress = obj.PresentAddress,
                @PermanentAddress = obj.PermanentAddress,
                @ReportingPerson = obj.ReportingPerson,
                @MobileNo = obj.MobileNo,
                @DeviceName = obj.DeviceName,
                @DeviceQty = obj.DeviceQty,
                @IMEINo = obj.IMEINo,
                @Photo = obj.Photo,
                @DepartmentCode = obj.DepartmentCode,
                @DesiCode = obj.DesiCode,
                @BasicSalary = obj.BasicSalary,
                @HouseRent = obj.HouseRent,
                @MedicalAllonce = obj.MedicalAllonce,
                @DainingAllonce = obj.DainingAllonce,
                @CreateBy = obj.CreateBy,
                @UserStatus = obj.UserStatus,
                @StatementType = "Update"
            }, commandType: CommandType.StoredProcedure);
            _connection.Close();
        }

        public void ExecuteUserRegistration(EmployeeInformation obj)
        {
            _connection.Open();
            _connection.Execute("EmployeeInformation_sp", new
            {
                @AccountCode=obj.AccountCode,
                @UserName = obj.UserName,
                @Password=obj.Password,
                @ConfirmPassword=obj.ConfirmPassword,
                @UserEmail = obj.UserEmail,
                @FirstName = obj.FirstName,
                @LastName = obj.LastName,
                @FullName = obj.FullName,
                @PresentAddress = obj.PresentAddress,
                @PermanentAddress = obj.PermanentAddress,
                @ReportingPerson = obj.ReportingPerson,
                @MobileNo = obj.MobileNo,
                @DeviceName = obj.DeviceName,
                @DeviceQty = obj.DeviceQty,
                @IMEINo = obj.IMEINo,
                @Photo = obj.Photo,
                @DepartmentCode = obj.DepartmentCode,
                @DesiCode = obj.DesiCode,
                @BasicSalary = obj.BasicSalary,
                @HouseRent = obj.HouseRent,
                @MedicalAllonce = obj.MedicalAllonce,
                @DainingAllonce = obj.DainingAllonce,
                @CreateBy=obj.CreateBy,
                @UserStatus=obj.UserStatus,
                @StatementType = "Create"
            }, commandType: CommandType.StoredProcedure);
            _connection.Close();
        }
        public IEnumerable<EmployeeInformation> GetAllUserRegistration()
        {
            _connection.Open();
            IEnumerable<EmployeeInformation> customerInformation = _connection.Query<EmployeeInformation>("select * from EmployeeInformation ");
            _connection.Close();
            return customerInformation;
        }
        public IEnumerable<EmployeeInformation> GetByUserRegistration(string AccountCode)
        {
            _connection.Open();
            IEnumerable<EmployeeInformation> customerInformation = _connection.Query<EmployeeInformation>("select * from EmployeeInformation where AccountCode=@AccountCode", new { AccountCode = @AccountCode });
            _connection.Close();
            return customerInformation;
        }
        public void InsertUserRegistration(List<EmployeeInformation> obj)
        {
            throw new NotImplementedException();
        }
    }
}
