using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Facade.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeAssignShiftController : ControllerBase
    {
        private readonly IEmployeeCommandFacade commandFacade;

            public EmployeeAssignShiftController(IEmployeeCommandFacade commandFacade)
            {
                this.commandFacade = commandFacade;
            }

            [HttpPost()]
            public void CreateAssignShift(EmployeeAssignShiftCommand command)
            {
                commandFacade.AddAssignShift(command);
            }
        
    }
}
