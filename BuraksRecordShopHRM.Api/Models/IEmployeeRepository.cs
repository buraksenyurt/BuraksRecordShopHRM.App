using BuraksRecordShopHRM.Shared;
using System.Collections.Generic;

namespace BuraksRecordShopHRM.Api.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int employeeId);
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        void Delete(int employeeId);
    }
}
