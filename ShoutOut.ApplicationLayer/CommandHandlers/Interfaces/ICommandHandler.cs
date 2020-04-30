using ShoutOut.ApplicationLayer.Helpers;
using ShoutOut.Core.Commands.Interfaces;

namespace ShoutOut.ApplicationLayer.CommandHandlers.Interfaces
{
    public interface ICommandHandler<in T>
    where T:ICommand
    {
        Result Execute(T command);
    }
}
