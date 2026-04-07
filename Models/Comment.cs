using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace blog.Models
{
    internal class Comment : Content
    {
        private static int currentId = 0;
        public int Pid { get; private set; }
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Comment text cannot be empty.");
                if (value.Length > 500)
                    throw new ArgumentException("Comment text is too long (max 500 chars).");
                _text = value;
            }
        }
        public User Author { get; set; } 
        public Comment(string s,User author)
        {
            Pid = ++currentId;
            Text = s;
            Author = author;
            

        }
        public override void display()
        {
            Console.WriteLine($"Comment by {Author.Name}: {Text}");
        }
            public override string ToString()
            {
                return $"Comment ID: {Pid}, Author: {Author.Name}, Text: {Text}";
        }
    }
}
