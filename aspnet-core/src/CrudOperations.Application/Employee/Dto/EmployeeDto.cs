using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using CrudOperations.Department.Dto;
using CrudOperations.Skill;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CrudOperations.Employee.Dto
{
    //[AutoMapFrom(typeof(Employee))]
    public class EmployeeDto:EntityDto//,ISoftDelete
    {
 
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }

        public string Email { get; set; }
        public int DepartmentID { get; set; }
        //[JsonIgnore]
        public DepartmentDto Department { get; set; }
        //public virtual ICollection<SkillDto> Skills { get; set; }




        //public bool IsDeleted { get; set; }
    }
}
