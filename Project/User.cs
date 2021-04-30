using PostSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSide
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Post[] Posts { get; set; }

        public void ShowPost()
        {
            if (Posts != null)
            {
                foreach (var item in Posts)
                {
                    item.Show();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Post is Not Found");
            }
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("======User Info=====");
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"UserName: {Username}");
            Console.WriteLine($"Surname : {Surname}");
            Console.WriteLine($"Age : {Age}");
            Console.WriteLine($"Email : {Email}");
            Console.WriteLine($"Password : {Password}");
        }

    }

}
