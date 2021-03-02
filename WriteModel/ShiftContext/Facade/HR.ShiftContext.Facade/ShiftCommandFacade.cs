using HR.Framework.Application;
using HR.Framework.Core.ApplicationService;
using HR.Framework.Facade;
using HR.ShiftContext.ApplicationService.Contracts.Shifts;
using HR.ShiftContext.Facade.Contracts;

namespace HR.ShiftContext.Facade
{
    public class ShiftCommandFacade : FacadeCommandBase , IShiftCommandFacade
    {
        public ShiftCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }
        public void ShiftCreate(ShiftCreateCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void ShiftUpdate(ShiftUpdateCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void ShiftRemove(ShiftRemoveCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void ShiftSegmentAdd(ShiftSegmentAddCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void ShiftSegmentRemove(ShiftSegmentRemoveCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void ShiftSegmentUpdate(ShiftSegmentUpdateCommand command)
        {
            CommandBus.Dispatch(command);
        }

    }
}
