using System;
using ShoutOut.Core.Commands.Interfaces;

namespace ShoutOut.Core.Commands
{
    public class UnRegisterUserCommand:ICommand
    {
        public readonly Guid Userid;

        public UnRegisterUserCommand(Guid userid)
        {
            Userid = userid;
        }
    }
}
