using ShoutOut.Core.Commands.Interfaces;

namespace ShoutOut.Core.Commands
{
    public class RegisterUserCommand:ICommand
    {
        private readonly string _handle;
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _bio;

        public RegisterUserCommand(string handle, string firstName, string lastName, string bio, string email, string profile)
        {
            _handle = handle;
            _firstName = firstName;
            _lastName = lastName;
            _bio = bio;
        }
    }
}

