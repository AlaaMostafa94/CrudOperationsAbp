using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations.Skill
{
    public class Skill:Entity<int>
    {
        public string Name { get; set; }
        public virtual CrudOperations.Employee.Employee Employee { get; set; }
    }
}
