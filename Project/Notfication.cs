using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NotficationSide
{
    public class Notfication
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string FromUser { get; set; }

        public void Show()
        {
            Console.WriteLine("======Notfication Info=======");
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"Text : {Text}");
            Console.WriteLine($"DateTime : {DateTime}");
            Console.WriteLine($"FromUser : {FromUser}");
        }

    }

}
