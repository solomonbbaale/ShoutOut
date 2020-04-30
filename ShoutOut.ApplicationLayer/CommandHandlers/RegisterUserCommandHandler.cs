using ShoutOut.ApplicationLayer.CommandHandlers.Interfaces;
using ShoutOut.ApplicationLayer.Helpers;
using ShoutOut.Core.Commands;
using ShoutOut.Core.Entities;
using ShoutOut.Infrastructure.Repository;

namespace ShoutOut.ApplicationLayer.CommandHandlers
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IRepository<User> _userRepository;

        public RegisterUserCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        //TODO:do we need a decorator attribute for handling exceptions

        //TODO:what happens when an exception is thrown

        public Result Execute(RegisterUserCommand command)
        {
            var user = new User(command.Handle, command.FirstName, command.LastName, command.Bio, command.Email, command.Profile);

            _userRepository.Add(user);

            _userRepository.Save();

            return Result.Success();
        }
    }
}
