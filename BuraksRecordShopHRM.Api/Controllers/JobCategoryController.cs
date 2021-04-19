using BuraksRecordShopHRM.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuraksRecordShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoryController : ControllerBase
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;
        public JobCategoryController(IJobCategoryRepository jobCategoryRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_jobCategoryRepository.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_jobCategoryRepository.GetById(id));
        }
    }
}
