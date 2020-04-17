using ShoutOut.Core.Commands.Interfaces;

namespace ShoutOut.Core.Commands
{
    public class UnregisterUserCommand:ICommand
    {
        private readonly int _userid;

        public UnregisterUserCommand(int userid)
        {
            _userid = userid;
        }
    }
}
