using ShoutOut.ApplicationLayer.Helpers;
using ShoutOut.Core.Commands;

namespace ShoutOut.ApplicationLayer.CommandHandlers
{
    public class RegisterUserCommandHandler:ICommandHandler<RegisterUserCommand>
    {
        public RegisterUserCommandHandler(RegisterUserCommand command)
        {

        }
        public Result Execute(RegisterUserCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
