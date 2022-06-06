using Abp.Application.Services;
using CrudOperations.Department.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations.Department
{
    public interface IDepartmentAppService:IApplicationService
    {
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDto GetDepartmentByID(int id);
        DepartmentDto GetDeptByID(int id);
        DepartmentDto GetByID(int id);
        void InsertDepartment(InsertDepartmentDto departmentDto);
        void UpdateDepartment(UpdateDepartmentDto departmentDto);
    }
}
