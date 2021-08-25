using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int favNumber = 0; 
            Console.WriteLine("Hello Mingshen Wu!");
            Console.WriteLine("What is your favorite number?");
            favNumber = Convert.ToInt32(Console.ReadLine()) ;
            Console.WriteLine("You enter the number " + favNumber + "as your favorite number! I love it!");
        }
    }
}
