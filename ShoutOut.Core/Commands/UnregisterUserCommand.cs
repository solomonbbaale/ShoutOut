using System;
using ShoutOut.Core.Commands.Interfaces;

namespace ShoutOut.Core.Commands
{
    public class UnregisterUserCommand:ICommand
    {
        public readonly Guid Userid;

        public UnregisterUserCommand(Guid userid)
        {
            Userid = userid;
        }
    }
}
