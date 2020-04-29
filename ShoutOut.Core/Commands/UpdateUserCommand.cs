using ShoutOut.Core.Commands.Interfaces;

namespace ShoutOut.Core.Commands
{
    public class UpdateUserCommand:ICommand
    {
        private string _handle;
        private string _firstName;
        private string _lastName;
        private string _bio;

        public UpdateUserCommand(int userId,string handle, string firstName, string lastName, string bio, string email, string profile)
        {
            _handle = handle;
            _firstName = firstName;
            _lastName = lastName;
            _bio = bio;
        }
    }
}
