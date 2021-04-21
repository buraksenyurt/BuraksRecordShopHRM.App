using BuraksRecordShopHRM.App.Services;
using BuraksRecordShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuraksRecordShopHRM.App.Pages
{
    public partial class EmployeeUpsert
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public ICountryDataService CountryDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public List<Country> Countries { get; set; } = new List<Country>();

        public string CountryId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetDetail(Convert.ToInt32(EmployeeId));
            Countries = (await CountryDataService.GetAll()).ToList();
            CountryId = Employee.CountryId.ToString();
        }
    }
}
