using System;
using System.Collections.Generic;
using System.Text;

namespace blog.Models
{
    internal class User
    {
        public int Id { get; private set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        public User(int id,string name,string email,string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }
        public override string ToString()
        {
            return $"User ID: {Id}, Name: {Name}, Email: {Email}";
        }
        

    }
}
