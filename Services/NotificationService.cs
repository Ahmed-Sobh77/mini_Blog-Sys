using blog.Models;
using System;

namespace blog.Services
{
    internal class NotificationService
    {
        public void OnPostCreated(Post post)
        {
            Console.WriteLine($"New Post Created: {post.Content}");
        }

        public void OnCommentAdded(Comment comment)
        {
            Console.WriteLine($"New Comment by {comment.Author.Name}: {comment.Text}");
        }

        public void OnPostLiked(Post post)
        {
            Console.WriteLine($"Post Liked: {post.Content}");
        }
        public void OnUserCreated(string userName)
        {
            Console.WriteLine($"New User Created: {userName}"); 

        }

        public void OnUserDeleted(int id)
        {
            Console.WriteLine($"User Deleted: {id}");
        }

       
    }
}