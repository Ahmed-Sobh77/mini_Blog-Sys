using blog.Models;
using blog.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace blog.ConsoleDisplay
{
    internal class RunProgram
    {
        private static Data.DataContext _context = new Data.DataContext();

        public static void AskUser()
        {
            int token = 1;
            while (token>0&&token<3)
            {
                Console.WriteLine("Enter 1 to Create a user");
                Console.WriteLine("Enter 2 If you have an account");
                Console.WriteLine("enter 0 to exit");
                
                token=Convert.ToInt32(Console.ReadLine());
                if (token == 1)
                {
                   new Tokens(_context).Token1();
                }
                else if (token == 2)
                {
                  new Tokens(_context).Token2();
                }
            }
        }
    }
}
