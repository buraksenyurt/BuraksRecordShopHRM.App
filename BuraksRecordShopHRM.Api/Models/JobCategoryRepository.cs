using BuraksRecordShopHRM.Shared;
using System.Collections.Generic;
using System.Linq;

namespace BuraksRecordShopHRM.Api.Models
{
    public class JobCategoryRepository
        : IJobCategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public JobCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<JobCategory> GetAll()
        {
            return _appDbContext.JobCategories;
        }

        public JobCategory GetById(int jobCategoryId)
        {
            return _appDbContext
                .JobCategories
                .FirstOrDefault(c => c.JobCategoryId == jobCategoryId);
        }
    }
}
