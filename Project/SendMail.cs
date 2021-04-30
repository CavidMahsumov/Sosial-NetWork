using HelperSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    static class SendMail
    {
        public static void SendMail1()
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("cavidm394@gmail.com", "CavidMahsumov"),
                EnableSsl = true,
            };

            smtpClient.Send("cavidm394@gmail.com", "cavidm394@gmail.com","Liked Post",$"{Helper.user.Username} liked your Post");
        }
    }
}
