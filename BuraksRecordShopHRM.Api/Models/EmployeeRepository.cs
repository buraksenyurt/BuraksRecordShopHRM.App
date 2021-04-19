using BuraksRecordShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuraksRecordShopHRM.Api.Models
{
    public class EmployeeRepository
        : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Employee Add(Employee employee)
        {
            var addedEntity = _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void Delete(int employeeId)
        {
            var founded = _appDbContext
                .Employees
                .FirstOrDefault(e => e.EmployeeId == employeeId);

            if (founded == null) 
                return;

            _appDbContext.Employees.Remove(founded);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _appDbContext.Employees;
        }

        public Employee GetById(int employeeId)
        {
            return _appDbContext
                .Employees
                .FirstOrDefault(c => c.EmployeeId == employeeId);
        }

        public Employee Update(Employee employee)
        {
            var founded = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

            if (founded != null)
            {
                founded.CountryId = employee.CountryId;
                founded.BirthDate = employee.BirthDate;
                founded.Email = employee.Email;
                founded.FirstName = employee.FirstName;
                founded.LastName = employee.LastName;
                founded.JobCategoryId = employee.JobCategoryId;
                founded.ExitDate = employee.ExitDate;
                founded.JoinedDate = employee.JoinedDate;

                _appDbContext.SaveChanges();

                return founded;
            }
            return null;
        }
    }
}
