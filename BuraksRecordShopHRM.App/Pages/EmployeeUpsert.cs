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

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public List<Country> Countries { get; set; } = new List<Country>();

        public string CountryId { get; set; }
        public CurrentState CurrentState { get; set; } = new CurrentState();

        protected async override Task OnInitializedAsync()
        {
            CurrentState.IsSaved = false;
            Countries = (await CountryDataService.GetAll()).ToList();
            int.TryParse(EmployeeId, out int id);
            if(id==0)
            {
                Employee = new Employee
                {
                    CountryId = 1,
                    JobCategoryId = 1,
                    BirthDate = DateTime.Now,
                    JoinedDate = DateTime.Now
                };
            }
            else
            {
                Employee = await EmployeeDataService.GetDetail(id);
            }
            
            CountryId = Employee.CountryId.ToString();
        }

        protected void OnValidSubmit()
        {
            //TODO@Burak Yazılacak
        }
        protected void OnInvalidSubmit()
        {
            //TODO@Burak Yazılacak
        }

        protected void DeleteEmployee()
        {
            //TODO@Burak Yazılacak
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}
