using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Facade.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeIoController : ControllerBase
    {
        private readonly IEmployeeCommandFacade commandFacade;

            public EmployeeIoController(IEmployeeCommandFacade commandFacade)
            {
                this.commandFacade = commandFacade;
            }

            [HttpPost()]
            public void CreateIO(EmployeeIOCommand command)
            {
                commandFacade.AddIO(command);
            }
        
    }
}
