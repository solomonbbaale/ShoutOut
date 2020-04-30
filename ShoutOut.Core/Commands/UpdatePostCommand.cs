using System;
using ShoutOut.Core.Commands.Interfaces;

namespace ShoutOut.Core.Commands
{
    public class UpdatePostCommand:ICommand
    {
        public readonly Guid UserId;
        public readonly Guid PostId;
        public readonly string Message;
        public readonly string Title;
        public UpdatePostCommand(Guid userid, Guid postid, string message, string title)
        {
            UserId = userid;
            PostId = postid;
            Message = message;
            Title = title;
        }
    }
}

