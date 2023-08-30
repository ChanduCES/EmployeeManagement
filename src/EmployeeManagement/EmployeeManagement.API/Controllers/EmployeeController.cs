using EmployeeManagement.Application.Services;

namespace EmployeeManagement.API.Controllers
{
    [Route($"{ApiRoutes.BaseUrl}/{ApiRoutes.Employee}")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> GetAllAsync()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }
    }
}
