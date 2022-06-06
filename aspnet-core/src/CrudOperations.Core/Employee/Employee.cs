using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CrudOperations.Employee
{
    public class Employee:Entity,ISoftDelete
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Employee name required")]
        [MaxLength(200)]
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Email required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(200)]
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CrudOperations.Department.Department Department { get; set; }
        [ForeignKey("Department")]
        public virtual int? DepartmentID { get; set; }
        //[JsonIgnore]
        public virtual ICollection<CrudOperations.Skill.Skill> Skills { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
