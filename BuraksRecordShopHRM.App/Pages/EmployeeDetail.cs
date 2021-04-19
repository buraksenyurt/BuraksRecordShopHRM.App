using BuraksRecordShopHRM.App.Services;
using BuraksRecordShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BuraksRecordShopHRM.App.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public string SearchingID { get; set; }
        public Employee CurrentEmployee { get; set; } = new Employee();

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        //public IEnumerable<Employee> Employees { get; set; }
        //public IEnumerable<Country> Countries { get; set; }
        //public IEnumerable<JobCategory> JobCategories { get; set; }
        protected async override Task OnInitializedAsync()
        {
            CurrentEmployee = await EmployeeDataService.GetDetail(Convert.ToInt32(SearchingID));
            //Countries = DataLoader.LoadCountries();
            //JobCategories = DataLoader.LoadJobs();
            //Employees = DataLoader.LoadEmployees();

            //CurrentEmployee = Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(SearchingID));

            //return base.OnInitializedAsync();
        }
    }
}
