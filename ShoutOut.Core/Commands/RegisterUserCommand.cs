using ShoutOut.Core.Commands.Interfaces;

namespace ShoutOut.Core.Commands
{
    public class RegisterUserCommand:ICommand
    {
        public RegisterUserCommand(string handle, string firstName, string lastName, string bio, string email, string profile)
        {
            Handle = handle;
            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
            Profile = profile;
            UserId = 1;
        }

        public int UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Profile { get;}
        public string Bio { get;}
        public string Handle { get; }
    }
}

