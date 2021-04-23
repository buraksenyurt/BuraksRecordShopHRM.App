using BuraksRecordShopHRM.App.Components;
using BuraksRecordShopHRM.App.Services;
using BuraksRecordShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuraksRecordShopHRM.App.Pages
{
    public partial class EmployeeOverview
    {
        public IEnumerable<Employee> Employees { get; set; }

        /*
            EmployeeOverview bileşeninin ihtiyacı olan veri hizmetini IEmployeeDataService üstünden
            enjtekte edilen aşağıdaki özellikle karşılayacağız.
            IEmployeeDataService üstünden gelen asıl nesnenin ne olacağını program.cs'te register etmiştik.
        */
        [Inject]
        public IEmployeeDataService EmployeeDataService {get;set;}

        public QuickCreateEmployeeDialog QuickCreateEmployeeDialog { get; set; }
        //public IEnumerable<Country> Countries { get; set; }
        //public IEnumerable<JobCategory> JobCategories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            // DataService nesnesi bu bilgiyi Web Api'mizden isteyecek
            Employees = (await EmployeeDataService.GetAll()).ToList();
            //Countries = DataLoader.LoadCountries();
            //JobCategories = DataLoader.LoadJobs();
            //Employees = DataLoader.LoadEmployees();

            //return base.OnInitializedAsync();
        }

        public void QuickCreate()
        {
            QuickCreateEmployeeDialog.Show();
        }

        /*
            Modal dialog ile bir çalışan eklendiğinde, QuickCreateEmployeeDialog bileşeninin OnHandleValidSubmit metodu içerisindeki 
            DialogCloseCallback.InvokeAsync(true) fonksiyonu tetiklenir. Bu tetikleme de sayfadaki QuickCreateEmployeeDialog bileşeninin 
            DialogCloseCallback eventi gerçekleştiğinden çalışan aşağıdaki metodu tetikler. 
            Dolayısıyla Modal Dialog bileşeni ile kullanıldığı bileşen arasında Event Based bir iletişim sağlanmış olur.
        */
        public async void DialogCloseCallback_Triggered()
        {
            Employees = (await EmployeeDataService.GetAll()).ToList();
            StateHasChanged();
        }
    }
}
