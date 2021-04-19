using BuraksRecordShopHRM.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuraksRecordShopHRM.App.Services
{
    public interface IJobCategoryDataService
    {
        Task<IEnumerable<JobCategory>> GetAll();
        Task<JobCategory> GetById(int jobCategoryId);
    }
}
