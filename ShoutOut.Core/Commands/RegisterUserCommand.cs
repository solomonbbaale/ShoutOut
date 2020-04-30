using ShoutOut.Core.Commands.Interfaces;

namespace ShoutOut.Core.Commands
{
    public class RegisterUserCommand:ICommand
    {
        public readonly string Handle;
        public readonly string FirstName;
        public readonly string LastName;
        public readonly string Bio;
        public readonly string Email;
        public readonly string Profile;

        public RegisterUserCommand(string handle, string firstName, string lastName, string bio, string email, string profile)
        {
            Handle = handle;
            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
            Email = email;
            Profile = profile;
        }
    }
}

