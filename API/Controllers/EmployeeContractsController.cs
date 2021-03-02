using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Facade.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeContractsController : ControllerBase
    {
        private readonly IEmployeeCommandFacade commandFacade;

            public EmployeeContractsController(IEmployeeCommandFacade commandFacade)
            {
                this.commandFacade = commandFacade;
            }

            [HttpPost()]  
            public void CreateContract(EmployeeCreateContract command)
            {
                commandFacade.AddContract(command);
            }

            [HttpPost()]
            public void UpdateContract(EmployeeUpdateContract command)
            {
                commandFacade.UpdateContract(command);
            }

            [HttpPost()]
            public void RemoveContract(EmployeeRemoveContract command)
            {
                commandFacade.RemoveContract(command);
            }

    }
}
