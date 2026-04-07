using blog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace blog.ConsoleDisplay
{
    internal class Validation
    {
        public static Boolean CheckYourRole(User user)
        {

            // Implement your role-checking logic here
            //check if the user's email contains "admin"
            //true if the user is an admin, false otherwise
            return user.Email.Contains("admin");
        }
        public static Boolean CheckPassword(string password)
        {
            //check if the password is at least 8 characters long and contains a number
            //check if the password has charcters and numbers
            if (password.Length < 8) return false;
            bool hasNumber = false, haschar = false;
            foreach (char c in password)
            {
                if (char.IsDigit(c)) hasNumber = true;
                if (char.IsLetter(c)) haschar = true;
                if (hasNumber && haschar) return true;
            }
            return hasNumber && haschar;
        }
        public static Boolean CheckEmail(string email)
        {
            string regx = "^[a-zA-Z0-9]+@gmail\\.com$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, regx);
        }
        public static int CanYouBeAdmin(string email)
        {
            //0=>not an admin, 1=> admin, 2=> can be an admin if the pass code is correct
            if (email.Contains("admin"))
            {
                string PassCode = "admin123";
                string enter;
                Console.WriteLine("Enter the pass Code to be an admin:");
                enter = Console.ReadLine();
                int cnt = 0;
                while (cnt < 3 && enter != PassCode)
                {
                    if (enter == PassCode)
                    {
                        return 1;
                    }
                    Console.WriteLine("Wrong pass code. Try again.");
                    enter = Console.ReadLine();
                    cnt++;
                }
                Console.WriteLine("You have entered the wrong pass code 3 times.");
                return 2;

            }
            return 0;
        }
    }
}
