using System;
using ShoutOut.Core.Commands.Interfaces;

namespace ShoutOut.Core.Commands
{
    public class UpdateUserCommand:ICommand
    {
        public readonly string Handle;
        public readonly string FirstName;
        public readonly string LastName;
        public readonly string Bio;
        public readonly string Email;
        public readonly string Profile;
        public readonly Guid UserId;

        public UpdateUserCommand(Guid userId,string handle, string firstName, string lastName, string bio, string email, string profile)
        {
            UserId = userId;
            Handle = handle;
            FirstName = firstName; 
            LastName = lastName;
            Bio = bio;
            Email = email;
            Profile = profile;
        }
    }
}
