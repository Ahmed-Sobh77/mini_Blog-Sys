using blog.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace blog.ConsoleDisplay
{
    internal class Tokens
    {
        private Data.DataContext _context;
        public Tokens(Data.DataContext context)
        {
            _context = context;
        }

        public void Token1()
        {
            Console.WriteLine("Creating a new user...");
            Console.WriteLine("Please enter your id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            if (Validation.CheckEmail(email) && Validation.CheckPassword(password))
            {
                var userservice = new UserService(_context);
                var user = userservice.CreateUser(id, name, email, password);
                var notifi = new NotificationService();
                userservice.UserCreated += notifi.OnUserCreated;

            }
            else
            {
                Console.WriteLine("Invalid email or password. Please try again.");
            }
        }
        public void Token2()
        {

            Console.WriteLine("Please enter the id:");
            int userId = Convert.ToInt32(Console.ReadLine());
            var QuriesService = new QuriesService(_context);
            var user = QuriesService.SearchOnUserWithId(userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
            }
            else
            {
                Console.WriteLine("Enter your Password");
                string password = Console.ReadLine();
                if (user.Password == password)
                {
                    Console.WriteLine("You are logged in.");
                    if (Validation.CheckYourRole(user))
                    {
                        int num = 1;
                        while (num != 0)
                        {
                            Console.WriteLine("Enter 1 to make to see analytics:");
                            Console.WriteLine("Enter 2 to make a post:");
                            Console.WriteLine("Enter 3 to delete a post:");
                            Console.WriteLine("Enter 4 to delete a user:");
                            Console.WriteLine("Enter 0 to log out:");

                            num = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    else
                    {
                        int num = 1;
                        while (num != 0)
                        {
                            Console.WriteLine("Enter 1 to make a post:");
                            Console.WriteLine("Enter 2 to see all posts:");
                            Console.WriteLine("Enter 3 to make a comment:");
                            Console.WriteLine("Enter 4 to make a like:");
                            Console.WriteLine("Enter 0 to log out:");

                            num = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                }
            }
        }
    }
}
