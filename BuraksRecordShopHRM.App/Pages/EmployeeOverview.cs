using BuraksRecordShopHRM.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuraksRecordShopHRM.App.Pages
{
    public partial class EmployeeOverview
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<JobCategory> JobCategories { get; set; }

        protected override Task OnInitializedAsync()
        {
            Countries = DataLoader.LoadCountries();
            JobCategories = DataLoader.LoadJobs();
            Employees = DataLoader.LoadEmployees();

            return base.OnInitializedAsync();
        }
    }
}
