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
        public IJobCategoryDataService JobCategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public List<Country> Countries { get; set; } = new List<Country>();
        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        public string CountryId { get; set; } = string.Empty;
        public string JobCategoryId { get; set; } = string.Empty;
        public CurrentState CurrentState { get; set; } = new CurrentState();

        protected async override Task OnInitializedAsync()
        {
            CurrentState.IsSaved = false;
            Countries = (await CountryDataService.GetAll()).ToList();
            JobCategories = (await JobCategoryDataService.GetAll()).ToList();

            int.TryParse(EmployeeId, out int id);
            if (id == 0)
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
            JobCategoryId = Employee.JobCategoryId.ToString();
        }

        protected async Task OnValidSubmit()
        {
            CurrentState.IsSaved = false;
            Employee.JobCategoryId = Convert.ToInt32(JobCategoryId);
            Employee.CountryId = Convert.ToInt32(CountryId);

            if (Employee.EmployeeId == 0)
            {
                var empl = await EmployeeDataService.Create(Employee);
                if (empl != null)
                {
                    CurrentState.Message = "A valuable person joined us :)";
                    CurrentState.AlertCssClass = "alert-success";
                    CurrentState.IsSaved = true;
                }
                else
                {
                    CurrentState.Message = "Aaa Houston! We have a problem!";
                    CurrentState.AlertCssClass = "alert-danger";
                    CurrentState.IsSaved = false;
                }
            }
            else
            {
                await EmployeeDataService.Update(Employee);
                CurrentState.IsSaved = true;
                CurrentState.Message = "We updated the data of this employee.";
                CurrentState.AlertCssClass = "alert-success";
            }
        }
        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.Delete(Employee.EmployeeId);
            CurrentState.AlertCssClass = "alert-success";
            CurrentState.Message = "We have a loss.";
            CurrentState.IsSaved = true;
        }
        protected void OnInvalidSubmit()
        {
            CurrentState.AlertCssClass = "alert-danger";
            CurrentState.Message = "It is necessary to check the information on the page.";
        }
        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}
