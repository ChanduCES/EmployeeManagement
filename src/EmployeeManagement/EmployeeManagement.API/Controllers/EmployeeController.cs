namespace EmployeeManagement.API.Controllers
{
    [Route($"{ApiRoutes.BaseUrl}/{ApiRoutes.Employee}")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetAllEmployeesDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
