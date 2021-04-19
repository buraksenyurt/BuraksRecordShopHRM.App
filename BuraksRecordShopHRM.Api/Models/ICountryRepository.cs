using BuraksRecordShopHRM.Shared;
using System.Collections.Generic;

namespace BuraksRecordShopHRM.Api.Models
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetById(int countryId);
    }
}
