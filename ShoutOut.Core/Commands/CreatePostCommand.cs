using System;
using ShoutOut.Core.Commands.Interfaces;
using ShoutOut.Core.Entities;

namespace ShoutOut.Core.Commands
{
    public class CreatePostCommand:ICommand
    {
        public readonly Guid UserId;

        public readonly Post CreatedPost;

        public CreatePostCommand(Guid userid, Post createdPost)
        {
            UserId = userid;

            CreatedPost = createdPost;
        }
    }
}
