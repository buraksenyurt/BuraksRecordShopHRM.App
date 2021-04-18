using BuraksRecordShopHRM.Shared;
using System;
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
            LoadCountries();
            LoadJobs();
            LoadEmployees();

            return base.OnInitializedAsync();
        }

        private void LoadJobs() => JobCategories = new List<JobCategory>
            {
                new JobCategory{JobCategoryId=1,Name="Research Lab" },
                new JobCategory{JobCategoryId=2,Name="Finance" },
                new JobCategory{JobCategoryId=3,Name="IT" },
                new JobCategory{JobCategoryId=4,Name="Shop Assistant" },
                new JobCategory{JobCategoryId=5,Name="Store Staff" },
            };

        private void LoadCountries() => Countries = new List<Country>
            {
                new Country{CountryId=1,Name="Germany"},
                new Country{CountryId=2,Name="England"},
                new Country{CountryId=3,Name="Turkey"},
                new Country{CountryId=4,Name="Portugal"},
                new Country{CountryId=5,Name="Spain"},
            };

        private void LoadEmployees() => Employees = new List<Employee>
            {
                new Employee{ EmployeeId=1,FirstName="Junger",LastName="Klöp", BirthDate=new DateTime(1967,4,12), CountryId=1, JobCategoryId=1},
                new Employee{ EmployeeId=2,FirstName="Aleksa",LastName="Bröger", BirthDate=new DateTime(1974,1,11), CountryId=1, JobCategoryId=3},
                new Employee{ EmployeeId=3,FirstName="Burak",LastName="Selim", BirthDate=new DateTime(1976,4,12), CountryId=3, JobCategoryId=2},
                new Employee{ EmployeeId=4,FirstName="Camelia Oscar De La",LastName="Fuante Garcia Velazques", BirthDate=new DateTime(1985,3,8), CountryId=5, JobCategoryId=4}
            };
    }
}
