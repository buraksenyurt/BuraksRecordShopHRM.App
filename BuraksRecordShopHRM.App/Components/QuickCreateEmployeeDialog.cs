using BuraksRecordShopHRM.App.Services;
using BuraksRecordShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;

namespace BuraksRecordShopHRM.App.Components
{
    public partial class QuickCreateEmployeeDialog
    {
        public Employee Employee { get; set; } = new Employee { JobCategoryId = 1, CountryId = 1, BirthDate = DateTime.Now.AddYears(-20), JoinedDate = DateTime.Now };
        [Inject]
        public EmployeeDataService EmployeeDataService{ get; set; }
        public bool ShowDialog { get; set; }
    }
}
