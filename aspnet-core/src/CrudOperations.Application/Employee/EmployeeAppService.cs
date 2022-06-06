using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Extensions;
using Abp.ObjectMapping;
using Abp.UI;
using CrudOperations.Department.Dto;
using CrudOperations.Employee.Dto;
using CrudOperations.Skill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations.Employee
{
    //[Route("/emp")]
    [AbpAuthorize]
    //[Authorize]
    public class EmployeeAppService:ApplicationService, IEmployeeAppService
    {
        private IRepository<Employee> repository;
        //private IRepository<CrudOperations.Department.Department> departmentRepository;
        private IObjectMapper objectMapper;
        public EmployeeAppService(IRepository<Employee> repository,IObjectMapper objectMapper,IRepository<CrudOperations.Department.Department> departmentRepository)
        {
            this.repository = repository;
            this.objectMapper = objectMapper;
            //this.departmentRepository=departmentRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        [Route("api/Employees/GetEmployeesList")]
        [AbpAllowAnonymous]
        //[AllowAnonymous]
        public IEnumerable<EmployeeDto> GetAllEmployees()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            IEnumerable<EmployeeDto> employees = repository.GetAll().Select(e => new EmployeeDto() { 
            
            Id=e.Id,
            Age=e.Age,
            Email=e.Email,
            Name=e.Name,
            Salary=e.Salary,
            //Skills=e.Skills.Select(s=>new SkillDto() { 
            //    Id=s.Id,
            //    Name=s.Name,
            //}).ToList(),
            DepartmentID=e.DepartmentID.GetValueOrDefault(),
            Department=new DepartmentDto() { Name=e.Department.Name} 
            //Department=new DepartmentDto() { Id=e.Department.Id,Name=e.Department.Name}
          
            }).ToList();
            return employees;
            

            //IEnumerable<Employee> employees = repository.GetAll().Include(e=>e.Department).ToList();
            //IEnumerable<EmployeeDto> employeesDto = objectMapper.Map<IEnumerable<EmployeeDto>>(employees);
            //return employeesDto;

        }

        //[HttpPost]
        [Route("api/Emp/GetEmployeeByID/{id}")]
        [AbpAllowAnonymous]
        public EmployeeDto GetById(int id = 2)
        {
            EmployeeDto employee = repository.GetAll().Select(e => new EmployeeDto() {
            Id=e.Id,
            Name=e.Name,
            Age=e.Age,
            Email=e.Email,
            Salary=e.Salary,
            DepartmentID=e.DepartmentID.GetValueOrDefault(),
            Department=new DepartmentDto()
            {
                Name=e.Department.Name
            },
            //Skills=e.Skills.Select(s=>new SkillDto() { Id=s.Id,Name=s.Name}).ToList()
            
            }).FirstOrDefault(e => e.Id == id);
            return employee;

            ////Employee employee = repository.GetAll().FirstOrDefault(e => e.Id == id);
            //Employee employee=repository.GetAll().Include(e=>e.Department).FirstOrDefault(e => e.Id == id);
            //EmployeeDto employeeDto = objectMapper.Map<EmployeeDto>(employee);
            ////employee.Department = departmentRepository.GetAll().FirstOrDefault(d => d.Id == employee.Department.Id);
            //return employeeDto;
        }

        //public Employee GetById(int id = 2)
        //{
        //    Employee employee = repository.GetAll().FirstOrDefault(e => e.Id == id);
        //    return employee;
        //}

        //public EmployeeDto GetById(int id = 2)
        //{
        //    Employee employee = repository.GetAll().FirstOrDefault(e => e.Id == id);
        //    employee.Department = departmentRepository.GetAll().FirstOrDefault(d => d.Id == employee.DepartmentID);
        //    EmployeeDto employeeDto = objectMapper.Map<EmployeeDto>(employee);
        //    return employeeDto;
        //}

    [AbpAllowAnonymous]    
        public IEnumerable<EmployeeDto> GetEmployeesByDepartmentID(int departmentId=1)
        {
            //IEnumerable<NewEmployeeDto> Employees = repository.GetAll().Where(e => e.DepartmentID == departmentId)
            //    .Select(e => new NewEmployeeDto()
            //    {
            //        Age = e.Age,
            //        FullName = e.Name,
            //        Salary = e.Salary,
            //        Department = new DepartmentDto() { Id=e.Department.Id,Name=e.Department.Name}
            //    }).ToList();
            //return Employees;


            IEnumerable<Employee> employees = repository.GetAll().Include(e => e.Department)
                .Where(e => e.Department.Id == departmentId).ToList();
            IEnumerable<EmployeeDto> employeesDto = ObjectMapper.Map<IEnumerable<EmployeeDto>>(employees);
            return employeesDto;
        }
        



        [HttpGet]
        [AbpAuthorize("AddEmployees")]
        
        [Route("api/Employees/AddNewEmployee")]
        public bool InsertEmployee(InsertEmployeeDto employeeDto)
        {
            try
            {
                Employee employee = objectMapper.Map<Employee>(employeeDto);
                repository.Insert(employee);
                return true;

            }
            catch (Exception e)
            {
                throw new UserFriendlyException(400, "Wrong");

            }

        }

        [Route("api/Employees/EditEmployee")]
        [HttpPut]
        [AbpAuthorize("AddEmployees")]
        public void UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            try
            {
                
                Employee employee = objectMapper.Map<Employee>(employeeDto);
                repository.Update(employee);
            }
            catch(Exception e)
            {
                throw new UserFriendlyException("Something wrong");
            }

        }

        [Route("api/Employees/RemoveEmployee")]
        [HttpDelete]
        //[HttpDelete("{id}")]
        public void DeleteEmployee(int id)
        {
            Employee employee = repository.GetAll().FirstOrDefault(e => e.Id == id);
            repository.Delete(employee);
        }

    }
}
