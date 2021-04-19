using BuraksRecordShopHRM.Shared;
using System.Collections.Generic;

namespace BuraksRecordShopHRM.Api.Models
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAll();
        JobCategory GetById(int jobCategoryId);
    }
}
