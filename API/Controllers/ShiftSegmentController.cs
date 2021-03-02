
using HR.ShiftContext.ApplicationService.Contracts.Shifts;
using Microsoft.AspNetCore.Mvc;
using HR.ShiftContext.Facade.Contracts;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShiftSegmentController : ControllerBase
    {
        private readonly IShiftCommandFacade commandFacade;

        public ShiftSegmentController(IShiftCommandFacade commandFacade)
        {
            this.commandFacade = commandFacade;
        }

        [HttpPost()]
        public void ShiftSegmentAdd(ShiftSegmentAddCommand command)
        {
            this.commandFacade.ShiftSegmentAdd(command);
        }

        [HttpPost()]
        public void ShiftSegmentUpdate(ShiftSegmentUpdateCommand command)
        {
            this.commandFacade.ShiftSegmentUpdate(command);
        }

        [HttpPost()]
        public void ShiftSegmentRemove(ShiftSegmentRemoveCommand command)
        {
            this.commandFacade.ShiftSegmentRemove(command);
        }
    }
}
