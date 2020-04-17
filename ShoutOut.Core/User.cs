using System.Collections.Generic;

namespace ShoutOut.Core
{
    public class ShoutImage : Entity
    {
        public ShoutImage(string name, string extension, byte[] imageBytes)
        {
            Name = name;
            Extension = extension;
            ImageBytes = imageBytes;
        }

        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] ImageBytes { get; set; }
    }

    public class User : Entity
    {
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
