
using HR.ShiftContext.ApplicationService.Contracts.Shifts;
using Microsoft.AspNetCore.Mvc;
using HR.ShiftContext.Facade.Contracts;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftCommandFacade commandFacade;

        public ShiftController(IShiftCommandFacade commandFacade)
        {
            this.commandFacade = commandFacade;
        }

        [HttpPost()]
        public void ShiftCreate(ShiftCreateCommand command)
        {
            this.commandFacade.ShiftCreate(command);
        }

        [HttpPost()]
        public void ShiftUpdate(ShiftUpdateCommand command)
        {
            this.commandFacade.ShiftUpdate(command);
        }

        [HttpPost()]
        public void RemoveShift(ShiftRemoveCommand command)
        {
            this.commandFacade.ShiftRemove(command);
        }

    }
}
