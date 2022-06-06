using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations.Department.Dto
{
    [AutoMapTo(typeof(Department))]
    public class UpdateDepartmentDto:EntityDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
