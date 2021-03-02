using HR.Framework.Core.ApplicationService;
using HR.Framework.Core.Facade;

namespace HR.Framework.Facade
{
    public abstract class FacadeCommandBase : ICommandFacade
    {
        protected readonly ICommandBus CommandBus;

        protected FacadeCommandBase(ICommandBus commandBus)
        {
            this.CommandBus = commandBus;
        }
    }
}
