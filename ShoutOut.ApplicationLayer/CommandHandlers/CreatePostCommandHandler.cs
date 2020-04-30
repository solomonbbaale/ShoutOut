using ShoutOut.ApplicationLayer.CommandHandlers.Interfaces;
using ShoutOut.ApplicationLayer.Helpers;
using ShoutOut.Core.Commands;
using ShoutOut.Core.Entities;
using ShoutOut.Infrastructure.Repository;

namespace ShoutOut.ApplicationLayer.CommandHandlers
{
    public class CreatePostCommandHandler : ICommandHandler<CreatePostCommand>
    {
        private readonly IRepository<User> _repository;

        public CreatePostCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public Result Execute(CreatePostCommand command)
        {
            var user = _repository.GetEntityById(command.UserId);

            if ( user == null) return Result.Fail(new[] { "User not found" });

            //TODO: Need to create the actual post here and just bring in the contents of the post that is being create
            //TODO: This is to separate the domain entities from the dto contracts that will be passed in from the user
            //TODO :E.g var post = new Post(dto.id, dto.title, dto.message);

            user.AddPost(command.CreatedPost);

            _repository.Save();

            return Result.Success();
        }
    }
}
