using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CrudOperations.Employee.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CrudOperations.Department.Dto
{
    [AutoMapFrom(typeof(Department))]
   
    public class DepartmentDto:EntityDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        //[JsonIgnore]
        public ICollection<EmployeeDto> Employees { get; set; }
    }
}
