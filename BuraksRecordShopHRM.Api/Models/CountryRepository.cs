using BuraksRecordShopHRM.Shared;
using System.Collections.Generic;
using System.Linq;

namespace BuraksRecordShopHRM.Api.Models
{
    public class CountryRepository 
        : ICountryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CountryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _appDbContext.Countries;
        }

        public Country GetById(int countryId)
        {
            return _appDbContext
                .Countries
                .FirstOrDefault(c => c.CountryId == countryId);
        }
    }
}
