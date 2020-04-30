using System.Collections.Generic;

namespace ShoutOut.Core.Entities
{
    public class User : Entity
    {
        public User() { }
        public User(string handle, string firstName, string lastName, string bio, string email, string profile)
        {
            Handle = handle;
            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
            Email = email;
            Profile = profile;
            Posts = new List<Post>();
        }

        public IEnumerable<Post> Posts { get; }
        public string Handle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Profile { get; set; }
    }
}
