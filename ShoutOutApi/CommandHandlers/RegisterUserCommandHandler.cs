using ShoutOut.Core.Commands;
using ShoutOutApi.Helpers;

namespace ShoutOutApi.CommandHandlers
{
    public class RegisterUserCommandHandler:ICommandHandler<RegisterUserCommand>
    {
        private readonly RegisterUserCommand _command;

        public RegisterUserCommandHandler(RegisterUserCommand command)
        {
            _command = command;
        }
        public Result Execute(RegisterUserCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
