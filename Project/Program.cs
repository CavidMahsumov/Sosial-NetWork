using AdminSide;
using HelperSide;
using NotficationSide;
using System;
using UserSide;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User
            {
                Id = 1,
                Username = "mahsumov_",
                Surname = "Mahsumov",
                Age = 16,
                Email = "mehsumovcavid@gmail.com",
                Password = "Cavid123"
            };
            User user2 = new User
            {
                Id = 2,
                Username = "mahsumov_",
                Surname = "Mahsumov",
                Age = 16,
                Email = "mehsumovcavid@gmail.com",
                Password = "Cavid123"
            };
            Admin admin1 = new Admin
            {
                Username = "1",
                Password = "1",
                Id = 1,
                Email = "admin@mail.ru"
            };
            Admin admin2 = new Admin
            {
                Username = "admin",
                Password = "adminadmin",
                Id = 1,
                Email = "admin@mail.ru"
            };
            User[] users = new User[2] { user1, user2 };
            Admin[] admins = new Admin[2] { admin1, admin2 };
            Helper.users = users;
            Helper.admins = admins;
            int choose = 0;
            string email;
            string password;
            int choose2;
            int id = 0;
            int back = 0;
            void BackAdminUserSelection()
            {
                Console.Clear();
                AgainRequest();
            }
            void NotficationSide()
            {
                Helper.admin.ShowNotfication();
                Console.WriteLine("1)Back");
                choose = int.Parse(Console.ReadLine());
                if (choose == 1)
                {
                    AdminSelection();
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong Choose!");
                    NotficationSide();

                }

            }
            void AdminSelection()
            {
                Console.Clear();
                Console.WriteLine("1)Share Post");
                Console.WriteLine("2)Show Notfication");
                Console.WriteLine("3)Back");

                Console.Write("Your Selection  : ");
                int choose1 = int.Parse(Console.ReadLine());
                if (choose1 == 1)
                {
                    Helper.admin.AddPost();

                    foreach (var item in admins)
                    {
                        item.Show();

                    }
                    Console.WriteLine("1)Back");
                    choose = int.Parse(Console.ReadLine());
                    if (choose == 1)
                    {
                        AdminSelection();
                        Console.ResetColor();
                    }
                }
                else if (choose1 == 2)
                {
                    Helper.admin.ShowNotfication();

                    System.Threading.Thread.Sleep(2000);
                    AdminSelection();



                }
                else if (choose1 == 3)
                {
                    BackAdminUserSelection();
                }
            }
            void Select()
            {
                Console.WriteLine("1)Share Post");
                Console.WriteLine("2)Show Notfication");
                Console.WriteLine("3)Back");
                Console.Write("Your Selection  : ");
                int choose1 = int.Parse(Console.ReadLine());
                if (choose1 == 1)
                {
                    Helper.admin.AddPost();

                    foreach (var item in admins)
                    {
                        item.Show();

                    }
                    Console.ResetColor();
                    Console.WriteLine("1)Back");

                    choose = int.Parse(Console.ReadLine());
                    if (choose == 1)
                    {
                        AdminSelection();
                        Console.ResetColor();
                    }
                }
                else if (choose1 == 2)
                {
                    NotficationSide();
                }
                else if (choose1 == 3)
                {
                    BackAdminUserSelection();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong Choose"); ;
                    System.Threading.Thread.Sleep(1000);
                    Console.ResetColor();
                    Console.Clear();
                    Select();
                }
            }
            void AdminSide()
            {
                Console.WriteLine("========Please Enter the Username and Password=======");
                Console.Write("Username : ");
                string username = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Password : ");
                string password1 = Console.ReadLine();
                if (Helper.CheckAdmin(password1, username))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Sign in Succesfly");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Console.ResetColor();
                    Select();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong UserName or Password");
                    System.Threading.Thread.Sleep(2000);
                    Console.ResetColor();
                    AdminSide();
                }
            }
            void InputUSerNameorPasswordForUser()
            {
                Console.WriteLine("==========Please Enter the Email and Password======== ");
                Console.Write("Enter the Email : ");
                email = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Enter The Password : ");
                password = Console.ReadLine();
            }
            void Back()
            {
                Console.Clear();
                Console.WriteLine("1)Back");
                back = int.Parse(Console.ReadLine());
                if (back == 1)
                {
                    AgainRequest();
                }
            }
            void WrongIdSearchPost()
            {
                Console.Write("Enter The Id : ");
                id = int.Parse(Console.ReadLine());
                foreach (var item in admins)
                {
                    if (item.PostCount > 0)
                    {
                        item.searchPost(id);
                        Console.WriteLine("1)Back ");
                        Console.WriteLine("2)Like other Post ");
                        int chooseAgain = int.Parse(Console.ReadLine());
                        if (chooseAgain == 1)
                        {
                            Back();
                        }
                        else if (chooseAgain == 2)
                        {
                            WrongIdSearchPost();
                        }


                    }


                }
            }

            void AgainRequest()
            {
                Console.ResetColor();
                Console.WriteLine("Please Enter The Choose");
                Console.WriteLine("1)Admin");
                Console.WriteLine("2)User");
                Console.WriteLine("3)Exit");
                choose = int.Parse(Console.ReadLine());
                if (choose == 1)
                {

                    AdminSide();


                }
                else if (choose == 2)
                {
                    InputUSerNameorPasswordForUser();
                    if (Helper.CheckUser(email, password))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Sign in successfully");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        Console.ResetColor();
                        Console.WriteLine("1)Show Post");
                        Console.WriteLine("2)Back");
                        choose2 = int.Parse(Console.ReadLine());
                        if (choose2 == 1)
                        {
                            foreach (var item in admins)
                            {
                                if (item.PostCount > 0)
                                {
                                    Console.WriteLine($"{item.Username} have {item.PostCount} post");

                                    for (int i = 0; i < Helper.admin.PostCount; i++)
                                    {
                                        WrongIdSearchPost();
                                        Back();
                                    }

                                }
                                else
                                {
                                    Console.WriteLine($"{item.Username} Post is Not found");
                                    System.Threading.Thread.Sleep(2000);
                                    Console.Clear();
                                    AgainRequest();
                                }
                            }

                        }
                        else if (choose2 == 2)
                        {
                            Console.Clear();
                            AgainRequest();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong Password Or UserName");
                        System.Threading.Thread.Sleep(2000);
                        Console.ResetColor();
                        Console.Clear();
                        AgainRequest();

                    }
                }
                else if (choose == 3)
                {
                    System.Environment.Exit(0);

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong Choose");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    AgainRequest();
                }
            }
            //--------------------Start
            AgainRequest();


        }
    }
}
