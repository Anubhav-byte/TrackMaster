using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackMaster.Domain.Employees;

namespace TrackMaster.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployee _employeeRepository;
        public EmployeeController(IEmployee employeeRepository) {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            await _employeeRepository.AddEmployee(addEmployeeRequest);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetSubordinates(int employeeId)
        {
            
            return Ok();
        }
    }
}
