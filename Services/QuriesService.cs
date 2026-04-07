using blog.Data;
using blog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace blog.Services
{
    internal class QuriesService
    {
        private DataContext _context;
        public QuriesService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Post> PostsWhichHasLikes()
        {
            return _context.Posts.Where(p => p.Likes.Count > 0);
            
        }
        public IEnumerable<Post> PostsWithoutComments()
        {
            return _context.Posts.Where(p => p.Comments.Count == 0);
        }
        public int NumOfPosts()
        {
            return _context.Posts.Count;
        }
        public IEnumerable<Post>PostsWithLikesMoreThan_X(int x)
        {
            return from p in _context.Posts
                   where p.Likes.Count > x
                   select p;
        }
        public Post? PostWithTheMostCountOfLikes()
        {

            return _context.Posts.OrderByDescending(p => p.Likes.Count).FirstOrDefault();
        }

        public IEnumerable<Post> PostsSortedOnLikes()
        {
            return _context.Posts.OrderBy(p => p.Likes.Count);
        }
        public int NumOfCommentsOnPostWithId(int id)
        {
            var post=_context.Posts.Where(p => p.Pid == id).FirstOrDefault();
            if (post == null) return 0;
            else return post.Comments.Count;
        }
        public Post? SearchOnPostWithId(int id)
        {
            var post = _context.Posts.Where(p => p.Pid == id).FirstOrDefault();
            return post;
        }
        public User? SearchOnUserWithId(int id)
        {
            var user = _context.Users.Where(p => p.Id == id).FirstOrDefault();
            return user;
        }

        public IEnumerable<Post> SearchOnPostWithContent(string s)
        {
            return _context.Posts.Where(P => P.Content.ToLower().Contains(s.ToLower()));
        }
        public IEnumerable<Comment> AllComments()
        {
            return _context.Posts.SelectMany(p => p.Comments);
        }
        public IEnumerable<User> UsersMakesLikesOnPost(int id)
        {
            var post = SearchOnPostWithId(id);
            if (post == null)
            {
                throw new Exception("Post not found");
            }
            return post.Likes;
        }
        public IEnumerable<Post> Top_X_PostsInInteractive(int x) => _context.Posts.OrderByDescending(p => p.Likes.Count + p.Comments.Count).Take(x);
        public User? MostActiveUserInPlatform()
        {
            var user = _context.Posts
        .SelectMany(p => p.Likes)
        .GroupBy(l => l.Id)
        .Select(g => new { UserId = g.Key, Count = g.Count() })
        .OrderByDescending(x => x.Count)
        .FirstOrDefault();

            if (user==null)
            {
                throw new Exception("user not found");
            }
            return SearchOnUserWithId(user.UserId);

        }
    }
}
