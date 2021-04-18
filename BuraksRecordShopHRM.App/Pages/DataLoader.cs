using BuraksRecordShopHRM.Shared;
using System;
using System.Collections.Generic;

namespace BuraksRecordShopHRM.App.Pages
{
    public static class DataLoader
    {
        public static IEnumerable<JobCategory> LoadJobs() => new List<JobCategory>
            {
                new JobCategory{JobCategoryId=1,Name="Research Lab" },
                new JobCategory{JobCategoryId=2,Name="Finance" },
                new JobCategory{JobCategoryId=3,Name="IT" },
                new JobCategory{JobCategoryId=4,Name="Shop Assistant" },
                new JobCategory{JobCategoryId=5,Name="Store Staff" },
            };

        public static IEnumerable<Country> LoadCountries() => new List<Country>
            {
                new Country{CountryId=1,Name="Germany"},
                new Country{CountryId=2,Name="England"},
                new Country{CountryId=3,Name="Turkey"},
                new Country{CountryId=4,Name="Portugal"},
                new Country{CountryId=5,Name="Spain"},
            };

        public static IEnumerable<Employee> LoadEmployees() => new List<Employee>
            {
                new Employee{ EmployeeId=1,FirstName="Junger",LastName="Klöp", BirthDate=new DateTime(1967,4,12), JoinedDate=new DateTime(1990,1,8),Email="junger.clup@buraksrecords.com", CountryId=1, JobCategoryId=1},
                new Employee{ EmployeeId=2,FirstName="Aleksa",LastName="Bröger", BirthDate=new DateTime(1974,1,11),JoinedDate=new DateTime(2000,1,8),Email="aleksa.broger@buraksrecords.com", CountryId=1, JobCategoryId=3},
                new Employee{ EmployeeId=3,FirstName="Burak",LastName="Selim", BirthDate=new DateTime(1976,4,12),JoinedDate=new DateTime(2001,12,10),Email="burak.selim@buraksrecords.com", CountryId=3, JobCategoryId=2},
                new Employee{ EmployeeId=4,FirstName="Camelia Oscar De La",LastName="Fuante Garcia Velazques", BirthDate=new DateTime(1985,3,8),JoinedDate=new DateTime(2010,9,9),Email="camelia.veazques@buraksrecords.com", CountryId=5, JobCategoryId=4}
            };
    }
}
