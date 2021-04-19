using BuraksRecordShopHRM.Api.Models;
using BuraksRecordShopHRM.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BuraksRecordShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employeeRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_employeeRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            var createdEmployee = _employeeRepository.Add(employee);
            return Created("employee", createdEmployee);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            var employeeToUpdate = _employeeRepository.GetById(employee.EmployeeId);

            if (employeeToUpdate == null)
                return NotFound();

            _employeeRepository.Update(employee);

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var employeeToDelete = _employeeRepository.GetById(id);
            if (employeeToDelete == null)
                return NotFound();

            _employeeRepository.Delete(id);

            return NoContent();
        }
    }
}
