using System.Collections.Generic;

namespace ShoutOut.Core.Entities
{
    public class Post : Entity
    {
        public Post(string title, string message, User owner, int posterOwnerId, User postOwner)
        {
            Title = title;
            Message = message;
            PosterOwnerId = posterOwnerId;
            PostOwner = postOwner;
            Replies = new List<Post>();
        }

        public string Title { get; set; }
        public string Message { get; set; }
        public IEnumerable<Post> Replies { get; }
        public User PostOwner { get; set; }
        public int PosterOwnerId { get; set; }
    }
}
