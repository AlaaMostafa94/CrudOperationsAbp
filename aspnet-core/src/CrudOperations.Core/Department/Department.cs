using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CrudOperations.Department
{
    public class Department:Entity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        //[JsonIgnore]
        public virtual ICollection<CrudOperations.Employee.Employee> Employees { get; set; }
    }
}
