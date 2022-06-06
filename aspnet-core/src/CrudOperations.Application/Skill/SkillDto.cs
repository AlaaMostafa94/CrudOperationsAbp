using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations.Skill
{
    public class SkillDto:EntityDto<int>
    {
        public string Name { get; set; }
        public virtual CrudOperations.Employee.Employee Employee { get; set; }
    }
}
