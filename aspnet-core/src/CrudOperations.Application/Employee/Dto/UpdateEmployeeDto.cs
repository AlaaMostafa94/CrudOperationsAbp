using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CrudOperations.Department.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations.Employee.Dto
{
    [AutoMapTo(typeof(Employee))]
    public class UpdateEmployeeDto:EntityDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee name required")]
        [MaxLength(200)]
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(200)]
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        //public UpdateDepartmentDto Department { get; set; }
    }
}
