using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CrudOperations.Authorization.Roles;
using CrudOperations.Authorization.Users;
using CrudOperations.MultiTenancy;


namespace CrudOperations.EntityFrameworkCore
{
    public class CrudOperationsDbContext : AbpZeroDbContext<Tenant, Role, User, CrudOperationsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<CrudOperations.Employee.Employee> Employees { get; set; }
        public DbSet<CrudOperations.Department.Department> Departments { get; set; }
        public DbSet<CrudOperations.Skill.Skill> Skills { get; set; }
        public CrudOperationsDbContext(DbContextOptions<CrudOperationsDbContext> options)
            : base(options)
        {
        }
    }
}
