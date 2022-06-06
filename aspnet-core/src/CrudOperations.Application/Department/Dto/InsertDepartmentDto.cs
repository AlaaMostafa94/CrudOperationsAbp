using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations.Department.Dto
{
    [AutoMapTo(typeof(Department))]
    public class InsertDepartmentDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
