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
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Profile = command.Profile,
                Handle = command.Handle,
                Email = command.Email,
                Bio = command.Bio,
            };

            _userRepository.Add(user);

            _userRepository.Save();

            return Result.Success();
        }
    }
}
