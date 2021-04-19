using BuraksRecordShopHRM.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuraksRecordShopHRM.App.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAll();
        Task<Country> GetById(int countryId);
    }
}
