using System.Linq;
using ShoutOut.ApplicationLayer.CommandHandlers.Interfaces;
using ShoutOut.ApplicationLayer.Helpers;
using ShoutOut.Core.Commands;
using ShoutOut.Core.Entities;
using ShoutOut.Infrastructure.Repository;

namespace ShoutOut.ApplicationLayer.CommandHandlers
{
    public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand>
    {
        private readonly IRepository<User> _userRepository;

        public UpdatePostCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Result Execute(UpdatePostCommand command)
        {
            var user = _userRepository.GetEntityById(command.UserId);

            if (user == null) return Result.Fail(new[] { "Not Found" });

            var post = user.Posts.FirstOrDefault(p => p.Id == command.PostId);

            if (post == null) return Result.Fail(new[] { "Not Found" });

            post.UpdatePost(command.Title,command.Message);

            _userRepository.Update(user);

            _userRepository.Save();

            return Result.Success();
        }
    }
}
