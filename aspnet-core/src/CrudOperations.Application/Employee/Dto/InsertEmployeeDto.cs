using Abp.AutoMapper;
using Abp.Domain.Entities;
using CrudOperations.Department.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations.Employee.Dto
{
    [AutoMapTo(typeof(Employee))]
    public class InsertEmployeeDto
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
        //[ForeignKey("DepartmentID")]
        //public CrudOperations.Department.Department Department { get; set; }

    }
}
