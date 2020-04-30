using System;
using System.Collections.Generic;

namespace ShoutOut.Core.Entities
{
    public class Post : Entity
    {
        public Post() { }
        public Post(string title, string message, Guid posterOwnerId, User postOwner)
        {
            Title = title;
            Message = message;
            PosterOwnerId = posterOwnerId;
            PostOwner = postOwner;
            Replies = new List<Post>();
        }

        public string Title { get; protected set; }
        public string Message { get; protected set; }
        public virtual ICollection<Post> Replies { get; protected set; }
        public User PostOwner { get; protected set; }
        public Guid PosterOwnerId { get; protected set; }

        public void UpdatePost(string title, string message)
        {
            Title = title;
            Message = message;
        }
    }
}
