using ShoutOut.Core.Commands.Interfaces;
using ShoutOutApi.Helpers;

namespace ShoutOutApi.CommandHandlers
{
    public interface ICommandHandler<in T>
    where T:ICommand
    {
        Result Execute(T command);

    }
}
