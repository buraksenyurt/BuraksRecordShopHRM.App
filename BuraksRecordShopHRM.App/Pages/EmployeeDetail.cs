using BuraksRecordShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuraksRecordShopHRM.App.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public string SearchingID { get; set; }
        public Employee CurrentEmployee { get; set; } = new Employee();

        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<JobCategory> JobCategories { get; set; }
        protected override Task OnInitializedAsync()
        {
            Countries = DataLoader.LoadCountries();
            JobCategories = DataLoader.LoadJobs();
            Employees = DataLoader.LoadEmployees();

            CurrentEmployee = Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(SearchingID));

            return base.OnInitializedAsync();
        }
    }
}
