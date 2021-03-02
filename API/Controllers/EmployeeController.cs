using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Facade.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeCommandFacade commandFacade;
        
        public EmployeeController(IEmployeeCommandFacade commandFacade)
        {
            this.commandFacade = commandFacade;
        }

        [HttpPost()]
        public void CreateEmployee(EmployeeCreateCommand command)
        {
            commandFacade.CreateEmployee(command);
        }

        [HttpPost()]
        public void UpdateEmployee(EmployeeUpdateCommand command)
        {
            commandFacade.UpdateEmployee(command);
        }

        [HttpPost()]
        public void RemoveEmployee(EmployeeDeleteCommand command)
        {
            commandFacade.RemoveEmployee(command);
        }
    }
}
