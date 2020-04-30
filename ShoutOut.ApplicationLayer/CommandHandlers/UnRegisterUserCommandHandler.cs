using ShoutOut.ApplicationLayer.Helpers;
using ShoutOut.Core.Commands;
using ShoutOut.Core.Entities;
using ShoutOut.Infrastructure.Repository;

namespace ShoutOut.ApplicationLayer.CommandHandlers
{
    public class UnRegisterUserCommandHandler : ICommandHandler<UnregisterUserCommand>
    {
        private readonly IRepository<User> _userRepository;

        public UnRegisterUserCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Result Execute(UnregisterUserCommand command)
        {
            var user = _userRepository.GetEntityById(command.Userid);

            if (user == null) return Result.Fail(new[] { "User not found" });

            _userRepository.Delete(user);

            _userRepository.Save();

            return Result.Success();
        }
    }
}
