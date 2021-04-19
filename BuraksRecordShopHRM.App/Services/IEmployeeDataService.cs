using BuraksRecordShopHRM.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuraksRecordShopHRM.App.Services
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetDetail(int employeeId);
        Task<Employee> Create(Employee employee);
        Task Update(Employee employee);
        Task Delete(int employeeId);
    }
}
