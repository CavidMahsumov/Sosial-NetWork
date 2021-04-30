using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostSide
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int LikeCount { get; set; }
        public int WiewCount { get; set; }
        public void Show()
        {
            Console.WriteLine($"======Post Info======");
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"Content : {Content}");
            Console.WriteLine($"CreateDateTime : {CreateDateTime}");
            Console.WriteLine($"Like Count : {LikeCount}");
            Console.WriteLine($"Wiew Count : {WiewCount}");

        }
    }

}