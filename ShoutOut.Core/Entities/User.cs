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

        public virtual ICollection<Post> Posts { get; }
        public string Handle { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Bio { get; protected set; }
        public string Email { get; protected set; }
        public string Profile { get; protected set; }

        public void UpdateUser(string handle, string firstName, string lastName, string bio, string email,
            string profile)
        {
            Handle = handle;
            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
            Email = email;
            Profile = profile;
        }

        public void AddPost(Post post)
        {
            Posts.Add(post);
        }
    }
}
