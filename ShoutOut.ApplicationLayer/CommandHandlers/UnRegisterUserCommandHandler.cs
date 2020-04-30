using ShoutOut.ApplicationLayer.CommandHandlers.Interfaces;
using ShoutOut.ApplicationLayer.Helpers;
using ShoutOut.Core.Commands;
using ShoutOut.Core.Entities;
using ShoutOut.Infrastructure.Repository;

namespace ShoutOut.ApplicationLayer.CommandHandlers
{
    public class UnRegisterUserCommandHandler : ICommandHandler<UnRegisterUserCommand>
    {
        private readonly IRepository<User> _userRepository;

        public UnRegisterUserCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Result Execute(UnRegisterUserCommand command)
        {
            var user = _userRepository.GetEntityById(command.Userid);
            
            //TODO: MAY BE REMOVE THIS STRING AND PUT IT SOMEWHERE ELSE

            if (user == null) return Result.Fail(new[] { "User not found" });

            _userRepository.Delete(user);

            _userRepository.Save();

            return Result.Success();
        }
    }
}
