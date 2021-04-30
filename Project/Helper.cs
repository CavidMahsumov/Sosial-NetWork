using AdminSide;
using PostSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSide;

namespace HelperSide
{
    public class Helper
    {
        public static Post MyProperty { get; set; }
        public static Admin[] admins { get; set; }
        public static User[] users { get; set; }
        public static Admin admin { get; set; }
        public static User user { get; set; }
        public static bool CheckAdmin(string passsword, string username)
        {
            foreach (var item in admins)
            {
                if ((username == item.Username||username==item.Email) && passsword == item.Password)
                {
                    admin = item;
                    return true;
                }
            }
            return false;
        }

        public static bool CheckUser(string email, string password)
        {
            foreach (var item in users)
            {
                if (email == item.Email && password == item.Password)
                {
                    user = item;
                    return true;
                }
            }
            return false;
        }

    }
}
