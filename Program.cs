using blog.Models;

namespace blog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new Data.DataContext();
            var PostService = new Services.PostService(context);
            var UserService = new Services.UserService(context);
            var user1=UserService.CreateUser(1, "John Doe", "john@example.com", "password123");
            Post P= PostService.CreatePost("Hello World",user1);
            var notifi = new Services.NotificationService();

            PostService.PostCreated += notifi.OnPostCreated;

        }   
    }
}
