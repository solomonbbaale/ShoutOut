using ShoutOut.ApplicationLayer.Helpers;
using ShoutOut.Core.Commands;
using ShoutOut.Core.Entities;
using ShoutOut.Infrastructure.Repository;

namespace ShoutOut.ApplicationLayer.CommandHandlers
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IRepository<User> _userRepository;

        public UpdateUserCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Result Execute(UpdateUserCommand command)
        {
            var user = _userRepository.GetEntityById(command.UserId);

            if (user == null) return Result.Fail(new[] { "User not found" });

            user.UpdateUser(command.Handle, command.FirstName, command.LastName, command.Bio, command.Email, command.Profile);

            _userRepository.Update(user);

            _userRepository.Save();

            return Result.Success();
        }
    }
}
