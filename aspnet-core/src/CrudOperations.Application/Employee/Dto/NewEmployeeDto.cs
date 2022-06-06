using Abp.AutoMapper;
using CrudOperations.Department.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations.Employee.Dto
{
    //[AutoMapFrom(typeof(Employee))]
    public class NewEmployeeDto
    {
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public int DepartmentID { get; set; }

        public DepartmentDto Department { get; set; }

    }
}
