using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace blog.Models
{
    internal class Post : Content
    {
        private static int currentId = 0;
        public int Pid { get; private set; }
        private string _content;
        public string Content
        {
            get => _content;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Comment text cannot be empty.");
                if (value.Length > 500)
                    throw new ArgumentException("Comment text is too long (max 500 chars).");
                _content = value;
            }
        }
        public User User { get; private set; }
        public List<Comment> Comments;
        public List<User> Likes;

        public Post(string s, User user)
        {
            Pid = ++currentId;
            _content = s;
            User = user;
            Comments = new List<Comment>();
            Likes = new List<User>();
          

        }
        public override void display()
        {
            Console.WriteLine(_content);   
        }
        public override string ToString()
        {
            return $"Post ID: {Pid}, Content: {_content}, Likes: {Likes.Count}, Comments: {Comments.Count}";
        }
        }
}
