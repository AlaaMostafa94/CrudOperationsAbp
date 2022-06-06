using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using CrudOperations.Department.Dto;
using CrudOperations.Employee.Dto;
using CrudOperations.EntityFrameworkCore;
using CrudOperations.Skill;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations.Department
{
    public class DepartmentAppService:IDepartmentAppService
    {
        private IRepository<Department> repository;
        private IObjectMapper objectMapper;
        public DepartmentAppService(IRepository<Department> repository,IObjectMapper objectMapper)
        {
            this.repository = repository;
            this.objectMapper = objectMapper;
        }

        //public IEnumerable<DepartmentDto> GetAllDepartments()
        //{

        //    //IEnumerable<Department> departments = repository.GetAll().Include(d=>d.Employees).ToList();
        //    IEnumerable<Department> departments = repository.GetAll().Include(d=>d.Employees).ToList();
        //    IEnumerable<DepartmentDto> departmentDto = objectMapper.Map<IEnumerable<DepartmentDto>>(departments);
        //    return departmentDto;

        //}

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            IEnumerable<DepartmentDto> departments = repository.GetAll().Select(s=>new DepartmentDto() {
            Id=s.Id,
            Name=s.Name,
            Employees=s.Employees.Select(e=>new EmployeeDto() { 
            Id=e.Id,
            Name=e.Name,
            Age=e.Age,
            Email=e.Email,
            Salary=e.Salary,
            //Skills=e.Skills.Select(s=>new SkillDto() { 
            //Name=s.Name
            //}).ToList()
         
            
            }).ToList()}).ToList();

            
            return departments;

            
        }
        [AbpAuthorize("TestPermission")]
        public DepartmentDto GetDepartmentByID(int id=1)
        {
            //Explicit Loading
            DepartmentDto department = repository.GetAll().Include(d => d.Employees)
                .Select(d => new DepartmentDto()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Employees = d.Employees.Select(e => new EmployeeDto()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Age = e.Age,
                        Email = e.Email,
                        Salary = e.Salary,
                        DepartmentID = e.DepartmentID.GetValueOrDefault(),
            

                    }).ToList()
                }).FirstOrDefault(d => d.Id == id);
            return department;


                    //IEnumerable<Department> departments = new List<Department>();
                    //IEnumerable<IEnumerable<CrudOperations.Employee.Employee>> employeesLists = departments.Select(d => d.Employees);
                    //IEnumerable<CrudOperations.Employee.Employee> employees = departments.SelectMany(d => d.Employees);





            //return department;

            //Department department = repository.GetAll().Include(d => new List<EmployeeDto>(d.Employees.Select(e=>e.Name).ToList())).FirstOrDefault();
            //DepartmentDto departmentDto = objectMapper.Map<DepartmentDto>(department);
            //return departmentDto;



            //Department department = repository.GetAll().Include(d => d.Employees=new CrudOperations.Employee.Employee() { 
            //Id=d.

            //}).FirstOrDefault(d => d.Id == id);




            //Department department = repository.GetAll().Include(d=>d.Employees).FirstOrDefault(d => d.Id == id);
            //DepartmentDto departmentDto = objectMapper.Map<DepartmentDto>(department);
            //return departmentDto;
        }

        public DepartmentDto GetDeptByID(int id=1)
        {

            //Lazy Loading
            DepartmentDto department = repository.GetAll().Select(d => new DepartmentDto()
            {
                Employees = d.Employees.Select(e => new EmployeeDto()
                {
                    Name = e.Name,
                    Id = e.Id,
                    Age = e.Age,
                    Email = e.Email,
                    Salary = e.Salary

                }).ToList(),
                Id = d.Id,
                Name = d.Name
            }).FirstOrDefault(d => d.Id == id);
            return department;


        }

        public DepartmentDto GetByID(int id = 1)
        {
            //Eager Loading
            DepartmentDto department = repository.GetAll().ToList().Select(d => new DepartmentDto()
            {
                Id = d.Id,
                Name = d.Name
            }).FirstOrDefault(d => d.Id == id);

            return department;
        }




        public void InsertDepartment(InsertDepartmentDto departmentDto)
        {
            Department department = objectMapper.Map<Department>(departmentDto);
            repository.Insert(department);
        }
        public void UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            Department department = objectMapper.Map<Department>(departmentDto);
            repository.Update(department);
        }
    }
}
