using BuraksRecordShopHRM.App.Services;
using BuraksRecordShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BuraksRecordShopHRM.App.Components
{
    public partial class QuickCreateEmployeeDialog
    {
        public Employee Employee { get; set; } = new Employee { JobCategoryId = 1, CountryId = 1, BirthDate = DateTime.Now.AddYears(-20), JoinedDate = DateTime.Now };
        [Inject]
        public EmployeeDataService EmployeeDataService{ get; set; }
        public bool ShowDialog { get; set; }

        public void Show()
        {
            Employee = new Employee { JobCategoryId = 1, CountryId = 1, BirthDate = DateTime.Now.AddYears(-20), JoinedDate = DateTime.Now };
            ShowDialog = true;
            StateHasChanged(); // State değiştiği için bileşeni tekrardan render et
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        public async Task OnHandleValidSubmit()
        {
            await EmployeeDataService.Create(Employee);
            ShowDialog = false;
        }
    }
}
