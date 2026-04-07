using blog.Data;
using blog.Models;

namespace blog.Services
{
    
    internal class UserService
    {

        public event Action<string> UserCreated;
        public event Action<int> UserDeleted;
        private DataContext _context;
        public UserService(DataContext context) {
            _context = context;
        }
        public User CreateUser(int id,string name,string email,string password)
        {
            var user = new User(id,name,email,password);
            _context.Users.Add(user);
            UserCreated?.Invoke(user.Name);
            return user;
        }
        public void DeleteUser(int id)
        {
            var PostQuries = new QuriesService(_context);
            PostQuries.SearchOnUserWithId(id);
            _context.Users.RemoveAll(u => u.Id == id);
            // delete all posts and comments of the user
             _context.Posts.RemoveAll(p => p.User.Id == id);
             _context.Comments.RemoveAll(c => c.Author.Id == id);
                UserDeleted?.Invoke(id);
        }
       
    }
}
