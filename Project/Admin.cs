using HelperSide;
using NotficationSide;
using PostSide;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSide
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Post[] Posts { get; set; }
        public int PostCount { get; set; }
        public Notfication[] Notfications { get; set; }
        public int NotficationCount { get; set; }

        static int myid = 0;
        public Post ReadLinePost()
        {
            //int id=default;
            Console.WriteLine("Please Enter The Post Contect");
            Post post = new Post
            {
                Content = Console.ReadLine(),
                CreateDateTime = DateTime.Now,
                Id = ++myid,
                LikeCount = 0,
                WiewCount = 0
            };

            return post;



        }
        public void AddPost()
        {

            Post[] post = new Post[++PostCount];
            if (Posts != null)
            {
                Posts.CopyTo(post, 0);
            }
            post[post.Length - 1] = ReadLinePost();
            Posts = post;
        }

        public void searchPost(int id)
        {
            if (Posts != null)
            {
                foreach (var item in Posts)
                {
                    if (id == item.Id)
                    {
                        ++item.WiewCount;
                        Notfication notf = new Notfication
                        {
                            DateTime = DateTime.Now,
                            FromUser = Helper.user.Username,
                            Id = Helper.user.Id,
                            Text = $"User {Helper.user.Username} saw Post"
                        };
                        Helper.admin.AddNotfiaction(notf);
                        item.Show();
                        Console.WriteLine("1)Like");
                        int choose = int.Parse(Console.ReadLine());
                        if (choose == 1)
                        {
                            ++item.LikeCount;
                            Notfication notf1 = new Notfication
                            {
                                DateTime = DateTime.Now,
                                FromUser = Helper.user.Username,
                                Id = Helper.user.Id,
                                Text = $"User  {Helper.user.Username} liked Your Post",
                            };
                            SendMail.SendMail1();
                            Helper.admin.AddNotfiaction(notf1);
                           
                        }

                        Console.Clear();
                        item.Show();

                        break;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

        }
        public void ShowNotfication()
        {
            if (Notfications != null)
            {
                foreach (var item in Notfications)
                {
                    item.Show();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Notfication Not Found");
                Console.ResetColor();
            }
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("========Admin Info=========");
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"UserName : {Username}");
            Console.WriteLine($"Email : {Email}");
            Console.WriteLine($"Password : {Password}");
            if (Posts != null)
            {
                foreach (var item in Posts)
                {
                    item.Show();
                }
            }

        }
        public void AddNotfiaction(Notfication notfication)
        {
            Notfication[] newnotfication = new Notfication[++NotficationCount];
            if (Notfications != null)
            {
                Notfications.CopyTo(newnotfication, 0);
            }
            newnotfication[newnotfication.Length - 1] = notfication;
            Notfications = newnotfication;
        }


    }
}