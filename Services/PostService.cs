using blog.Data;
using blog.Models;
using System;
using System.Collections.Generic;

namespace blog.Services
{
    internal class PostService
    {
        public event Action<Post> PostCreated;
        public event Action<Comment> CommentAdded;
        public event Action<Post> PostLiked;

        private readonly DataContext _context;

        public PostService(DataContext dc)
        {
            _context = dc;
        }

        public Post CreatePost(string content, User user)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("content can't be empty");

            var post = new Post(content, user);

            _context.Posts.Add(post);

            PostCreated?.Invoke(post);
            return post;
        }

        public void AddComment(Post post, User user, string comment)
        {
            if (post == null || user == null)
                throw new ArgumentException("invalid post or user");

            var newComment = new Comment(comment, user);

            post.Comments.Add(newComment);
            _context.Comments.Add(newComment);

            CommentAdded?.Invoke(newComment);
        }

        public void AddLike(Post post, User user)
        {
            if (!post.Likes.Contains(user))
            {
                post.Likes.Add(user);

                PostLiked?.Invoke(post);
            }
        }

        public IReadOnlyList<Post> AllPosts()
        {
            return _context.Posts.AsReadOnly();
        }
    }
}