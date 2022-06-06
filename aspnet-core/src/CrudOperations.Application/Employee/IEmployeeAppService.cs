using Abp.Application.Services;
using CrudOperations.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations.Employee
{
    public interface IEmployeeAppService:IApplicationService
    {
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDto GetById(int id);
        IEnumerable<EmployeeDto> GetEmployeesByDepartmentID(int departmentId);
        bool InsertEmployee(InsertEmployeeDto employeeDto);
        void UpdateEmployee(UpdateEmployeeDto employeeDto);
        void DeleteEmployee(int id);
    }
}
